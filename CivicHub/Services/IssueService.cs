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
        private readonly IIssueStateRepository _issueStateRepository;
        private readonly IIssueStateSignatureRepository _issueStateSignatureRepository;
        private readonly IIssueStatePhotoService _issueStatePhotoService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public IssueService(IIssueRepository issueRepository, IIssueStateRepository issueStateRepository, IMapper mapper, IUserService userService, IIssueStateSignatureRepository issueStateSignatureRepository, IIssueStatePhotoService issueStatePhotoService)
        {
            _issueRepository = issueRepository;
            _issueStateRepository = issueStateRepository;
            _mapper = mapper;
            _userService = userService;
            _issueStateSignatureRepository = issueStateSignatureRepository;
            _issueStatePhotoService = issueStatePhotoService;
        }

        public List<IssueDto> GetAll()
        {
            var allIssues = _mapper.Map<List<IssueDto>>(_issueRepository.GetAllWithDetails());
            foreach(IssueDto issue in allIssues){

                issue.IssueStates = _mapper.Map<List<IssueStateDto>>(_issueStateRepository.GetAllByIssueIdAsync(issue.Id).Result);
            }
            return allIssues;
        }

        public List<IssueResponseDto> GetAllWithUsersDetails()
        {
            List<IssueResponseDto> issuesWithUserDetails = new List<IssueResponseDto>();
            var allIssues = _issueRepository.GetAllWithDetails();
            foreach(var issue in allIssues)
            {

                issuesWithUserDetails.Add(new IssueResponseDto { 
                    Id = issue.Id,
                    Description = issue.Description,
                    FirstName = issue.User.FirstName,
                    LastName = issue.User.LastName,
                    Title = issue.Title,
                    Latitude = issue.Latitude,
                    Longitude = issue.Longitude,
                    UserId = issue.UserId,
                    Mail = issue.User.Mail,
                    Avatar = issue.User.Avatar,
                    Points = issue.User.Points,
                    IssueStates = _mapper.Map<List<IssueStateDto>>(issue.IssueStates)
                  });
            }

            return issuesWithUserDetails;
        }

        public IssueDto GetById(Guid id)
        {
            var issueDto = _mapper.Map<IssueDto>(_issueRepository.FindById(id));
            if (issueDto == null)
                return null;
            issueDto.IssueStates = _mapper.Map<List<IssueStateDto>>(_issueStateRepository.GetAllByIssueIdAsync(issueDto.Id).Result);
            int numberOfSignatures = 0;
            foreach (IssueStateDto issueState in issueDto.IssueStates)
            {
                if (issueState.Type == 0)
                {
                    numberOfSignatures += _issueStateSignatureRepository.GetAllWithDetails(issueState.Id).Count;
                }
            }
            issueDto.NumberOfSignatures = numberOfSignatures;
            return issueDto;
        }

        public async Task<List<IssueDto>> GetAllByUserIdAsync(Guid userId)
        {
            var userIssuesDtos = _mapper.Map<List<IssueDto>>(await _issueRepository.FindByUserIdAsync(userId));
            if (userIssuesDtos == null || userIssuesDtos.Count() == 0)
                return null;
            foreach(var userIssueDto in userIssuesDtos)
            {
                userIssueDto.IssueStates = _mapper.Map<List<IssueStateDto>>(await _issueStateRepository.GetAllByIssueIdAsync(userIssueDto.Id));
            }

            return userIssuesDtos;
        }

        public bool Create(IssueDto issueDTO)
        {
            var issue = _mapper.Map<Issue>(issueDTO);
            _issueRepository.Create(issue);
            var result =  _issueRepository.SaveChanges();
            var issueStateDto = new IssueState
            {
                IssueId = issue.Id,
                Type = 0,
                Message = "Collecting signatures",
                DateStart = DateTime.Now,
                DateEnd = DateTime.Now.AddMinutes(60)

            };
            _issueStateRepository.Create(issueStateDto);
            _issueStateRepository.SaveChanges();
            if(issueDTO.Photos != null)
            { 
                foreach (string photo in issueDTO.Photos)
                {

                    _issueStatePhotoService.Create(new IssueStatePhotoDto
                    {

                        IssueStateId = issueStateDto.Id,
                        Photo = photo,
                        dateAdded = issueStateDto.DateStart
                    });
                }
            }
            //add points
            _userService.AddPoints(issue.UserId, 25);
            return result;
        }

        public bool Update(IssueDto issueDTO)
        {
            var issue = _issueRepository.FindById(issueDTO.Id);
            if (issue == null)
            {
                _issueRepository.Create(_mapper.Map<Issue>(issueDTO));
            }
            else
            {
                _mapper.Map(issueDTO, issue);
                _issueRepository.Update(issue);
            }
            return _issueRepository.SaveChanges();
        }

        public (bool status,string msg) CheckIssueState(Guid issueId)
        {
            var issueState = _issueStateRepository.GetLatestIssueState(issueId);
            if (issueState == null)
                return(false, "Issue state not found");

            if (issueState.DateEnd != null)
                return (true, $"Issue was closed at {(DateTime)issueState.DateEnd:dd/MMMM/yyyy}");
           
            else
            {
                var timePassed = DateTime.UtcNow - issueState.DateStart;
                if (timePassed.Days > DateTime.DaysInMonth(issueState.DateStart.Year, issueState.DateStart.Month))
                {
                    //issueState.DateEnd = DateTime.UtcNow;
                    return (true, "Petitia este inactiva de " + timePassed.Days.ToString() + " de zile");
                }

                return (true, "Petitia e inca activa");    
            }
        }
    }
}
