namespace PropertyManagement.Domain
{
    using System;
    using System.Collections.Generic;

    public class Unit
    {
        public int UnitId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public int LastUpdatedBy { get; set; }
        public string LastUpdatedByName { get; set; }
        public byte[] Ts { get; set; }
        public bool IsDeleted { get; set; }
        public string BuildingName { get; set; }
        public string UnitName { get; set; }
        public int BuildingId { get; set; }
        public decimal SquareFootage { get; set; }
        public decimal NumberOfBedrooms { get; set; }
        public decimal NumberOfBathrooms { get; set; }
        
        public Unit()
        {

        }
    }
}
