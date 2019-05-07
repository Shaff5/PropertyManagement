using System.Linq;

namespace PropertyManagement.WebApi.Models
{
    public class FastFindBindingModel
    {
        public IQueryable<Domain.Building> Buildings { get; set; }
        public IQueryable<Domain.Unit> Units { get; set; }
        public IQueryable<Domain.Rent> Rents { get; set; }
    }
}
