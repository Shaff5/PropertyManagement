using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagement.Ui.Mvc.Models.Building
{
    public class BuildingBindingModel
    {
        public int BuildingId { get; set; }

        [Editable(false)]
        public DateTime CreatedOn { get; set; }

        [Editable(false)]
        public int CreatedBy { get; set; }

        [Editable(false)]
        public DateTime LastUpdatedOn { get; set; }

        [Editable(false)]
        public int LastUpdatedBy { get; set; }

        [Display(Name = "Building Name")]
        public string BuildingName { get; set; }

        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        [Display(Name = "Address Line 3")]
        public string AddressLine3 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        public DateTime PurchaseDate { get; set; }

        [Display(Name = "Purchase Price")]
        public decimal PurchasePrice { get; set; }

        public DateTime? SellDate { get; set; }

        [Display(Name = "Sell Price")]
        public decimal? SellPrice { get; set; }

        [Display(Name = "Number of Units")]
        public decimal NumberOfUnits { get; set; }
    }
}
