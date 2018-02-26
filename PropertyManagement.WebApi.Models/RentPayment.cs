namespace PropertyManagement.WebApi.Models
{
    using System;
    
    public class RentPayment
    {
        public int RentPaymentId { get; set; }
        public int UnitId { get; set; }
        public int TenantId { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public int LastUpdatedBy { get; set; }
        public byte[] Ts { get; set; }

        public Unit Unit { get; set; }

        public RentPayment(Data.RentPayment rentPayment)
        {
            RentPaymentId = rentPayment.RentPaymentId;
            UnitId = rentPayment.UnitId;
            TenantId = rentPayment.TenantId;
            Amount = rentPayment.Amount;
            StartDate = rentPayment.StartDate;
            EndDate = rentPayment.EndDate;
            CreatedOn = rentPayment.CreatedOn;
            CreatedBy = rentPayment.CreatedBy;
            LastUpdatedOn = rentPayment.LastUpdatedOn;
            LastUpdatedBy = rentPayment.LastUpdatedBy;
            Ts = rentPayment.Ts;
        }
    }
}
