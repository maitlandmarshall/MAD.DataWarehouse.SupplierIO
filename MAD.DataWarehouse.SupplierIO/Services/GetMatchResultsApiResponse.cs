using System.Collections;
using System.Collections.Generic;

namespace MAD.DataWarehouse.SupplierIO.Services
{
    public class GetMatchResultsApiResponse
    {
        public string JobId { get; set; }
        public int NumberOfInputRecord { get; set; }
        public string Status { get; set; }

        public IEnumerable<MatchedSupplier> Suppliers { get; set; }
    }
}