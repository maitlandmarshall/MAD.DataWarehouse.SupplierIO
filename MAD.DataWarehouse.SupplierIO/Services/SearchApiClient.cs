using MAD.DataWarehouse.SupplierIO.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MAD.DataWarehouse.SupplierIO.Services
{
    public class SearchApiClient
    {
        private readonly HttpClient httpClient;

        public SearchApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ApiResult<Supplier>> GetSearchDetail(GetSearchDetailApiRequest request)
        {
            return await this.GetResponse<Supplier>(request, new Dictionary<string, string> { { "searchQuery", request.SearchQuery } } );
        }

        private async Task<ApiResult<TResult>> GetResponse<TResult>(ApiRequest request, IDictionary<string, string> queryParams)
        {
            var queryBuilder = HttpUtility.ParseQueryString(string.Empty);

            foreach (var kv in queryParams)
            {
                if (string.IsNullOrEmpty(kv.Value))
                    continue;

                queryBuilder[kv.Key] = kv.Value;
            }

            var relativeUrl = request.RelativeUrl + $"?{queryBuilder.ToString()}";

            var serializer = new JsonSerializer();
            using var response = await this.httpClient.GetAsync(relativeUrl);
            using var sr = new StreamReader(await response.Content.ReadAsStreamAsync());
            using var jr = new JsonTextReader(sr);

            var apiResponse = serializer.Deserialize<ApiResponse<TResult>>(jr);
            return apiResponse.Results;
        }
    }
}
