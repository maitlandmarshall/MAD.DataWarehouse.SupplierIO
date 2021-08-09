using Hangfire;
using MAD.DataWarehouse.SupplierIO.Data;
using MAD.DataWarehouse.SupplierIO.Services;
using MAD.Integration.Common.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace MAD.DataWarehouse.SupplierIO
{
    internal class Startup
    {
        public void ConfigureServices(IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddIntegrationSettings<AppConfig>();

            serviceDescriptors.AddTransient<AuthDelegatingHandler>();
            serviceDescriptors
                .AddHttpClient<SearchApiClient>((svc, cfg) =>
                {
                    var appConfig = svc.GetRequiredService<AppConfig>();
                    
                    if (appConfig.IsSandbox)
                    {
                        cfg.BaseAddress = new Uri("https://explorerdev.supplierio.com/api/");
                    }
                    else
                    {
                        cfg.BaseAddress = new Uri("https://explorer.supplier.io/api/");
                    }

                })
                .AddHttpMessageHandler<AuthDelegatingHandler>();

            serviceDescriptors.AddDbContext<SupplierIODbContext>(optionsAction: (svc, opt) =>
            {
                var appConfig = svc.GetRequiredService<AppConfig>();
                opt.UseSqlServer(appConfig.ConnectionString);
            });
        }

        public async Task Configure(IGlobalConfiguration hangfireConfig)
        {

        }
    }
}