using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAD.DataWarehouse.SupplierIO.Data
{
    public class Supplier
    {
        public string SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        
        [JsonProperty("Actualemployees")]
        public string ActualEmployees { get; set; }
        public string ActualRevenue { get; set; }
        public IEnumerable<string> AlternateSupplierNames { get; set; }

        public IEnumerable<CertificationDetail> CertificationDetail { get; set; }
        public IEnumerable<ContactDetail> ContactDetail { get; set; }

        public string Employee { get; set; }
        public string Established { get; set; }
        public string Ethnicity { get; set; }

        public IEnumerable<string> NAICS { get; set; }
        public IEnumerable<string> NAICSDescription { get; set; }
        public IEnumerable<string> Ownership { get; set; }
        public string Phone { get; set; }
        public string Revenue { get; set; }
        public IEnumerable<string> SIC { get; set; }
        public IEnumerable<string> SmallBusinessClassifications { get; set; }
        public string Website { get; set; }
    }
}
