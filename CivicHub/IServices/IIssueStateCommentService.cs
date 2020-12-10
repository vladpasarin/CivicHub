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
        IssueStateCommentDto Create(IssueStateCommentDto issueDTO);
        IssueStateCommentDto Update(IssueStateCommentDto issueDTO);
        int Delete(IssueStateCommentDto issueDTO);
    }
}
