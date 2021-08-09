using System;
using System.Collections.Generic;
using System.Text;

namespace MAD.DataWarehouse.SupplierIO.Api
{
    public class PaginatedApiResponse<TResults>
    {
        public PaginatedApiResult<TResults> Results { get; set; }
    }
}
