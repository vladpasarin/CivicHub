using CivicHub.Dtos;
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
    }
}
