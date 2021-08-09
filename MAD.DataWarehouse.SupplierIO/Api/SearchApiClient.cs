using MAD.DataWarehouse.SupplierIO.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Web;

namespace MAD.DataWarehouse.SupplierIO.Api
{
    public class SearchApiClient : BaseApiClient
    {
        public SearchApiClient(HttpClient httpClient) : base(httpClient)
        {
            
        }

        public async Task<PaginatedApiResult<Supplier>> GetSearchDetail(GetSearchDetailApiRequest request)
        {
            return await this.GetResult<Supplier>(request, new Dictionary<string, string> {
                { "searchQuery", request.SearchQuery },
                { "startRecord", request.StartRecord.ToString() },
                { "rowCount", request.RowCount.ToString()}
            });
        }

        private async Task<PaginatedApiResult<TResult>> GetResult<TResult>(ApiRequest request, IDictionary<string, string> queryParams)
        {
            var response = await this.GetResponse<PaginatedApiResponse<TResult>>(request, queryParams);
            return response.Results;
        }
    }
}
 