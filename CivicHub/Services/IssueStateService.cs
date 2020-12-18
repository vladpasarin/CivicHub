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
    public class IssueStateService : IIssueStateService
    {
        private readonly IIssueStateRepository _issueStateRepository;
        private readonly IMapper _mapper;
        public IssueStateService(IIssueStateRepository issueStateRepository, IMapper mapper)
        {
            _issueStateRepository = issueStateRepository;
            _mapper = mapper;
        }

        public bool Create(IssueStateDto IssueStateDTO)
        {
            var IssueState = _mapper.Map<IssueState>(IssueStateDTO);
            _issueStateRepository.Create(IssueState);
            return _issueStateRepository.SaveChanges();
            
        }

        public List<IssueStateDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<IssueStateDto>> GetAllByIssueIdAsync(Guid IssueId)
        {
            var IssueStates = await _issueStateRepository.GetAllByIssueIdAsync(IssueId);
            return _mapper.Map<List<IssueStateDto>>(IssueStates);
        }

        public bool Update(IssueStateDto IssueStateDTO)
        {
            var issue = _issueStateRepository.FindById(IssueStateDTO.Id);
            if (issue == null)
            {
                _issueStateRepository.Create(_mapper.Map<IssueState>(IssueStateDTO));
            }
            else
            { 
                _mapper.Map(IssueStateDTO, issue);
                _issueStateRepository.Update(issue);
            }
            return _issueStateRepository.SaveChanges();
        }

        public IssueStateDto GetLatestIssueState(Guid IssueId)
        {
            return _mapper.Map<IssueStateDto>(_issueStateRepository.GetLatestIssueState(IssueId));
        }
    }
}
