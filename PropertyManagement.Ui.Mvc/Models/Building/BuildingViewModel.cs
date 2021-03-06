﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PropertyManagement.Ui.Mvc.Models.Building
{
    public class BuildingViewModel
    {
        public int BuildingId { get; set; }

        [Display(Name = "Created On")]
        public DateTime? CreatedOn { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Last Updated On")]
        public DateTime? LastUpdatedOn { get; set; }

        [Display(Name = "Last Updated By")]
        public string LastUpdatedBy { get; set; }

        [Display(Name = "Building Name")]
        [Required]
        [StringLength(75)]
        public string BuildingName { get; set; }

        [Display(Name = "Address Line 1")]
        [Required]
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

        public IEnumerable<SelectListItem> States { get; set; } =
            new List<SelectListItem>
            {
                new SelectListItem{Value = string.Empty, Text = string.Empty},
                new SelectListItem{Value = "CT", Text = "CT"},
                new SelectListItem{Value = "MA", Text = "MA"},
                new SelectListItem{Value = "ME", Text = "ME"},
                new SelectListItem{Value = "NH", Text = "NH"},
                new SelectListItem{Value = "RI", Text = "RI"},
                new SelectListItem{Value = "VT", Text = "VT"}
            };

        [Required]
        public string State { get; set; }

        [Display(Name = "Zip Code")]
        [Required]
        [StringLength(10)]
        public string ZipCode { get; set; }

        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime? PurchaseDate { get; set; }

        [Display(Name = "Purchase Price")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "C")]
        [Required]
        [Range(1, int.MaxValue)]
        public decimal PurchasePrice { get; set; }

        [Display(Name = "Sell Date")]
        [DataType(DataType.Date)]
        public DateTime? SellDate { get; set; }

        [Display(Name = "Sell Price")]
        [Range(0, int.MaxValue)]
        public decimal? SellPrice { get; set; }

        [Display(Name = "Number of Units")]
        [Required]
        [Range(1, int.MaxValue)]
        public decimal NumberOfUnits { get; set; }
    }
}
