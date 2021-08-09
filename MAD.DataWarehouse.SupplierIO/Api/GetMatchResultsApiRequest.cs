namespace MAD.DataWarehouse.SupplierIO.Api
{
    public class GetMatchResultsApiRequest : ApiRequest
    {
        public override string RelativeUrl { get; } = "GetMatchResults";

        public string JobId { get; set; }
    }
}