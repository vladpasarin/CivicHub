using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CivicHub.Entities;

namespace CivicHub.Interfaces
{
    public interface IIssueStateRepository : IGenericRepository<IssueState>
    {
        Task<List<IssueState>> GetAllByIssueIdAsync(Guid IssueId);

        IssueState GetLatestIssueState(Guid IssueId);
    }
}
