namespace PropertyManagement.Repositories.Abstract
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IUnitRepository
    {
        IQueryable<Domain.Unit> GetUnits();
        IQueryable<Domain.Unit> GetDeletedUnits();
        IQueryable<Domain.Unit> GetUnits(List<Tuple<string, string>> filters);
        Domain.Unit GetUnit(int id);
        void AddUnit(Domain.Unit unit);
        void UpdateUnit(Domain.Unit unit);
        void SoftDeleteUnit(int id);
        void HardDeleteUnit(int id);
    }
}
