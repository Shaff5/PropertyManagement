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
            UnitsCreatedByNavigation = new HashSet<Unit>();
            UnitsLastUpdatedByNavigation = new HashSet<Unit>();
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
        public virtual ICollection<Unit> UnitsCreatedByNavigation { get; set; }
        public virtual ICollection<Unit> UnitsLastUpdatedByNavigation { get; set; }
        
        public Domain.User MapToDomainUser()
        {
            var u = new Domain.User();

            u.UserId = UserId;
            u.CreatedOn = CreatedOn;
            u.CreatedBy = CreatedBy;
            u.LastUpdatedOn = LastUpdatedOn;
            u.LastUpdatedBy = LastUpdatedBy;
            u.Ts = Ts;
            u.IsDeleted = IsDeleted;
            u.UserName = UserName;
            
            return u;
        }
    }
}
