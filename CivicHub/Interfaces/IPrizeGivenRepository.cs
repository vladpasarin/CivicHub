using CivicHub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Interfaces
{
    public interface IPrizeGivenRepository : IGenericRepository<PrizeGiven>
    {
        List<PrizeGiven> getUserPrizes(Guid id);
    }
}
