using CivicHub.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.IServices
{
    public interface IIssueStateService
    {
        List<IssueStateDto> GetAll();
        bool Create(IssueStateDto IssueStateDTO);
        bool Update(IssueStateDto IssueDTO);
        Task<List<IssueStateDto>> GetAllByIssueIdAsync(Guid IssueId);
        IssueStateDto GetLatestIssueState(Guid IssueId);
        IssueStateDto ConfirmSignatureSubmission(SignaturesSubmittedDto signaturesSubmittedDto);
        IssueStateDto AddGivenResponse(ResponseGivenDto responseGivenDto);
        IssueStateDto AddUngivenResponse(Guid issueId);
        Tuple<int, object> ReopenIssue(Guid issueId);
        IssueStateDto ChangeStateToImplemented(ResponseImplementedDto responseImplementedDto);

    }
}
