using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using PropertyManagement.Data;
using PropertyManagement.Repositories.Abstract;

namespace PropertyManagement.Repositories.Concrete
{
    public class RentRepository : IRentRepository
    {
        private readonly PropertyManagementContext _context;

        public RentRepository()
        {
            _context = new PropertyManagementContext();
        }

        /// <summary>
        /// Gets all rents.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Domain.Rent> GetRents()
        {
            var rents = _context.Rents
                .Include(r => r.CreatedByNavigation)
                .Include(r => r.LastUpdatedByNavigation)
                .Include(r => r.Unit)
                .Where(r => !r.IsDeleted);

            var rentsList = new List<Domain.Rent>();
            foreach (var rent in rents)
            {
                rentsList.Add(rent.MapToDomainRent());
            }

            return rentsList.AsQueryable();
        }

        public IQueryable<Domain.Rent> GetDeletedRents()
        {
            var rents = _context.Rents
                .Include(r => r.CreatedByNavigation)
                .Include(r => r.LastUpdatedByNavigation)
                .Include(r => r.Unit)
                .Where(r => r.IsDeleted);

            var rentsList = new List<Domain.Rent>();
            foreach (var rent in rents)
            {
                rentsList.Add(rent.MapToDomainRent());
            }

            return rentsList.AsQueryable();
        }

        public IQueryable<Domain.Rent> GetRents(List<Tuple<string, object>> filters)
        {
            var rawQuery = new StringBuilder(@"SELECT r1.* 
                                                FROM Rents r1 
                                                INNER JOIN Units u1 ON u1.UnitId = r1.UnitId
                                                WHERE ");
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
            rawQuery.Append("r1.IsDeleted = 0");

            var rents = _context.Rents
              .FromSql(rawQuery.ToString(), sqlParameters.ToArray())
              .Include(r => r.CreatedByNavigation)
              .Include(r => r.LastUpdatedByNavigation)
              .Include(r => r.Unit)
              .Include(r => r.Unit.Building)
              .ToList();

            var rentsList = new List<Domain.Rent>();
            foreach (var rent in rents)
            {
                rentsList.Add(rent.MapToDomainRent());
            }

            return rentsList.AsQueryable();
        }

        /// <summary>
        /// Gets the rent by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Domain.Rent GetRent(int id)
        {
            var rent = _context.Rents
                .Include(r => r.CreatedByNavigation)
                .Include(r => r.LastUpdatedByNavigation)
                .Include(r => r.Unit)
                .FirstOrDefault(r => r.RentId == id);

            if (rent == null)
            {
                return null;
            }

            return rent.MapToDomainRent();
        }

        /// <summary>
        /// Adds the rent.
        /// </summary>
        /// <param name="rent">The rent.</param>
        public void AddRent(Domain.Rent rent)
        {
            var r = new Data.Rent();
            r.UnitId = rent.UnitId;
            r.StartDate = rent.StartDate;
            r.EndDate = rent.EndDate;
            r.Amount = rent.Amount;
            r.CreatedBy = 1;
            r.CreatedOn = System.DateTime.Now;
            r.LastUpdatedBy = 1;
            r.LastUpdatedOn = System.DateTime.Now;
            r.IsDeleted = rent.IsDeleted;

            _context.Rents.Add(r);

            _context.SaveChanges();
        }

        /// <summary>
        /// Updates the rent.
        /// </summary>
        /// <param name="rent">The rent.</param>
        public void UpdateRent(Domain.Rent rent)
        {
            var r = _context.Rents.Find(rent.RentId);

            r.UnitId = rent.UnitId;
            r.CreatedOn = System.DateTime.Now;
            r.CreatedBy = rent.CreatedBy;
            r.LastUpdatedOn = System.DateTime.Now;
            r.LastUpdatedBy = rent.LastUpdatedBy;
            r.IsDeleted = rent.IsDeleted;
            r.UnitId = rent.UnitId;
            r.StartDate = rent.StartDate;
            r.EndDate = rent.EndDate;
            r.Amount = rent.Amount;

            _context.SaveChanges();
        }

        public void SoftDeleteRent(int id)
        {
            var rent = _context.Rents.Find(id);
            rent.IsDeleted = true;
            rent.LastUpdatedOn = DateTime.Now;
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes the rent.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void HardDeleteRent(int id)
        {
            var rent = _context.Rents.Find(id);
            _context.Rents.Remove(rent);
            _context.SaveChanges();
        }
    }
}
