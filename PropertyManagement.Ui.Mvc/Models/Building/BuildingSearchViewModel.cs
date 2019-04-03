using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagement.Ui.Mvc.Models.Building
{
    public class BuildingSearchViewModel
    {
        [Display(Name = "Created On Start")]
        [DataType(DataType.Date)]
        public DateTime? CreatedOnStart { get; set; }

        [Display(Name = "Created On End")]
        [DataType(DataType.Date)]
        public DateTime? CreatedOnEnd { get; set; }

        [Display(Name = "Last Updated On Start")]
        [DataType(DataType.Date)]
        public DateTime? LastUpdatedOnStart { get; set; }

        [Display(Name = "Last Updated On End")]
        [DataType(DataType.Date)]
        public DateTime? LastUpdatedOnEnd { get; set; }

        [Display(Name = "Building Name")]
        [StringLength(75)]
        public string BuildingName { get; set; }

        [Display(Name = "Address Line 1")]
        [StringLength(50)]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(50)]
        public string AddressLine2 { get; set; }

        [Display(Name = "Address Line 3")]
        [StringLength(50)]
        public string AddressLine3 { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [Display(Name = "Zip Code")]
        [StringLength(10)]
        public string ZipCode { get; set; }

        //[Display(Name = "Purchase Date")]
        //[DataType(DataType.Date)]
        //[Required]
        //public DateTime? PurchaseDate { get; set; }

        [Display(Name = "Purchase Price Low")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "C")]
        [Range(1, int.MaxValue)]
        public decimal? PurchasePriceLow { get; set; }

        [Display(Name = "Purchase Price High")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "C")]
        [Range(1, int.MaxValue)]
        public decimal? PurchasePriceHigh { get; set; }

        [Display(Name = "Sell Price")]
        [Range(0, int.MaxValue)]
        public decimal? SellPrice { get; set; }

        [Display(Name = "Number of Units")]
        [Range(1, int.MaxValue)]
        public decimal? NumberOfUnits { get; set; }
    }
}
