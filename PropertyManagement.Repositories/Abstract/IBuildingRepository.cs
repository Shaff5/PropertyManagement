namespace PropertyManagement.Repositories.Abstract
{
    using System.Linq;

    public interface IBuildingRepository
    {
        IQueryable<Domain.Building> GetBuildings();
        Domain.Building GetBuilding(int id);
        void AddBuilding(Domain.Building building);
        void UpdateBuilding(Domain.Building building);
        void DeleteBuilding(int id);
    }
}
