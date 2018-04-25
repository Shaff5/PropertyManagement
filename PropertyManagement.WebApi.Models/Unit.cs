namespace PropertyManagement.WebApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public class Unit
    {
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public int BuildingId { get; set; }
        public decimal SquareFootage { get; set; }
        public decimal NumberOfBedrooms { get; set; }
        public decimal NumberOfBathrooms { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public int LastUpdatedBy { get; set; }
        public byte[] Ts { get; set; }

        //public Building Building { get; set; }
        //public List<RentPayment> RentPayments { get; set; }
        //public List<Rent> Rents { get; set; }

        public Unit()
        {

        }

        public Unit(Data.Unit unit)
        {
            UnitId = unit.UnitId;
            UnitName = unit.UnitName;
            BuildingId = unit.BuildingId;
            SquareFootage = unit.SquareFootage;
            NumberOfBedrooms = unit.NumberOfBedrooms;
            NumberOfBathrooms = unit.NumberOfBathrooms;
            CreatedOn = unit.CreatedOn;
            CreatedBy = unit.CreatedBy;
            LastUpdatedOn = unit.LastUpdatedOn;
            LastUpdatedBy = unit.LastUpdatedBy;
            Ts = unit.Ts;

            //Building = new Building(unit.Building);

            //RentPayments = new List<RentPayment>();
            //foreach (var rentPayment in unit.RentPayments)
            //{
            //    RentPayments.Add(new RentPayment(rentPayment));
            //}

            //Rents = new List<Rent>();
            //foreach (var rent in unit.Rents)
            //{
            //    Rents.Add(new Rent(rent));
            //}
        }
    }
}
