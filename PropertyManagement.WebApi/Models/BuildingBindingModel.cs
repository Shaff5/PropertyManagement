using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagement.WebApi.Models
{
    public class BuildingBindingModel
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
    }
}
