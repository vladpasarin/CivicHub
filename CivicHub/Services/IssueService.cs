using AutoMapper;
using CivicHub.Dtos;
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
        private readonly IMapper _mapper;

        public IssueService(IIssueRepository issueRepository, IMapper mapper)
        {
            _issueRepository = issueRepository;
            _mapper = mapper;
        }
        public List<IssueDto> GetAll()
        {
            return _mapper.Map<List<IssueDto>>(_issueRepository.GetAllWithDetails());
        }

        public IssueDto GetById(Guid id)
        {
            return _mapper.Map<IssueDto>(_issueRepository.FindById(id));
        }

        public async Task<List<IssueDto>> GetAllByUserIdAsync(Guid userId)
        {
            var userIssues = await _issueRepository.FindByUserIdAsync(userId);
            return _mapper.Map<List<IssueDto>>(userIssues);
        }

        public IssueDto Create(IssueDto issueDTO)
        {
            var issue = _mapper.Map<Issue>(issueDTO);
            _issueRepository.Create(issue);
            _issueRepository.SaveChanges();
            return _mapper.Map<IssueDto>(_issueRepository.GetAllDetails(issue.Id));
        }

        public IssueDto Update(IssueDto issueDTO)
        {
            var issue = _mapper.Map<Issue>(issueDTO);
            _issueRepository.Update(issue);
            _issueRepository.SaveChanges();
            return _mapper.Map<IssueDto>(_issueRepository.GetAllDetails(issue.Id));
        }
    }
}
