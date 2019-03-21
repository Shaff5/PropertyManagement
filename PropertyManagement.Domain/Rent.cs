namespace PropertyManagement.Domain
{
    using System;

    public class Rent
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
    }
}
