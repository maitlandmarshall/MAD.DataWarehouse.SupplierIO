using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MAD.DataWarehouse.SupplierIO.Services
{
    public abstract class BaseApiClient
    {
        protected BaseApiClient(HttpClient httpClient)
        {
            this.HttpClient = httpClient;
        }

        protected HttpClient HttpClient { get; }

        protected async Task<TResult> GetResponse<TResult>(ApiRequest request, IDictionary<string, string> queryParams = null, IDictionary<string, object> bodyParams = null)
        {
            var relativeUrl = request.RelativeUrl + $"?{this.BuildQueryUri(queryParams)}";
            var serializer = new JsonSerializer();

            HttpResponseMessage response;

            if (bodyParams != null)
            {
                response = await this.HttpClient.PostAsync(relativeUrl, JsonContent.Create(bodyParams));
            }
            else
            {
                response = await this.HttpClient.GetAsync(relativeUrl);
            }

            using var sr = new StreamReader(await response.Content.ReadAsStreamAsync());
            using var jr = new JsonTextReader(sr);

            var apiResponse = serializer.Deserialize<TResult>(jr);
            return apiResponse;
        }

        private string BuildQueryUri(IDictionary<string, string> queryParams)
        {
            var queryBuilder = HttpUtility.ParseQueryString(string.Empty);

            if (queryParams != null)
            {
                foreach (var kv in queryParams)
                {
                    if (string.IsNullOrEmpty(kv.Value))
                        continue;

                    queryBuilder[kv.Key] = kv.Value;
                }
            }

            return queryBuilder.ToString();
        }
    }
}
