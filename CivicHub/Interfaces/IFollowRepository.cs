using CivicHub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Interfaces
{
    public interface IFollowRepository : IGenericRepository<Follow>
    {
        List<Follow> getByUser(Guid userId);
        List<Follow> getByIssue(Guid issueId);
        Follow getByUserAndIssue(Guid userId, Guid issueId);
    }
}
