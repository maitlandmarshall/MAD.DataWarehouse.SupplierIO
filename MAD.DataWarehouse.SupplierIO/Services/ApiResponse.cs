using System;
using System.Collections.Generic;
using System.Text;

namespace MAD.DataWarehouse.SupplierIO.Services
{
    public class ApiResponse <TData>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public TData Data { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
