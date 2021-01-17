using CivicHub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.IServices
{
    public interface IPrizeGivenService
    {
        PrizeGiven GetById(Guid id);
        List<PrizeGiven> GetAll();
        Tuple<int, object> Create(PrizeGiven issueDTO);
        PrizeGiven Update(PrizeGiven issueDTO);
    }
}
