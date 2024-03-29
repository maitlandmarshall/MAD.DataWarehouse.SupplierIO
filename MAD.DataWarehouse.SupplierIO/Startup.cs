﻿using Hangfire;
using MAD.DataWarehouse.SupplierIO.Data;
using MAD.DataWarehouse.SupplierIO.Api;
using MAD.Integration.Common.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using MAD.DataWarehouse.SupplierIO.Jobs;

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

            serviceDescriptors
                .AddHttpClient<SupplierApiClient>((svc, cfg) =>
                {
                    var appConfig = svc.GetRequiredService<AppConfig>();

                    if (appConfig.IsSandbox)
                    {
                        cfg.BaseAddress = new Uri("https://api.supplierio.com/supplier/");
                    }
                    else
                    {
                        cfg.BaseAddress = new Uri("https://api.supplier.io/supplier/");
                    }

                })
                .AddHttpMessageHandler<AuthDelegatingHandler>();

            serviceDescriptors.AddDbContext<SupplierIODbContext>(optionsAction: (svc, opt) =>
            {
                var appConfig = svc.GetRequiredService<AppConfig>();
                opt.UseSqlServer(appConfig.ConnectionString);
            });

            serviceDescriptors.AddScoped<GetSuppliersJob>();
        }

        public void Configure(IBackgroundJobClient backgroundJobClient)
        {
            backgroundJobClient.Enqueue<GetSuppliersJob>(y => y.FindSuppliersToLoad(0));
        }
    }
}