using Microsoft.VisualStudio.TestTools.UnitTesting;
using MAD.DataWarehouse.SupplierIO.Services;
using System;
using System.Collections.Generic;
using System.Text;
using MAD.DataWarehouse.SupplierIO.Tests;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace MAD.DataWarehouse.SupplierIO.Services.Tests
{
    [TestClass()]
    public class SearchApiClientTests
    {
        [TestMethod()]
        public async Task GetSearchDetailTest()
        {
            var searchApiClient = TestServiceProvider.GetServiceProvider().GetRequiredService<SearchApiClient>();
            var suppliers = await searchApiClient.GetSearchDetail(new GetSearchDetailApiRequest());
        }
    }
}