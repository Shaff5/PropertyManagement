namespace PropertyManagement.Repositories.Concrete
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using PropertyManagement.Data;
    using Abstract;

    public class BuildingRepository : IBuildingRepository
    {
        private readonly PropertyManagementContext _context;

        public BuildingRepository()
        {
            _context = new PropertyManagementContext();
        }

        /// <summary>
        /// Gets all buildings.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Domain.Building> GetBuildings()
        {
            var buildings = _context.Buildings
                .Include(u => u.CreatedByNavigation)
                .Include(u => u.LastUpdatedByNavigation)
                .Where(b => !b.IsDeleted);

            var buildingsList = new List<Domain.Building>();
            foreach (var building in buildings)
            {
                buildingsList.Add(building.MapToDomainBuilding());
            }

            return buildingsList.AsQueryable();
        }

        public IQueryable<Domain.Building> GetDeletedBuildings()
        {
            var buildings = _context.Buildings
                .Include(u => u.CreatedByNavigation)
                .Include(u => u.LastUpdatedByNavigation)
                .Where(b => b.IsDeleted);

            var buildingsList = new List<Domain.Building>();
            foreach (var building in buildings)
            {
                buildingsList.Add(building.MapToDomainBuilding());
            }

            return buildingsList.AsQueryable();
        }

        public IQueryable<Domain.Building> GetBuildings(List<Tuple<string, object>> filters)
        {
            //need to figure out how to do this without risking sql injection
            //var sql = $"SELECT * FROM Buildings {whereClause} AND IsDeleted = 0";
            //var buildings = _context.Buildings
            //    .FromSql(sql)
            //    .Include(u => u.CreatedByNavigation)
            //    .Include(u => u.LastUpdatedByNavigation)
            //    .ToList();



            var rawQuery = new StringBuilder("SELECT * FROM Buildings WHERE ");
            var sqlParameters = new List<object>();

            foreach (var f in filters)
            {
                var parameterName = $"@p{filters.IndexOf(f)}";
                var parameterizedCondition = string.Format(f.Item1, parameterName);
                // f.condition is something like "Name LIKE {0}"

                rawQuery.Append(parameterizedCondition);
                rawQuery.Append(" AND ");
                sqlParameters.Add(new SqlParameter(parameterName, f.Item2));
            }
            rawQuery.Append("IsDeleted = 0");

            var buildings = _context.Buildings
              .FromSql(rawQuery.ToString(), sqlParameters.ToArray())
              .Include(u => u.CreatedByNavigation)
              .Include(u => u.LastUpdatedByNavigation)
              .ToList();








            var buildingsList = new List<Domain.Building>();
            foreach (var building in buildings)
            {
                buildingsList.Add(building.MapToDomainBuilding());
            }

            return buildingsList.AsQueryable();
        }

        /// <summary>
        /// Gets the building by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Domain.Building GetBuilding(int id)
        {
            var building = _context.Buildings
                .Include(u => u.CreatedByNavigation)
                .Include(u => u.LastUpdatedByNavigation)
                .FirstOrDefault(b => b.BuildingId == id);

            if (building == null)
            {
                return null;
            }

            return building.MapToDomainBuilding();
        }

        /// <summary>
        /// Adds the building.
        /// </summary>
        /// <param name="building">The building.</param>
        public void AddBuilding(Domain.Building building)
        {
            var b = new Data.Building();
            b.BuildingName = building.BuildingName;
            b.AddressLine1 = building.AddressLine1;
            b.AddressLine2 = building.AddressLine2;
            b.AddressLine3 = building.AddressLine3;
            b.City = building.City;
            b.State = building.State;
            b.ZipCode = building.ZipCode;
            b.PurchaseDate = building.PurchaseDate;
            b.PurchasePrice = building.PurchasePrice;
            b.SellDate = building.SellDate;
            b.SellPrice = building.SellPrice;
            b.NumberOfUnits = building.NumberOfUnits;
            b.CreatedBy = 1;
            b.CreatedOn = System.DateTime.Now;
            b.LastUpdatedBy = 1;
            b.LastUpdatedOn = System.DateTime.Now;
            b.IsDeleted = building.IsDeleted;

            _context.Buildings.Add(b);

            _context.SaveChanges();
        }

        /// <summary>
        /// Updates the building.
        /// </summary>
        /// <param name="building">The building.</param>
        public void UpdateBuilding(Domain.Building building)
        {
            var b = _context.Buildings.Find(building.BuildingId);

            b.BuildingId = building.BuildingId;
            b.CreatedOn = System.DateTime.Now;
            b.CreatedBy = building.CreatedBy;
            b.LastUpdatedOn = System.DateTime.Now;
            b.LastUpdatedBy = building.LastUpdatedBy;
            b.IsDeleted = building.IsDeleted;
            b.BuildingName = building.BuildingName;
            b.AddressLine1 = building.AddressLine1;
            b.AddressLine2 = building.AddressLine2;
            b.AddressLine3 = building.AddressLine3;
            b.City = building.City;
            b.State = building.State;
            b.ZipCode = building.ZipCode;
            b.PurchaseDate = building.PurchaseDate;
            b.PurchasePrice = building.PurchasePrice;
            b.SellDate = building.SellDate;
            b.SellPrice = building.SellPrice;
            b.NumberOfUnits = building.NumberOfUnits;
            
            _context.SaveChanges();
        }

        public void SoftDeleteBuilding(int id)
        {
            var building = _context.Buildings.Find(id);
            building.IsDeleted = true;
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes the building.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void HardDeleteBuilding(int id)
        {
            var building = _context.Buildings.Find(id);
            _context.Buildings.Remove(building);
            _context.SaveChanges();
        }
    }
}
