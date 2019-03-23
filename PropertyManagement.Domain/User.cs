using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyManagement.Domain
{
    public class User
    {
        public int UserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public int LastUpdatedBy { get; set; }
        public byte[] Ts { get; set; }
        public bool IsDeleted { get; set; }
        public string UserName { get; set; }
    }
}
