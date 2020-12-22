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
    public class IssueStateSignatureRepository : GenericRepository<IssueStateSignature>, IIssueStateSignatureRepository
    {
        public IssueStateSignatureRepository(Context context) : base(context)
        {

        }

        public List<IssueStateSignature> GetAllWithDetails(Guid issueStateId)
        {
            return _table
                .Where(x => x.IssueStateId == issueStateId)
                .Include(x => x.User)
                .Include(x => x.IssueState)
                .ToList();
        }

        public IssueStateSignature GetByUserIdAndIssueStateId(Guid userId, Guid issueStateId)
        {
            return _table
                .Where(x => x.UserId == userId)
                .Where(x => x.IssueStateId == issueStateId)
                .FirstOrDefault();
        }
    }
}
