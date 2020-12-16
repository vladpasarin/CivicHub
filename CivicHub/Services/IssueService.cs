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
        private readonly IMapper _mapper;

        public IssueService(IIssueRepository issueRepository, IIssueStateRepository issueStateRepository, IMapper mapper)
        {
            _issueRepository = issueRepository;
            _issueStateRepository = issueStateRepository;
            _mapper = mapper;
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
            issueDto.IssueStates = _mapper.Map<List<IssueStateDto>>(_issueStateRepository.GetAllByIssueIdAsync(issueDto.Id).Result);
            return issueDto;
        }

        public async Task<List<IssueDto>> GetAllByUserIdAsync(Guid userId)
        {
            var userIssuesDtos = _mapper.Map<List<IssueDto>>(await _issueRepository.FindByUserIdAsync(userId));
            foreach(var userIssueDto in userIssuesDtos)
            {
                userIssueDto.IssueStates = _mapper.Map<List<IssueStateDto>>(await _issueStateRepository.GetAllByIssueIdAsync(userIssueDto.Id));
            }

            return userIssuesDtos;
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
