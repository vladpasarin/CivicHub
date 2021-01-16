using CivicHub.Data;
using CivicHub.Entities;
using CivicHub.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Repositories
{
    public class PrizeGivenRepository : GenericRepository<PrizeGiven> , IPrizeGivenRepository
    {
        public PrizeGivenRepository(Context context) : base(context)
        {
        }
    }
}
