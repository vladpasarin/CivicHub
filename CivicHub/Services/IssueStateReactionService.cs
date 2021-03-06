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
    public class IssueStateReactionService : IIssueStateReactionService
    {
        private readonly IIssueStateReactionRepository _issueStateReactionRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public IssueStateReactionService(IIssueStateReactionRepository issueStateReactionRepository,IMapper mapper, IUserService userService)
        {
            _issueStateReactionRepository = issueStateReactionRepository;
            _mapper = mapper;
            _userService = userService;
        }

        public IssueStateReactionDto GetById(Guid id)
        {
            return _mapper.Map<IssueStateReactionDto>(_issueStateReactionRepository.FindById(id));
        }

        public bool Create(IssueStateReactionDto issueStateReactionDto)
        {
            var issueStateReaction = _mapper.Map<IssueStateReaction>(issueStateReactionDto);
            issueStateReaction.dateGiven = DateTime.Now;
            var existingReactionFound = _issueStateReactionRepository.GetUserReactionToIssueState(issueStateReaction);
            if (existingReactionFound != null)
            {
                _issueStateReactionRepository.Delete(existingReactionFound);
            }
            else
            {
                _issueStateReactionRepository.Create(issueStateReaction);
            }
            var result =  _issueStateReactionRepository.SaveChanges();
            if (result == true)
            {
                //add points
                _userService.AddPoints(issueStateReaction.UserId, 2);
            }
            return result;
        }

        public List<IssueStateReactionDto> GetAll()
        {
            return _mapper.Map<List<IssueStateReactionDto>>(_issueStateReactionRepository.GetAll());
        }

        public bool Update(IssueStateReactionDto issueStateReactionDto)
        {
            var issueStateReaction = _issueStateReactionRepository.FindById(issueStateReactionDto.Id);
            if (issueStateReaction == null)
            {
                _issueStateReactionRepository.Create(_mapper.Map<IssueStateReaction>(issueStateReactionDto));
            }
            else
            {
                _mapper.Map(issueStateReactionDto, issueStateReaction);
                _issueStateReactionRepository.Update(issueStateReaction);
            }
            return _issueStateReactionRepository.SaveChanges();
        }
        public async Task<List<IssueStateReactionDto>> GetAllByIssueStateIdAsync(Guid id)
        {
            return _mapper.Map<List<IssueStateReactionDto>>(await _issueStateReactionRepository.GetAllByIssueStateIdAsync(id));
        }

        public int GetNumberOfDownVotes(Guid id)
        {
            return _issueStateReactionRepository.GetNumberOfDownVotes(id);
        }
        public int GetNumberOfUpVotes(Guid id)
        {
            return _issueStateReactionRepository.GetNumberOfUpVotes(id);
        }

        public IssueStateReaction GetUserReactionToIssueState(IssueStateReactionDto issueStateReactionDto)
        {
            return _issueStateReactionRepository.GetUserReactionToIssueState(_mapper.Map<IssueStateReaction>(issueStateReactionDto));
        }

        public bool Delete(Guid issueStateReactionId)
        {
            var issueStateReaction = _issueStateReactionRepository.FindById(issueStateReactionId);

            if (issueStateReaction == null)
                return false;

            _issueStateReactionRepository.Delete(issueStateReaction);
            return _issueStateReactionRepository.SaveChanges();
        }
    }
}
