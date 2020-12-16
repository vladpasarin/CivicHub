using CivicHub.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.IServices
{
    public interface IIssueStateSignatureService
    {
        List<IssueStateSignatureResponseDto> GetAll(Guid IssueStateId);
        IssueStateSignatureResponseDto Create(IssueStateSignatureRequestDto issueDTO);
        int Delete(IssueStateSignatureRequestDto issueDTO);
    }
}
