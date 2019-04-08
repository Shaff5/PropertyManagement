using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagement.Ui.Mvc.Models.Unit
{
    public class UnitBindingModel
    {
        public int UnitId { get; set; }

        [Display(Name = "Unit Name")]
        [Required]
        [StringLength(50)]
        public string UnitName { get; set; }

        [Display(Name = "Square Footage")]
        [Required]
        [Range(1, int.MaxValue)]
        public decimal SquareFootage { get; set; }

        [Display(Name = "Number of Bedrooms")]
        [Required]
        [Range(1, int.MaxValue)]
        public decimal NumberOfBedrooms { get; set; }

        [Display(Name = "Number of Bathrooms")]
        [Required]
        [Range(1, int.MaxValue)]
        public decimal NumberOfBathrooms { get; set; }
    }
}
