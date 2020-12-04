using CivicHub.Entities;
using CivicHub.Interfaces;
using CivicHub.IServices;
using CivicHub.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Services
{
    public class IssueService : IIssueService
    {
        private readonly IIssueRepository _issueRepository;
        public IssueService(IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository;
        }
        public List<Issue> GetAll()
        {
            return _issueRepository.GetAllWithDetails();
        }

        public Issue GetById(Guid id)
        {
            return _issueRepository.FindById(id);
        }

        //TO DO de modificat cu dto
        public Issue Create(Issue issueDTO)
        {
            _issueRepository.Create(issueDTO);
            _issueRepository.SaveChanges();
            return _issueRepository.GetAllDetails(issueDTO.Id);
        }

        public Issue Update(Issue issueDTO)
        {
            _issueRepository.Update(issueDTO);
            _issueRepository.SaveChanges();
            return _issueRepository.GetAllDetails(issueDTO.Id);
        }
    }
}
