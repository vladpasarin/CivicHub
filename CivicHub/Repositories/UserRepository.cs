using CivicHub.Data;
using CivicHub.Entities;
using CivicHub.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
        }

        public User GetByUserAndPassword(string mail, string password)
        {
            return _table.Where(x => x.Mail == mail && x.Password == password).FirstOrDefault();
        }
    }
}
