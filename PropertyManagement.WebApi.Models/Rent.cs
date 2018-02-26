namespace PropertyManagement.WebApi.Models
{
    using System;
    
    public class Rent
    {
        public int RentId { get; set; }
        public int UnitId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public int LastUpdatedBy { get; set; }
        public byte[] Ts { get; set; }

        public Unit Unit { get; set; }

        public Rent(Data.Rent rent)
        {
            RentId = rent.RentId;
            UnitId = rent.UnitId;
            StartDate = rent.StartDate;
            EndDate = rent.EndDate;
            Amount = rent.Amount;
            CreatedOn = rent.CreatedOn;
            CreatedBy = rent.CreatedBy;
            LastUpdatedOn = rent.LastUpdatedOn;
            LastUpdatedBy = rent.LastUpdatedBy;
            Ts = rent.Ts;
        }
    }
}
