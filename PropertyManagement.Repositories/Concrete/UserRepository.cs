namespace PropertyManagement.Repositories.Concrete
{
    using System.Collections.Generic;
    using System.Linq;
    using PropertyManagement.Data;
    using Abstract;

    public class UserRepository : IUserRepository
    {
        private readonly PropertyManagementContext _context;

        public UserRepository()
        {
            _context = new PropertyManagementContext();
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Domain.User> GetUsers()
        {
            var users = _context.Users;
            var usersList = new List<Domain.User>();
            foreach (var user in users)
            {
                usersList.Add(user.MapToDomainUser());
            }

            return usersList.AsQueryable();
        }

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Domain.User GetUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return null;
            }

            return user.MapToDomainUser();
        }
    }
}
