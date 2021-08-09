using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAD.DataWarehouse.SupplierIO.Tests
{
    public class TestServiceProvider
    {
        public static IServiceProvider GetServiceProvider()
        {
            var startup = new Startup();

            var sc = new ServiceCollection();
            startup.ConfigureServices(sc);

            return sc.BuildServiceProvider();
        }
    }
}
