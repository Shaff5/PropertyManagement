using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PropertyManagement.Ui.Mvc.Models.Unit
{
    public class UnitViewModel
    {
        public int UnitId { get; set; }

        [Display(Name = "Created On")]
        public DateTime? CreatedOn { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Last Updated On")]
        public DateTime? LastUpdatedOn { get; set; }

        [Display(Name = "Last Updated By")]
        public string LastUpdatedBy { get; set; }

        [Display(Name = "Unit Name")]
        [Required]
        [StringLength(50)]
        public string UnitName { get; set; }

        [Display(Name = "Building Id")]
        public int BuildingId { get; set; }

        [Display(Name = "Building Name")]
        public string BuildingName { get; set; }

        [Display(Name = "Square Footage")]
        public decimal SquareFootage { get; set; }

        [Display(Name = "Number of Bedrooms")]
        public decimal NumberOfBedrooms { get; set; }

        [Display(Name = "Number of Bathrooms")]
        public decimal NumberOfBathrooms { get; set; }
    }
}
