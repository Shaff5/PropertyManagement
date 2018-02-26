namespace PropertyManagement.Repositories.Abstract
{
    using System.Linq;
    using Data;

    public interface IBuildingRepository
    {
        IQueryable<WebApi.Models.Building> GetAllBuildings();
        WebApi.Models.Building GetBuildingById(int id);
        void AddBuilding(WebApi.Models.Building building);
        void UpdateBuilding(WebApi.Models.Building building);
        void DeleteBuilding(int id);
    }
}
