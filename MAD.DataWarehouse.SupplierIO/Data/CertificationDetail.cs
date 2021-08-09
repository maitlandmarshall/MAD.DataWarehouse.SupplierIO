using System;

namespace MAD.DataWarehouse.SupplierIO.Data
{
    public class CertificationDetail
    {
        public string Agency { get; set; }
        public string Classification { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}