using CivicHub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetByUserAndPassword(string mail, string password);
        List<User> GetAllOrderedByPoints();
    }
}
