using System;
using System.Collections.Generic;

namespace PropertyManagement.Data
{
    public partial class Vendor
    {
        public int VendorId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public int LastUpdatedBy { get; set; }
        public byte[] Ts { get; set; }
        public bool IsDeleted { get; set; }
        public string VendorName { get; set; }
    }
}
