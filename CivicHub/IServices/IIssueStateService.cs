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
        IssueStateDto Create(IssueStateDto IssueStateDTO);
        IssueStateDto Update(IssueStateDto IssueDTO);
        Task<List<IssueStateDto>> GetAllByIssueIdAsync(Guid IssueId);
    }
}
