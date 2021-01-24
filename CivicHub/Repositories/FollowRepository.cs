using CivicHub.Data;
using CivicHub.Entities;
using CivicHub.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Repositories
{
    public class FollowRepository : GenericRepository<Follow>, IFollowRepository
    {
        public FollowRepository(Context context) : base(context)
        {

        }

        public List<Follow> getByIssue(Guid issueId)
        {
            return _table.Where(x => x.IssueId == issueId).ToList();
        }

        public List<Follow> getByUser(Guid userId)
        {
            return _table.Where(x => x.UserId == userId).ToList();
        }

        public Follow getByUserAndIssue(Guid userId, Guid issueId)
        {
            return _table.Where(x => x.UserId == userId && x.IssueId == issueId).FirstOrDefault();
        }
    }
}
