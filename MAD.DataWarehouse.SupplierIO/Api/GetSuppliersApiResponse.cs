﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MAD.DataWarehouse.SupplierIO.Api
{
    public class GetSuppliersApiResponse
    {
        public string JobId { get; set; }
        public int NumberOfInputRecord { get; set; }
        public string Status { get; set; }
    }
}
