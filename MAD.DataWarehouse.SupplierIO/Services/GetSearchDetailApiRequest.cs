namespace MAD.DataWarehouse.SupplierIO.Services
{
    public class GetSearchDetailApiRequest : ApiRequest
    {
        public override string RelativeUrl { get; } = "GetSearchDetail";

        public string SearchQuery { get; set; }
        public int StartRecord { get; set; } = 0;
        public int RowCount { get; set; } = 1000;
    }
}