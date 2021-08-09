namespace MAD.DataWarehouse.SupplierIO.Services
{
    public class GetMatchResultsApiRequest : ApiRequest
    {
        public override string RelativeUrl { get; } = "GetMatchResults";

        public string JobId { get; set; }
    }
}