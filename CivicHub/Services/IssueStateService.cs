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
        private readonly IIssueStateReactionRepository _issueStateReactionRepository;
        private readonly IMapper _mapper;
        public IssueStateService(IIssueStateRepository issueStateRepository, IMapper mapper, IIssueStatePhotoRepository issueStatePhotoRepository, IIssueStateReactionRepository issueStateReactionRepository)
        {
            _issueStateRepository = issueStateRepository;
            _issueStatePhotoRepository = issueStatePhotoRepository;
            _issueStateReactionRepository = issueStateReactionRepository;
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

            if (issueStateDto.Type == 4 && (DateTime.Now - issueStateDto.DateStart).Days > 14)
            {
                Create(new IssueStateDto
                {
                    IssueId = IssueId,
                    DateStart = DateTime.Now,
                    Message = "Problema e inchisa",
                    Type = 4
                });
                return _mapper.Map<IssueStateDto>(_issueStateRepository.GetLatestIssueState(IssueId));
            }

            //check if reponse wasn't given in 30 days
            if (issueStateDto.Type == 2 && (DateTime.Now - issueStateDto.DateStart).Days > 29)
            {
                return AddUngivenResponse(IssueId);              
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

        public IssueStateDto AddGivenResponse(ResponseGivenDto responseGivenDto)
        {
            var issueLastState = GetLatestIssueState(responseGivenDto.IssueId);

            if (issueLastState.Type != 2)
            {
                return null;
            }

            // create issue state nou cu waiting for response
            Create(new IssueStateDto
            {
                IssueId = issueLastState.IssueId,
                DateStart = DateTime.Now,
                Message = "Raspunsul autoritatilor a fost dat",
                CustomMessage = responseGivenDto.MessageFromAuthorities,
                Type = 3
            });
            var lastIssueStateAfter = GetLatestIssueState(responseGivenDto.IssueId);
            //add photos to issue state
            foreach (byte[] photo in responseGivenDto.Photos)
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

        public IssueStateDto AddUngivenResponse(Guid issueId)
        {
            var issueLastState = GetLatestIssueState(issueId);

            if (issueLastState.Type != 2)
            {
                return null;
            }

            // create issue state nou cu waiting for response
            Create(new IssueStateDto
            {
                IssueId = issueLastState.IssueId,
                DateStart = DateTime.Now,
                Message = "Nu a venit niciun raspuns din partea autoritatilor in termen de 30 de zile",
                Type = 6
            });
            var lastIssueStateAfter = GetLatestIssueState(issueId);
            return lastIssueStateAfter;
        }

        public Tuple<int, object> ReopenIssue(Guid issueId)
        {
            var issueLastState = GetLatestIssueState(issueId);
            if (issueLastState == null)
            {
                return new Tuple<int, object>(404, "Nu s-a gasit niciun issue cu id-ul " + issueId);
            }

            if (issueLastState.Type != 3 && issueLastState.Type != 4 && issueLastState.Type != 6)
            {
                return new Tuple<int, object>(400, "Issue isn;t in a state that permits reopening it");
            }

            //daca issue last state este 3 sau 4 si nr de reactii pozitive > negative, nu se face nika
            if ((issueLastState.Type == 3 || issueLastState.Type == 4) && (_issueStateReactionRepository.GetNumberOfUpVotes(issueLastState.Id) > _issueStateReactionRepository.GetNumberOfDownVotes(issueLastState.Id)))
            {
                return new Tuple<int, object>(400, "Numarul de reactii negative trb sa fie mai mare decat pozitive pentru a putea redeschide");
            }

            // create issue state nou cu waiting for response
            Create(new IssueStateDto
            {
                IssueId = issueLastState.IssueId,
                DateStart = DateTime.Now,
                Message = "Strangerea de semnaturi a inceput",
                Type = 0
            });
            var lastIssueStateAfter = GetLatestIssueState(issueId);
            return new Tuple<int, object>(200, lastIssueStateAfter);
        }

        public IssueStateDto ChangeStateToImplemented(ResponseImplementedDto responseImplementedDto)
        {
            var issueLastState = GetLatestIssueState(responseImplementedDto.IssueId);

            if (issueLastState.Type != 3)
            {
                return null;
            }

            // create issue state nou implemented
            Create(new IssueStateDto
            {
                IssueId = issueLastState.IssueId,
                DateStart = DateTime.Now,
                Message = "Solutia a fost implementata",
                CustomMessage = responseImplementedDto.MessageFromAuthorities,
                Type = 4
            });
            var lastIssueStateAfter = GetLatestIssueState(responseImplementedDto.IssueId);
            //add photos to issue state
            foreach (byte[] photo in responseImplementedDto.Photos)
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
