using MAD.DataWarehouse.SupplierIO.Data;
using System.Collections;
using System.Collections.Generic;

namespace MAD.DataWarehouse.SupplierIO.Api
{
    public class MatchedSupplier
    {
        public string InputSupplierId { get; set; }
        public IEnumerable<Supplier> MatchedSuppliers { get; set; }
    }
}