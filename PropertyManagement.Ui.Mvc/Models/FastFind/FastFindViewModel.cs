using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PropertyManagement.Domain;

namespace PropertyManagement.Ui.Mvc.Models.FastFind
{
    public class FastFindViewModel
    {
        public IQueryable<Domain.Building> Buildings { get; set; }
        public IQueryable<Domain.Unit> Units { get; set; }
        public IQueryable<Domain.Rent> Rents { get; set; }
    }
}
