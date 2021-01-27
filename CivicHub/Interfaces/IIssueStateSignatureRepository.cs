using CivicHub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Interfaces
{
    public interface IIssueStateSignatureRepository : IGenericRepository<IssueStateSignature>
    {
        List<IssueStateSignature> GetAllWithDetails(Guid issueStateId);
        IssueStateSignature GetByUserIdAndIssueStateId(Guid userId, Guid issueStateId);
        List<IssueStateSignature> GetAllSignedIssuesByUser(Guid userId);

    }
}
