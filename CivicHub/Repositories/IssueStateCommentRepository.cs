using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CivicHub.Entities;
using CivicHub.Interfaces;
using CivicHub.Data;
using Microsoft.EntityFrameworkCore;

namespace CivicHub.Repositories
{
    public class IssueStateCommentRepository : GenericRepository<IssueStateComment>, IIssueStateCommentRepository
    {
        public IssueStateCommentRepository(Context context) : base(context)
        {

        }

        public List<IssueStateComment> GetAllWithDetails(Guid issueStateId)
        {
            return _table
                .Where(x => x.IssueStateId == issueStateId)
                .Include(x => x.IssueStateCommentPhotos)
                .ToList();
        }

        public IssueStateComment GetWithDetails(Guid id)
        {
            return _table
                .Where(x => x.Id == id)
                .Include(x => x.User)
                .Include(x => x.IssueState)
                .Include(x => x.IssueStateCommentPhotos)
                .FirstOrDefault();
        }
    }
}
