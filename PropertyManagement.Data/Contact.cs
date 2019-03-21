using System;
using System.Collections.Generic;

namespace PropertyManagement.Data
{
    public partial class Contact
    {
        public int ContactId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public int LastUpdatedBy { get; set; }
        public byte[] Ts { get; set; }
        public bool IsDeleted { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Phone1 { get; set; }
        public byte? Phone1Type { get; set; }
        public string Phone2 { get; set; }
        public byte? Phone2Type { get; set; }
        public string Phone3 { get; set; }
        public byte? Phone3Type { get; set; }
        public string Email1 { get; set; }
        public byte? Email1Type { get; set; }
        public string Email2 { get; set; }
        public byte? Email2Type { get; set; }
        public string Email3 { get; set; }
        public byte? Email3Type { get; set; }
    }
}
