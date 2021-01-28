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

        public IssueState GetLatestIssueState(Guid IssueId)
        {
            return _table.
                OrderBy(x => x.DateStart).
                LastOrDefault(x => x.IssueId == IssueId);

            //var issueStates = _table.Where(x => x.IssueId == IssueId).ToList();
            //int index = -1;
            ////(int year, int month, int day, int hour, int minute, int second)
            //DateTime lastestDate = new DateTime(1900,1,1,0,0,0);
            //for(int i =0;i<issueStates.Count();i++)
            //{
            //    if (issueStates[i].DateStart.CompareTo(lastestDate) > 0)
            //    {
            //        lastestDate = issueStates[i].DateStart;
            //        index = i;
            //    }
            //}

            //return issueStates[index];
        }
    }
}
