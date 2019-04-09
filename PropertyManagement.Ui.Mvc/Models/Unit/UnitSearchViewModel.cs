using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagement.Ui.Mvc.Models.Unit
{
    public class UnitSearchViewModel
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

        [Display(Name = "Unit Name")]
        [StringLength(50)]
        public string UnitName { get; set; }

        [Display(Name = "Square Footage Low")]
        [Range(1, int.MaxValue)]
        public decimal? SquareFootageLow { get; set; }

        [Display(Name = "Square Footage High")]
        [Range(1, int.MaxValue)]
        public decimal? SquareFootageHigh { get; set; }
    }
}
