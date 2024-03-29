﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAD.DataWarehouse.SupplierIO.Api
{
    public class PaginatedApiResult<TResults>
    {
        [JsonProperty("Error")]
        public string Error { get; set; }

        [JsonProperty("SearchQuery")]
        public string SearchQuery { get; set; }

        [JsonProperty("startRecord")]
        public int StartRecord { get; set; }

        [JsonProperty("rowCount")]
        public int RowCount { get; set; }

        [JsonProperty("TotalRecords")]
        public string TotalRecords { get; set; }

        [JsonProperty("Results")]
        public List<TResults> Results { get; set; }
    }
}
