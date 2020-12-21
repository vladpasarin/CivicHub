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
    public class IssueStateReactionRepository : GenericRepository<IssueStateReaction>, IIssueStateReactionRepository
    {
        public IssueStateReactionRepository(Context context) : base(context)
        {

        }

        public async Task<List<IssueStateReaction>> GetAllByIssueStateIdAsync(Guid id)
        {
            return await _context.IssueStateReactions.Where(x => x.IssueStateId == id).ToListAsync();
        }

        public int GetNumberOfDownVotes(Guid id)
        {
            return _context.IssueStateReactions
                .Where(x => x.Vote.ToLower().Equals("downvote") && x.IssueStateId == id)
                .Count();
        }

        public int GetNumberOfUpVotes(Guid id)
        {
            return _context.IssueStateReactions
                .Where(x => x.Vote.ToLower().Equals("upvote") && x.IssueStateId == id)
                .Count();
        }

        public string GetUserReactionToIssueState(IssueStateReaction issueStateReaction) 
        {
            IssueStateReaction result;
            try
            {
                result = _context.IssueStateReactions.Where(x => x.UserId == issueStateReaction.UserId &&
                x.IssueStateId == issueStateReaction.IssueStateId).Single();
            }catch(InvalidOperationException e)
            { 
                return "DidntReact"; 
            }

            return result.Vote;
        }
    }
}
