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
    public class IssueStateRepository : GenericRepository<IssueState>, IIssueStateRepository
    {
        public IssueStateRepository(Context context) : base(context)
        {

        }

        public async Task<List<IssueState>> GetAllByIssueIdAsync(Guid IssueId)
        {
            return await _table.Where(x => x.IssueId == IssueId).ToListAsync();
        }
    }
}
