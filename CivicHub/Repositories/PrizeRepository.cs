using CivicHub.Data;
using CivicHub.Entities;
using CivicHub.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Repositories
{
    public class PrizeRepository : GenericRepository<Prize>, IPrizeRepository
    {
        public PrizeRepository(Context context) : base(context)
        {
        }
    }
}
