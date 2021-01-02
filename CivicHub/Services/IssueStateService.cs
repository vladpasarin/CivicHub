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
        private readonly IIssueStatePhotoRepository _issueStatePhotoRepository;
        private readonly IMapper _mapper;
        public IssueStateService(IIssueStateRepository issueStateRepository, IMapper mapper, IIssueStatePhotoRepository issueStatePhotoRepository)
        {
            _issueStateRepository = issueStateRepository;
            _issueStatePhotoRepository = issueStatePhotoRepository;
            _mapper = mapper;
        }

        public bool Create(IssueStateDto IssueStateDTO)
        {
            var IssueState = _mapper.Map<IssueState>(IssueStateDTO);
            IssueState.DateStart = DateTime.Now;
            // set date end to date start + 21
            if (IssueState.Type == 0)
            {
                IssueState.DateEnd = DateTime.Now.AddMinutes(4);
            }
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
            var issueStateDto =  _mapper.Map<IssueStateDto>(_issueStateRepository.GetLatestIssueState(IssueId));
            //if state is petitioning and date now> date end : change state to waiting for signature submission
            if (issueStateDto.Type == 0 && DateTime.Now > issueStateDto.DateEnd)
            {
                //create new state and get again the latest issue state
                Create(new IssueStateDto
                {
                    IssueId = issueStateDto.IssueId,
                    DateStart = DateTime.Now,
                    Type = 1,
                    Message = "Se asteapta ca organizatorul sa depuna petitia"
                });
                return _mapper.Map<IssueStateDto>(_issueStateRepository.GetLatestIssueState(IssueId));
            }

            return issueStateDto;
        }

        public IssueStateDto ConfirmSignatureSubmission(SignaturesSubmittedDto signaturesSubmittedDto)
        {
            var issueLastState = GetLatestIssueState(signaturesSubmittedDto.IssueId);

            if (issueLastState.Type != 1)
            {
                return null;
            }

            // create issue state nou cu waiting for response
            Create(new IssueStateDto
            {
                IssueId = issueLastState.IssueId,
                DateStart = DateTime.Now,
                Message = "Se asteapta raspunsul din partea autoritatilor",
                Type = 2
            });
            var lastIssueStateAfter = GetLatestIssueState(signaturesSubmittedDto.IssueId);
            //add photos to issue state
            foreach(byte[] photo in signaturesSubmittedDto.Photos)
            {
                _issueStatePhotoRepository.Create(new IssueStatePhoto
                {
                    IssueStateId = lastIssueStateAfter.Id,
                    Photo = photo,
                    dateAdded = DateTime.Now
                });
            }
            return lastIssueStateAfter;
        }
    }
}
