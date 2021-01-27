using CivicHub.Dtos;
using CivicHub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.IServices
{
    public interface IIssueService
    {
        IssueDto GetById(Guid id);
        List<IssueDto> GetAll();
        bool Create(IssueDto issueDTO);
        bool Update(IssueDto issueDTO);
        Task<List<IssueDto>> GetAllByUserIdAsync(Guid userId);
        List<IssueResponseDto> GetAllWithUsersDetails();
        (bool status, string msg) CheckIssueState(Guid issueId);
    }
}
