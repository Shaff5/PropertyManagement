using System;
using System.Collections.Generic;

namespace PropertyManagement.Data
{
    public partial class Rent
    {
        public int RentId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public int LastUpdatedBy { get; set; }
        public byte[] Ts { get; set; }
        public bool IsDeleted { get; set; }
        public int UnitId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Amount { get; set; }

        public virtual Unit Unit { get; set; }

        public Domain.Rent MapToDomainRent()
        {
            var r = new Domain.Rent();

            r.RentId = RentId;
            r.CreatedOn = CreatedOn;
            r.CreatedBy = CreatedBy;
            r.LastUpdatedOn = LastUpdatedOn;
            r.LastUpdatedBy = LastUpdatedBy;
            r.Ts = Ts;
            r.IsDeleted = IsDeleted;
            r.UnitId = UnitId;
            r.StartDate = StartDate;
            r.EndDate = EndDate;
            r.Amount = Amount;         

            return r;
        }
    }
}
