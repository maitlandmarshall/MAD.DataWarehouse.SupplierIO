namespace MAD.DataWarehouse.SupplierIO.Services
{
    public class GetSearchDetailApiRequest : ApiRequest
    {
        public override string RelativeUrl { get; } = "GetSearchDetail";

        public string SearchQuery { get; set; }
    }
}