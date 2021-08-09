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
    public class SupplierApiClient : BaseApiClient
    {
        public SupplierApiClient(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<GetSuppliersApiResponse> GetSuppliers(GetSuppliersApiRequest request)
        {
            var response = await this.GetResponse<ApiResponse<GetSuppliersApiResponse>>(request, bodyParams: new Dictionary<string, object>
            {
                { "supplierIds", request.SupplierIds}
            });

            return response.Data;
        }


        public async Task<ApiResponse<GetMatchResultsApiResponse>> GetMatchResults(GetMatchResultsApiRequest request)
        {
            var response = await this.GetResponse<ApiResponse<GetMatchResultsApiResponse>>(request, new Dictionary<string, string>
            {
                {"jobId", request.JobId }
            });

            return response;
        }
    }
}
 