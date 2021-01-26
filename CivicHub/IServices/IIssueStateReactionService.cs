using CivicHub.Dtos;
using CivicHub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.IServices
{
    public interface IIssueStateReactionService
    {
        List<IssueStateReactionDto> GetAll();
        IssueStateReactionDto GetById(Guid id);
        bool Create(IssueStateReactionDto issueStateReactionDTO);
        bool Update(IssueStateReactionDto issueStateReactionDTO);
        bool Delete(Guid issueStateReactionId);
        Task<List<IssueStateReactionDto>> GetAllByIssueStateIdAsync(Guid id);
        int GetNumberOfDownVotes(Guid id);
        int GetNumberOfUpVotes(Guid id);
        IssueStateReaction GetUserReactionToIssueState(IssueStateReactionDto issueStateReactionDto);
    }
}
