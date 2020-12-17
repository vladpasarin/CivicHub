using AutoMapper;
using CivicHub.Dtos;
using CivicHub.Entities;
using CivicHub.IServices;
using CivicHub.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Services
{
    public class IssueStateReactionService : IIssueStateReactionService
    {
        private readonly IssueStateReactionRepository _issueStateReactionRepository;
        private readonly IMapper _mapper;
        public IssueStateReactionService(IssueStateReactionRepository issueStateReactionRepository,IMapper mapper)
        {
            _issueStateReactionRepository = issueStateReactionRepository;
            _mapper = mapper;
        }

        public IssueStateReactionDto GetById(Guid id)
        {
            return _mapper.Map<IssueStateReactionDto>(_issueStateReactionRepository.FindById(id));
        }

        public bool Create(IssueStateReactionDto issueStateReactionDto)
        {
            _issueStateReactionRepository.Create(_mapper.Map<IssueStateReaction>(issueStateReactionDto));
            return _issueStateReactionRepository.SaveChanges();
        }

        public List<IssueStateReactionDto> GetAll()
        {
            return _mapper.Map<List<IssueStateReactionDto>>(_issueStateReactionRepository.GetAll());
        }

        public bool Update(IssueStateReactionDto issueStateReactionDto)
        {
            throw new NotImplementedException();
        }
    }
}
