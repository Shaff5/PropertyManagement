using System;
using System.Collections.Generic;

namespace PropertyManagement.Data
{
    public partial class RentPayment
    {
        public int RentPaymentId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public int LastUpdatedBy { get; set; }
        public byte[] Ts { get; set; }
        public bool IsDeleted { get; set; }
        public int UnitId { get; set; }
        public int TenantId { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Unit Unit { get; set; }

        public Domain.RentPayment MapToDomainRentPayment()
        {
            var rp = new Domain.RentPayment();

            rp.RentPaymentId = RentPaymentId;
            rp.CreatedOn = CreatedOn;
            rp.CreatedBy = CreatedBy;
            rp.LastUpdatedOn = LastUpdatedOn;
            rp.LastUpdatedBy = LastUpdatedBy;
            rp.Ts = Ts;
            rp.IsDeleted = IsDeleted;
            rp.UnitId = UnitId;
            rp.TenantId = TenantId;
            rp.Amount = Amount;
            rp.StartDate = StartDate;
            rp.EndDate = EndDate;
            
            return rp;
        }
    }
}
