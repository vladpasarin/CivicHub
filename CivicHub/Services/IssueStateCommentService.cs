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
        private readonly IMapper _mapper;

        public IssueStateCommentService(IIssueStateCommentRepository issueStateCommentRepository, IMapper mapper)
        {
            _issueStateCommentRepository = issueStateCommentRepository;
            _mapper = mapper;
        }

        public IssueStateCommentDto Create(IssueStateCommentDto issueDTO)
        {
            var issue = _mapper.Map<IssueStateComment>(issueDTO);
            _issueStateCommentRepository.Create(issue);
            _issueStateCommentRepository.SaveChanges();
            return _mapper.Map<IssueStateCommentDto>(_issueStateCommentRepository.GetWithDetails(issue.Id));
        }

        public int Delete(IssueStateCommentDto issueDTO)
        {
            if ( _issueStateCommentRepository.FindById(issueDTO.Id) == null)
            {
                return 404;
            }else
            {
                _issueStateCommentRepository.Delete(_mapper.Map<IssueStateComment>(issueDTO));
                _issueStateCommentRepository.SaveChanges();

                if (_issueStateCommentRepository.FindById(issueDTO.Id) == null)
                {
                    return 200;
                }else
                {
                    return 500;
                }
            }
        }

        public List<IssueStateCommentDto> GetAll(Guid issueStateId)
        {
            return _mapper.Map<List<IssueStateCommentDto>>(_issueStateCommentRepository.GetAllWithDetails(issueStateId));
        }

        public IssueStateCommentDto Update(IssueStateCommentDto issueDTO)
        {
            if (_issueStateCommentRepository.FindById(issueDTO.Id) == null)
            {
                return null;
            }
            else
            {
                _issueStateCommentRepository.Update(_mapper.Map<IssueStateComment>(issueDTO));
                _issueStateCommentRepository.SaveChanges();
                return _mapper.Map<IssueStateCommentDto>(_issueStateCommentRepository.GetWithDetails(issueDTO.Id));
            }
        }
    }
}
