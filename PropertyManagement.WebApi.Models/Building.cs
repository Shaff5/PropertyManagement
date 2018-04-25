namespace PropertyManagement.WebApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public class Building
    {
        public int BuildingId { get; set; }
        public string BuildingName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime? SellDate { get; set; }
        public decimal? SellPrice { get; set; }
        public decimal NumberOfUnits { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public int LastUpdatedBy { get; set; }
        public byte[] Ts { get; set; }

        public List<Unit> Units { get; set; }

        public Building()
        {

        }

        public Building(Data.Building building)
        {
            BuildingId = building.BuildingId;
            BuildingName = building.BuildingName;
            AddressLine1 = building.AddressLine1;
            AddressLine2 = building.AddressLine2;
            AddressLine3 = building.AddressLine3;
            City = building.City;
            State = building.State;
            ZipCode = building.ZipCode;
            PurchaseDate = building.PurchaseDate;
            PurchasePrice = building.PurchasePrice;
            SellDate = building.SellDate;
            SellPrice = building.SellPrice;
            NumberOfUnits = building.NumberOfUnits;
            CreatedOn = building.CreatedOn;
            CreatedBy = building.CreatedBy;
            LastUpdatedOn = building.LastUpdatedOn;
            LastUpdatedBy = building.LastUpdatedBy;
            Ts = building.Ts;

            Units = new List<Unit>();
            foreach (var unit in building.Units)
            {
                Units.Add(new Unit(unit));
            }
        }
    }

}
