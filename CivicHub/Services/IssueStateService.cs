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
        public IssueStateDto Create(IssueStateDto IssueStateDTO)
        {
            var IssueState = _mapper.Map<IssueState>(IssueStateDTO);
            _issueStateRepository.Create(IssueState);
            _issueStateRepository.SaveChanges();
            return IssueStateDTO;
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

        public IssueStateDto Update(IssueStateDto IssueStateDTO)
        {
            _issueStateRepository.Update(_mapper.Map<IssueState>(IssueStateDTO));
            _issueStateRepository.SaveChanges();
            return _mapper.Map<IssueStateDto>(_issueStateRepository.FindById(IssueStateDTO.Id));
        }
    }
}
