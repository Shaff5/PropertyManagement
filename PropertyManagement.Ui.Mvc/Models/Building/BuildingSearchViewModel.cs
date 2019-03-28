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
        public DateTime? CreatedOnStart { get; set; }

        [Display(Name = "Created On End")]
        public DateTime? CreatedOnEnd { get; set; }

        [Display(Name = "Building Name")]
        [StringLength(75)]
        public string BuildingName { get; set; }
    }
}
