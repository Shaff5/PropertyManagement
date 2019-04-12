using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PropertyManagement.Repositories.Abstract
{
    public interface IRentRepository
    {
        IQueryable<Domain.Rent> GetRents();
        IQueryable<Domain.Rent> GetDeletedRents();
        IQueryable<Domain.Rent> GetRents(List<Tuple<string, object>> filters);
        Domain.Rent GetRent(int id);
        void AddRent(Domain.Rent rent);
        void UpdateRent(Domain.Rent rent);
        void SoftDeleteRent(int id);
        void HardDeleteRent(int id);
    }
}
