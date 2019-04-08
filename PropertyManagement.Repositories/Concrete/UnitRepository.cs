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

    public class UnitRepository : IUnitRepository
    {
        private readonly PropertyManagementContext _context;

        public UnitRepository()
        {
            _context = new PropertyManagementContext();
        }

        /// <summary>
        /// Gets all units.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Domain.Unit> GetUnits()
        {
            var units = _context.Units
                .Include(u => u.CreatedByNavigation)
                .Include(u => u.LastUpdatedByNavigation)
                .Include(u => u.Building)
                .Where(u => !u.IsDeleted);

            var unitsList = new List<Domain.Unit>();
            foreach (var unit in units)
            {
                unitsList.Add(unit.MapToDomainUnit());
            }

            return unitsList.AsQueryable();
        }

        public IQueryable<Domain.Unit> GetDeletedUnits()
        {
            var units = _context.Units
                .Include(u => u.CreatedByNavigation)
                .Include(u => u.LastUpdatedByNavigation)
                .Include(u => u.Building)
                .Where(u => u.IsDeleted);

            var unitsList = new List<Domain.Unit>();
            foreach (var unit in units)
            {
                unitsList.Add(unit.MapToDomainUnit());
            }

            return unitsList.AsQueryable();
        }

        public IQueryable<Domain.Unit> GetUnits(List<Tuple<string, object>> filters)
        {
            var rawQuery = new StringBuilder("SELECT * FROM Units WHERE ");
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

            var units = _context.Units
              .FromSql(rawQuery.ToString(), sqlParameters.ToArray())
              .Include(u => u.CreatedByNavigation)
              .Include(u => u.LastUpdatedByNavigation)
              .Include(u => u.Building)
              .ToList();

            var unitsList = new List<Domain.Unit>();
            foreach (var unit in units)
            {
                unitsList.Add(unit.MapToDomainUnit());
            }

            return unitsList.AsQueryable();
        }

        /// <summary>
        /// Gets the unit by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Domain.Unit GetUnit(int id)
        {
            var unit = _context.Units
                .Include(u => u.CreatedByNavigation)
                .Include(u => u.LastUpdatedByNavigation)
                .Include(u => u.Building)
                .FirstOrDefault(u => u.UnitId == id);

            if (unit == null)
            {
                return null;
            }

            return unit.MapToDomainUnit();
        }

        /// <summary>
        /// Adds the unit.
        /// </summary>
        /// <param name="unit">The unit.</param>
        public void AddUnit(Domain.Unit unit)
        {
            var u = new Data.Unit();
            u.UnitName = unit.UnitName;
            u.BuildingId = unit.BuildingId;
            u.SquareFootage = unit.SquareFootage;
            u.NumberOfBedrooms = unit.NumberOfBedrooms;
            u.NumberOfBathrooms = unit.NumberOfBathrooms;
            u.CreatedBy = 1;
            u.CreatedOn = System.DateTime.Now;
            u.LastUpdatedBy = 1;
            u.LastUpdatedOn = System.DateTime.Now;
            u.IsDeleted = unit.IsDeleted;

            _context.Units.Add(u);

            _context.SaveChanges();
        }

        /// <summary>
        /// Updates the unit.
        /// </summary>
        /// <param name="unit">The unit.</param>
        public void UpdateUnit(Domain.Unit unit)
        {
            var u = _context.Units.Find(unit.UnitId);

            u.UnitId = unit.UnitId;
            u.CreatedOn = System.DateTime.Now;
            u.CreatedBy = unit.CreatedBy;
            u.LastUpdatedOn = System.DateTime.Now;
            u.LastUpdatedBy = unit.LastUpdatedBy;
            u.IsDeleted = unit.IsDeleted;
            u.UnitName = unit.UnitName;
            u.BuildingId = unit.BuildingId;
            u.SquareFootage = unit.SquareFootage;
            u.NumberOfBedrooms = unit.NumberOfBedrooms;
            u.NumberOfBathrooms = unit.NumberOfBathrooms;

            _context.SaveChanges();
        }

        public void SoftDeleteUnit(int id)
        {
            var unit = _context.Units.Find(id);
            unit.IsDeleted = true;
            unit.LastUpdatedOn = DateTime.Now;
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes the unit.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void HardDeleteUnit(int id)
        {
            var unit = _context.Units.Find(id);
            _context.Units.Remove(unit);
            _context.SaveChanges();
        }
    }
}
