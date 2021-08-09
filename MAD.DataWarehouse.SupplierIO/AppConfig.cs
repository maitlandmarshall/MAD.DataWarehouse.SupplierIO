using System;
using System.Collections.Generic;
using System.Text;

namespace MAD.DataWarehouse.SupplierIO
{
    public class AppConfig
    {
        public string ConnectionString { get; set; }

        public string ApiKey { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public bool IsSandbox { get; set; } = false;
    }
}
