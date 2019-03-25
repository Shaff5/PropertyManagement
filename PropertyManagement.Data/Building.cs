using System;
using System.Collections.Generic;

namespace PropertyManagement.Data
{
    public partial class Building
    {
        public Building()
        {
            Units = new HashSet<Unit>();
        }

        public int BuildingId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public int LastUpdatedBy { get; set; }
        public byte[] Ts { get; set; }
        public bool IsDeleted { get; set; }
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

        public virtual User CreatedByNavigation { get; set; }
        public virtual User LastUpdatedByNavigation { get; set; }
        public virtual ICollection<Unit> Units { get; set; }

        public Domain.Building MapToDomainBuilding()
        {
            var b = new Domain.Building();

            b.BuildingId = BuildingId;
            b.CreatedOn = CreatedOn;
            b.CreatedBy = CreatedBy;
            b.CreatedByName = CreatedByNavigation.UserName;
            b.LastUpdatedOn = LastUpdatedOn;
            b.LastUpdatedBy = LastUpdatedBy;
            b.LastUpdatedByName = LastUpdatedByNavigation.UserName;
            b.Ts = Ts;
            b.IsDeleted = IsDeleted;
            b.BuildingName = BuildingName;
            b.AddressLine1 = AddressLine1;
            b.AddressLine2 = AddressLine2;
            b.AddressLine3 = AddressLine3;
            b.City = City;
            b.State = State;
            b.ZipCode = ZipCode;
            b.PurchaseDate = PurchaseDate;
            b.PurchasePrice = PurchasePrice;
            b.SellDate = SellDate;
            b.SellPrice = SellPrice;
            b.NumberOfUnits = NumberOfUnits;

            return b;
        }
    }
}
