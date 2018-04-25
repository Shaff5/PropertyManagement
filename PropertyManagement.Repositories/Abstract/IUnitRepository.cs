namespace PropertyManagement.Repositories.Abstract
{
    using System.Linq;
    
    public interface IUnitRepository
    {
        IQueryable<WebApi.Models.Unit> GetAllUnits();
        IQueryable<WebApi.Models.Unit> GetUnitsByBuildingId(int id);
        WebApi.Models.Unit GetUnitById(int id);
        void AddUnit(WebApi.Models.Unit unit);
        void UpdateUnit(WebApi.Models.Unit unit);
        void DeleteUnit(int id);
    }
}
