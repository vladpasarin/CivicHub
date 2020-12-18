using CivicHub.Data;
using CivicHub.Entities;
using CivicHub.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Repositories
{
    public class IssueStateCommentLikeRepository : GenericRepository<IssueStateCommentLike>, IIssueStateCommentLikeRepository
    {
        public IssueStateCommentLikeRepository(Context context) : base(context)
        {
            
        }

        public List<IssueStateCommentLike> GetAllByCommentId(Guid issueStateCommentId)
        {
            return _table
                .Where(x => x.IssueStateCommentId == issueStateCommentId)
                .ToList();
        }

        public IssueStateCommentLike getEntryByUserId(Guid issueStateCommentId, Guid userId)
        {
            return _table
                .Where(x => x.IssueStateCommentId == issueStateCommentId)
                .Where(x => x.UserId == userId)
                .FirstOrDefault();
        }
    }
}
