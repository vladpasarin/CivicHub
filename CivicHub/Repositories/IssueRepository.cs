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
    public class IssueRepository : GenericRepository<Issue>, IIssueRepository
    {
       
        public IssueRepository(Context context) : base(context)
        {

        }

        public async Task<List<Issue>>FindByUserIdAsync(Guid userId)
        {
           return await _context.Issues.Where(x => x.UserId == userId).ToListAsync();
        }

        public Issue GetAllDetails(Guid id)
        {
            return _table.Where(x => x.Id == id)
                 .Include(x => x.User)
                 .FirstOrDefault();
        }

       
        public List<Issue> GetAllWithDetails()
        {
            return _table
                 .Include(x => x.User)
                 .ToList();
        }
    }
}
