namespace PropertyManagement.Repositories.Concrete
{
    using System.Collections.Generic;
    using System.Linq;
    using Abstract;
    using Data;

    public class UnitRepository : IUnitRepository
    {
        private readonly PropertyManagementEntities _context;

        public UnitRepository()
        {
            _context = new PropertyManagementEntities();
        }

        /// <summary>
        /// Gets all units.
        /// </summary>
        /// <returns></returns>
        public IQueryable<WebApi.Models.Unit> GetAllUnits()
        {
            var units = _context.Units;
            var unitsList = new List<WebApi.Models.Unit>();
            foreach (var unit in units)
            {
                unitsList.Add(new WebApi.Models.Unit(unit));
            }

            return unitsList.AsQueryable();
        }

        /// <summary>
        /// Gets the units by building identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IQueryable<WebApi.Models.Unit> GetUnitsByBuildingId(int id)
        {
            var units = _context.Units.Where(i => i.BuildingId == id);
            var unitsList = new List<WebApi.Models.Unit>();
            foreach (var unit in units)
            {
                unitsList.Add(new WebApi.Models.Unit(unit));
            }

            return unitsList.AsQueryable();
        }

        /// <summary>
        /// Gets the unit by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public WebApi.Models.Unit GetUnitById(int id)
        {
            var u = _context.Units.Find(id);
            if (u == null)
            {
                return null;
            }

            return new WebApi.Models.Unit(u);
        }

        /// <summary>
        /// Adds the unit.
        /// </summary>
        /// <param name="unit">The unit.</param>
        public void AddUnit(WebApi.Models.Unit unit)
        {
            var u = new Data.Unit();
            u.UnitName = unit.UnitName;
            u.BuildingId = unit.BuildingId;
            u.SquareFootage = unit.SquareFootage;
            u.NumberOfBedrooms = unit.NumberOfBedrooms;
            u.NumberOfBathrooms = unit.NumberOfBathrooms;
            u.CreatedBy = 4;
            u.CreatedOn = System.DateTime.Now;
            u.LastUpdatedBy = 4;
            u.LastUpdatedOn = System.DateTime.Now;

            _context.Units.Add(u);

            _context.SaveChanges();
        }

        /// <summary>
        /// Updates the unit.
        /// </summary>
        /// <param name="unit">The unit.</param>
        public void UpdateUnit(WebApi.Models.Unit unit)
        {
            var u = _context.Units.Find(unit.UnitId);

            u.UnitId = unit.UnitId;
            u.UnitName = unit.UnitName;
            u.BuildingId = unit.BuildingId;
            u.SquareFootage = unit.SquareFootage;
            u.NumberOfBedrooms = unit.NumberOfBedrooms;
            u.NumberOfBathrooms = unit.NumberOfBathrooms;
            u.LastUpdatedBy = 4;
            u.LastUpdatedOn = System.DateTime.Now;

            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes the unit.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteUnit(int id)
        {
            var unit = _context.Units.Find(id);
            _context.Units.Remove(unit);
            _context.SaveChanges();
        }
    }
}
