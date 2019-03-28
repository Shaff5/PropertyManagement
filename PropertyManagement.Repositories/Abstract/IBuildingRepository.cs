namespace PropertyManagement.Repositories.Abstract
{
    using System.Linq;

    public interface IBuildingRepository
    {
        IQueryable<Domain.Building> GetBuildings();
        IQueryable<Domain.Building> GetDeletedBuildings();
        IQueryable<Domain.Building> GetBuildings(string whereClause);
        Domain.Building GetBuilding(int id);
        void AddBuilding(Domain.Building building);
        void UpdateBuilding(Domain.Building building);
        void SoftDeleteBuilding(int id);
        void HardDeleteBuilding(int id);
    }
}
