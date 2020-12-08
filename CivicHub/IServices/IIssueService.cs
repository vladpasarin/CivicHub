using CivicHub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.IServices
{
    public interface IIssueService
    {
        Issue GetById(Guid id);
        List<Issue> GetAll();
        Issue Create(Issue issueDTO);
        Issue Update(Issue issueDTO);
        Task<List<Issue>> GetAllByUserId(Guid userId);
    }
}
