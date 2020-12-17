using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CivicHub.Entities;

namespace CivicHub.Interfaces
{
    public interface IIssueStateReactionRepository : IGenericRepository<IssueStateReaction>
    {

        Task<List<IssueStateReaction>> GetAllByIssueStateIdAsync(Guid userId);
        int GetNumberOfDownVotes(Guid id);
        int GetNumberOfUpVotes(Guid id);
    }
}
