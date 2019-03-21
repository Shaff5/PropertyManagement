using System;
using System.Collections.Generic;

namespace PropertyManagement.Data
{
    public partial class User
    {
        public User()
        {
            BuildingsCreatedByNavigation = new HashSet<Building>();
            BuildingsLastUpdatedByNavigation = new HashSet<Building>();
        }

        public int UserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public int LastUpdatedBy { get; set; }
        public byte[] Ts { get; set; }
        public bool IsDeleted { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<Building> BuildingsCreatedByNavigation { get; set; }
        public virtual ICollection<Building> BuildingsLastUpdatedByNavigation { get; set; }
    }
}
