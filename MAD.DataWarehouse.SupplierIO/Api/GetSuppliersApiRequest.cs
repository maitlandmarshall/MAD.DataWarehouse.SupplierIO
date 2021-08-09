using System.Collections;
using System.Collections.Generic;

namespace MAD.DataWarehouse.SupplierIO.Api
{
    public class GetSuppliersApiRequest : ApiRequest
    {
        public override string RelativeUrl { get; } = "GetSuppliers";

        public IEnumerable<string> SupplierIds { get; set; }
    }
}