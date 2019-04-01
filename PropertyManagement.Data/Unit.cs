using System;
using System.Collections.Generic;

namespace PropertyManagement.Data
{
    public partial class Unit
    {
        public Unit()
        {
            RentPayments = new HashSet<RentPayment>();
            Rents = new HashSet<Rent>();
        }

        public int UnitId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public int LastUpdatedBy { get; set; }
        public byte[] Ts { get; set; }
        public bool IsDeleted { get; set; }
        public string UnitName { get; set; }
        public int BuildingId { get; set; }
        public decimal SquareFootage { get; set; }
        public decimal NumberOfBedrooms { get; set; }
        public decimal NumberOfBathrooms { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual User LastUpdatedByNavigation { get; set; }
        public virtual Building Building { get; set; }
        public virtual ICollection<RentPayment> RentPayments { get; set; }
        public virtual ICollection<Rent> Rents { get; set; }

        public Domain.Unit MapToDomainUnit()
        {
            var u = new Domain.Unit();

            u.UnitId = UnitId;
            u.CreatedOn = CreatedOn;
            u.CreatedBy = CreatedBy;
            u.LastUpdatedOn = LastUpdatedOn;
            u.LastUpdatedBy = LastUpdatedBy;
            u.Ts = Ts;
            u.IsDeleted = IsDeleted;
            u.UnitName = UnitName;
            u.BuildingId = BuildingId;
            u.SquareFootage = SquareFootage;
            u.NumberOfBedrooms = NumberOfBedrooms;
            u.NumberOfBathrooms = NumberOfBathrooms;
            
            return u;
        }
    }
}
