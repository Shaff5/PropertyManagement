namespace PropertyManagement.Repositories.Abstract
{
    using System.Linq;
    using Data;

    public interface IUnitRepository
    {
        IQueryable<Unit> GetAllUnits();
        IQueryable<Unit> GetUnitsByBuildingId(int id);
        Unit GetUnitById(int id);
        void AddUnit(Unit unit);
        void UpdateUnit(Unit unit);
        void DeleteUnit(int id);
    }
}
