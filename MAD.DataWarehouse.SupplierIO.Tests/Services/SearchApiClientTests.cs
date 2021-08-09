using Microsoft.VisualStudio.TestTools.UnitTesting;
using MAD.DataWarehouse.SupplierIO.Services;
using System;
using System.Collections.Generic;
using System.Text;
using MAD.DataWarehouse.SupplierIO.Tests;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using MAD.DataWarehouse.SupplierIO.Data;
using System.Linq;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;

namespace MAD.DataWarehouse.SupplierIO.Services.Tests
{
    [TestClass()]
    public class SearchApiClientTests
    {
        [TestMethod()]
        public async Task GetSearchDetail_WithHVACAsSearchQuery_EnumeratesAllPagesAndSavesIntoDbContext()
        {
            var sp = TestServiceProvider.GetServiceProvider();
            var searchApiClient = sp.GetRequiredService<SearchApiClient>();
            var dbContext = sp.GetRequiredService<SupplierIODbContext>();
            await dbContext.Database.MigrateAsync();

            var result = new List<Supplier>();
            var lastIndex = 0;
            PaginatedApiResult<Supplier> paginedResult;

            do
            {
                paginedResult = await searchApiClient.GetSearchDetail(new GetSearchDetailApiRequest
                {
                    SearchQuery = "HVAC",
                    StartRecord = lastIndex
                });

                lastIndex += paginedResult.RowCount;
                result.AddRange(paginedResult.Results);

            } while (paginedResult.Results.Any());

            await dbContext.BulkInsertOrUpdateAsync(result);
        }

        [TestMethod]
        public async Task GetSuppliers_With500SupplierIds_JobIsCreated()
        {
            var sp = TestServiceProvider.GetServiceProvider();
            var supplierApiClient = sp.GetRequiredService<SupplierApiClient>();
            var dbContext = sp.GetRequiredService<SupplierIODbContext>();
            var supplierIds = await dbContext.Supplier.Select(y => y.SupplierId).Take(500).ToListAsync();
            var getSuppliers = await supplierApiClient.GetSuppliers(new GetSuppliersApiRequest
            {
                SupplierIds = supplierIds
            });

            Assert.IsNotNull(getSuppliers.JobId);
            Assert.AreEqual(getSuppliers.NumberOfInputRecord, 500);
        }

        [DataTestMethod]
        [DataRow("d7e559fb5b6b479e98803e765ffc2551")]
        public async Task GetMatchResults_With500SuppliersJob_SavesSuppliersIntoDatabase(string jobId)
        {
            var sp = TestServiceProvider.GetServiceProvider();
            var supplierApiClient = sp.GetRequiredService<SupplierApiClient>();
            var dbContext = sp.GetRequiredService<SupplierIODbContext>();
            await dbContext.Database.MigrateAsync();

            var getMatchJob = await supplierApiClient.GetMatchResults(new GetMatchResultsApiRequest
            {
                JobId = jobId
            });

            var suppliers = getMatchJob.Data.Suppliers.SelectMany(y => y.MatchedSuppliers).ToList();
            await dbContext.BulkInsertOrUpdateAsync(suppliers, new BulkConfig
            {
                IncludeGraph = true
            });
        }
    }
}