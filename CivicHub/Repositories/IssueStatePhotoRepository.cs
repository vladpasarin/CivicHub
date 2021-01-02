using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CivicHub.Entities;
using CivicHub.Interfaces;
using CivicHub.Data;

namespace CivicHub.Repositories
{
    public class IssueStatePhotoRepository : GenericRepository<IssueStatePhoto>, IIssueStatePhotoRepository
    {
        public IssueStatePhotoRepository(Context context) : base(context)
        {

        }

        public List<IssueStatePhoto> GetAllWithDetails(Guid issueStateId)
        {
            return _table
                .Where(x => x.IssueStateId == issueStateId)
                .ToList();
        }
    }
}