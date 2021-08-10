using Hangfire;
using MAD.DataWarehouse.SupplierIO.Data;
using MAD.DataWarehouse.SupplierIO.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using MAD.Integration.Common.Jobs;

namespace MAD.DataWarehouse.SupplierIO.Jobs
{
    public class GetSuppliersJob
    {
        private readonly SearchApiClient searchApiClient;
        private readonly SupplierApiClient supplierApiClient;
        private readonly SupplierIODbContext supplierIODbContext;
        private readonly IBackgroundJobClient backgroundJobClient;

        public GetSuppliersJob(SearchApiClient searchApiClient, SupplierApiClient supplierApiClient, SupplierIODbContext supplierIODbContext, IBackgroundJobClient backgroundJobClient)
        {
            this.searchApiClient = searchApiClient;
            this.supplierApiClient = supplierApiClient;
            this.supplierIODbContext = supplierIODbContext;
            this.backgroundJobClient = backgroundJobClient;
        }

        public async Task FindSuppliersToLoad(int skip)
        {
            var result = new List<Supplier>();
            var paginedResult = await searchApiClient.GetSearchDetail(new GetSearchDetailApiRequest
            {
                SearchQuery = "HVAC",
                StartRecord = skip,

                // Get 500, as this is the max the GetSuppliers endpoint can return
                RowCount = 500
            });

            if (paginedResult.Results.Any())
            {
                var nextSkip = skip + paginedResult.RowCount;
                
                // Enqueue the job to get the next page
                this.backgroundJobClient.Enqueue<GetSuppliersJob>(y => y.FindSuppliersToLoad(nextSkip));

                // Enqueue the job to load the supplier details
                var supplierIds = paginedResult.Results.Select(y => y.SupplierId);
                this.backgroundJobClient.Enqueue<GetSuppliersJob>(y => y.CreateLoadSupplierDetailsJob(supplierIds.ToArray()));
            }
        }

        public async Task CreateLoadSupplierDetailsJob(string[] supplierIds)
        {
            if (supplierIds.Length > 500)
                throw new ArgumentException($"{nameof(supplierIds)} must be no larger than 500.");

            var batch = supplierIds;
            var result = await this.supplierApiClient.GetSuppliers(new GetSuppliersApiRequest
            {
                SupplierIds = batch
            });

            this.backgroundJobClient.Enqueue<GetSuppliersJob>(y => y.HandleLoadSupplierDetailsJob(result.JobId));
        }

        [AutomaticRetry(Attempts = 15)]
        public async Task HandleLoadSupplierDetailsJob(string jobId)
        {
            var job = await this.supplierApiClient.GetMatchResults(new GetMatchResultsApiRequest
            {
                JobId = jobId
            });

            switch (job.Data.Status)
            {
                case "Completed":
                    var suppliersToLoad = job.Data.Suppliers.SelectMany(y => y.MatchedSuppliers).ToList();
                    await this.supplierIODbContext.BulkInsertOrUpdateAsync(suppliersToLoad, new BulkConfig
                    {
                        IncludeGraph = true
                    });
                    break;

                case "Failed":
                case "Error":
                case "Exception":
                    BackgroundJobContext.Current.BackgroundJob.SetJobParameter("RetryCount", 15);
                    throw new RemoteJobFailedException(string.Join(Environment.NewLine, job.Errors));

                default:
                    BackgroundJobContext.Current.BackgroundJob.SetJobParameter("RetryCount", 5);
                    throw new WaitingForRemoteJobToCompleteException($"Job is in state: {job.Data.Status}");

            }
        }
    }
}
