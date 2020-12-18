using CivicHub.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.IServices
{
    public interface IIssueStateCommentService
    {
        List<IssueStateCommentDto> GetAll(Guid IssueStateId);
        bool Create(IssueStateCommentDto issueDTO);
        bool Update(IssueStateCommentDto issueDTO);
        int Delete(IssueStateCommentDto issueDTO);
    }
}
