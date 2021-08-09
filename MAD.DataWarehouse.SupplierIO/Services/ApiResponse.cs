using System;
using System.Collections.Generic;
using System.Text;

namespace MAD.DataWarehouse.SupplierIO.Services
{
    public class ApiResponse<TResults>
    {
        public ApiResult<TResults> Results { get; set; }
    }
}
