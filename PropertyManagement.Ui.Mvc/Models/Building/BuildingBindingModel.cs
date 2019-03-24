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

        [Required]
        [StringLength(75)]
        public string BuildingName { get; set; }

        [Required]
        [StringLength(50)]
        public string AddressLine1 { get; set; }

        [StringLength(50)]
        public string AddressLine2 { get; set; }

        [StringLength(50)]
        public string AddressLine3 { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(2)]
        [MinLength(2)]
        public string State { get; set; }

        [Required]
        [StringLength(10)]
        public string ZipCode { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public decimal PurchasePrice { get; set; }

        public DateTime? SellDate { get; set; }

        [Range(0, int.MaxValue)]
        public decimal? SellPrice { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public decimal NumberOfUnits { get; set; }
    }
}
