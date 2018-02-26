namespace PropertyManagement.Repositories.Concrete
{
    using System.Data.Entity;
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
        public IQueryable<Unit> GetAllUnits()
        {
            return _context.Units;
        }

        /// <summary>
        /// Gets the units by building identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IQueryable<Unit> GetUnitsByBuildingId(int id)
        {
            return _context.Units.Where(i => i.BuildingId == id);
        }

        /// <summary>
        /// Gets the unit by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Unit GetUnitById(int id)
        {
            return _context.Units.Find(id);
        }

        /// <summary>
        /// Adds the unit.
        /// </summary>
        /// <param name="unit">The unit.</param>
        public void AddUnit(Unit unit)
        {
            _context.Units.Add(unit);
            _context.SaveChanges();
        }

        /// <summary>
        /// Updates the unit.
        /// </summary>
        /// <param name="unit">The unit.</param>
        public void UpdateUnit(Unit unit)
        {
            _context.Entry(unit).State = EntityState.Modified;
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
