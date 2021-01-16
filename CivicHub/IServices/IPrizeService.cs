using CivicHub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.IServices
{
    interface IPrizeService
    {
        Prize GetById(Guid id);
        List<Prize> GetAll();
        Prize Create(Prize issueDTO);
        Prize Update(Prize issueDTO);
    }
}
