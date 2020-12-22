using CivicHub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.IServices
{
    public interface IIssueStateCommentLikeService
    {
        List<IssueStateCommentLike> GetAll(Guid issueStateCommentId);
        Tuple<int, object> Create(IssueStateCommentLike issueStateReactionDTO);
        bool UserVoted(Guid userid, Guid issueStateCommentId);
        int Delete(Guid issueStateCommentLikeId);
    }
}
