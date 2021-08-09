using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MAD.DataWarehouse.SupplierIO
{
    internal class AuthDelegatingHandler : DelegatingHandler
    {
        private readonly AppConfig appConfig;

        public AuthDelegatingHandler(AppConfig appConfig)
        {
            this.appConfig = appConfig;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var uriBuilder = new UriBuilder(request.RequestUri);
            var queryBuilder = HttpUtility.ParseQueryString(uriBuilder.Query);

            queryBuilder["apiKey"] = this.appConfig.ApiKey;
            queryBuilder["customerId"] = this.appConfig.CustomerId.ToString();
            queryBuilder["customerName"] = this.appConfig.CustomerName;

            uriBuilder.Query = queryBuilder.ToString();
            request.RequestUri = uriBuilder.Uri;

            return base.SendAsync(request, cancellationToken);
        }
    }
}