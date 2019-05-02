using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagement.WebApi.Models
{
    public class UnitBindingModel
    {
        public int UnitId { get; set; }
        public int BuildingId { get; set; }
        public string UnitName { get; set; }
        public decimal SquareFootage { get; set; }
        public decimal NumberOfBedrooms { get; set; }
        public decimal NumberOfBathrooms { get; set; }
    }
}
