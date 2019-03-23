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
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Created By")]
        public int CreatedBy { get; set; }

        [Display(Name = "Last Updated On")]
        public DateTime LastUpdatedOn { get; set; }

        [Display(Name = "Last Updated By")]
        public int LastUpdatedBy { get; set; }

        [Display (Name = "Building Name")]
        [Required]
        public string BuildingName { get; set; }

        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        [Display(Name = "Address Line 3")]
        public string AddressLine3 { get; set; }

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
        public string ZipCode { get; set; }

        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }

        [Display(Name = "Purchase Price")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "C")]
        public decimal PurchasePrice { get; set; }

        public DateTime? SellDate { get; set; }

        [Display(Name = "Sell Price")]
        public decimal? SellPrice { get; set; }

        [Display(Name = "Number of Units")]
        public decimal NumberOfUnits { get; set; }
    }
}
