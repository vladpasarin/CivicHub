using CivicHub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.IServices
{
    interface IPrizeGivenService
    {
        PrizeGiven GetById(Guid id);
        List<PrizeGiven> GetAll();
        bool Create(PrizeGiven issueDTO);
        bool Update(PrizeGiven issueDTO);
    }
}
