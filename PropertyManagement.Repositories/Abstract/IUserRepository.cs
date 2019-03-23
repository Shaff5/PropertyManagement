using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyManagement.Repositories.Abstract
{
    using System.Linq;

    public interface IUserRepository
    {
        IQueryable<Domain.User> GetUsers();
        Domain.User GetUser(int id);
    }
}
