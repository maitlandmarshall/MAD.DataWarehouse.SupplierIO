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
            ApiResult<Supplier> paginedResult;

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
    }
}