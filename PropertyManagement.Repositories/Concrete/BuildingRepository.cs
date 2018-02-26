namespace PropertyManagement.Repositories.Concrete
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Data;
    using Abstract;

    public class BuildingRepository : IBuildingRepository
    {
        private readonly PropertyManagementEntities _context;

        public BuildingRepository()
        {
            _context = new PropertyManagementEntities();
        }

        /// <summary>
        /// Gets all buildings.
        /// </summary>
        /// <returns></returns>
        public IQueryable<WebApi.Models.Building> GetAllBuildings()
        {
            var buildings = _context.Buildings;
            var buildingsList = new List<WebApi.Models.Building>();
            foreach (var building in buildings)
            {
                buildingsList.Add(new WebApi.Models.Building(building));
            }
            
            return buildingsList.AsQueryable();
        }

        /// <summary>
        /// Gets the building by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public WebApi.Models.Building GetBuildingById(int id)
        {
            var b = _context.Buildings.Find(id);
            if (b == null)
            {
                return null;
            }

            return new WebApi.Models.Building(b);
        }

        /// <summary>
        /// Adds the building.
        /// </summary>
        /// <param name="building">The building.</param>
        public void AddBuilding(WebApi.Models.Building building)
        {
            var b = new Data.Building();
            b.BuildingName = building.BuildingName;
            b.AddressLine1 = building.AddressLine1;
            b.AddressLine2 = building.AddressLine2;
            b.AddressLine3 = building.AddressLine3;
            b.City = building.City;
            b.State = building.State;
            b.ZipCode = building.ZipCode;
            //b.PurchaseDate = new System.DateTime(2010, 1, 1);
            b.PurchaseDate = building.PurchaseDate;
            b.PurchasePrice = 100000;
            b.NumberOfUnits = 6;
            b.CreatedBy = 4;
            b.CreatedOn = System.DateTime.Now;
            b.LastUpdatedBy = 4;
            b.LastUpdatedOn = System.DateTime.Now;

            _context.Buildings.Add(b);

            _context.SaveChanges();
        }

        /// <summary>
        /// Updates the building.
        /// </summary>
        /// <param name="building">The building.</param>
        public void UpdateBuilding(WebApi.Models.Building building)
        {
            var b = _context.Buildings.Find(building.BuildingId);

            b.BuildingId = building.BuildingId;
            b.BuildingName = building.BuildingName;
            b.AddressLine1 = building.AddressLine1;
            b.AddressLine2 = building.AddressLine2;
            b.AddressLine3 = building.AddressLine3;
            b.City = building.City;
            b.State = building.State;
            b.ZipCode = building.ZipCode;
            //b.PurchaseDate = new System.DateTime(2010, 1, 1);
            b.PurchaseDate = building.PurchaseDate;
            b.PurchasePrice = 100000;
            b.NumberOfUnits = 6;
            b.CreatedBy = 4;
            b.CreatedOn = System.DateTime.Now;
            b.LastUpdatedBy = 4;
            b.LastUpdatedOn = System.DateTime.Now;
            //_context.Entry(b).State = EntityState.Modified;
            
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes the building.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteBuilding(int id)
        {
            var building = _context.Buildings.Find(id);
            _context.Buildings.Remove(building);
            _context.SaveChanges();
        }
    }
}
