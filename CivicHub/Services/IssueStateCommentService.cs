using AutoMapper;
using CivicHub.Dtos;
using CivicHub.Entities;
using CivicHub.Interfaces;
using CivicHub.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Services
{
    public class IssueStateCommentService : IIssueStateCommentService
    {
        private readonly IIssueStateCommentRepository _issueStateCommentRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public IssueStateCommentService(IIssueStateCommentRepository issueStateCommentRepository, IMapper mapper, IUserService userService)
        {
            _issueStateCommentRepository = issueStateCommentRepository;
            _mapper = mapper;
            _userService = userService;
        }

        public bool Create(IssueStateCommentDto issueDTO)
        {
            var issue = _mapper.Map<IssueStateComment>(issueDTO);
            issue.dateCreated = DateTime.Now;
            _issueStateCommentRepository.Create(issue);
            var result =  _issueStateCommentRepository.SaveChanges();
            if (result == true)
            {
                //add points
                _userService.AddPoints(issue.UserId, 1);
            }
            return result;
        }

        public int Delete(Guid issueStateCommentId)
        {
            

            if (_issueStateCommentRepository.FindById(issueStateCommentId) == null)
            {
                return 404;
            }
            else
            {
                var issueDTO = _issueStateCommentRepository.FindById(issueStateCommentId);
                _issueStateCommentRepository.Delete(_mapper.Map<IssueStateComment>(issueDTO));
                _issueStateCommentRepository.SaveChanges();

                if (_issueStateCommentRepository.FindById(issueDTO.Id) == null)
                {
                    return 200;
                }
                else
                {
                    return 500;
                }
            }
        }

        public List<IssueStateCommentDto> GetAll(Guid issueStateId)
        {
            return _mapper.Map<List<IssueStateCommentDto>>(_issueStateCommentRepository.GetAllWithDetails(issueStateId));
        }

        public bool Update(IssueStateCommentDto issueDTO)
        {
            var issue = _issueStateCommentRepository.FindById(issueDTO.Id);
            if (issue == null)
            {
                _issueStateCommentRepository.Create(_mapper.Map<IssueStateComment>(issueDTO));
            }
            else
            {
                _mapper.Map(issueDTO, issue);
                _issueStateCommentRepository.Update(issue);
            }
            return _issueStateCommentRepository.SaveChanges();
        }
    }
}
