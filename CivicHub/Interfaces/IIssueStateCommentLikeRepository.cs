using CivicHub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Interfaces
{
    public interface IIssueStateCommentLikeRepository : IGenericRepository<IssueStateCommentLike>
    {
        List<IssueStateCommentLike> GetAllByCommentId(Guid issueStateCommentId);
        IssueStateCommentLike getEntryByUserId(Guid issueStateCommentId, Guid userId);
    }
}
