using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CivicHub.Entities;

namespace CivicHub.Interfaces
{
    public interface IIssueRepository : IGenericRepository<Issue>
    {
        Issue GetAllDetails(Guid id);
        public List<Issue> GetAllWithDetails();
    }
}
