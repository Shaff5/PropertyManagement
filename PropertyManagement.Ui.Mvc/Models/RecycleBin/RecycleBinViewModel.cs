using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagement.Ui.Mvc.Models.RecycleBin
{
    public class RecycleBinViewModel
    {
        public int Id { get; set; }
        public string EntityName { get; set; }
        public string Description { get; set; }
        public string DeletedBy { get; set; }
        public DateTime DeletedOn { get; set; }
    }
}
