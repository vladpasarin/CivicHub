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
    public class IssueStatePhotoService : IIssueStatePhotoService
    {
        private readonly IIssueStatePhotoRepository _issueStatePhotoRepository;
        private readonly IMapper _mapper;

        public IssueStatePhotoService(IIssueStatePhotoRepository issueStatePhotoRepository, IMapper mapper)
        {
            _issueStatePhotoRepository = issueStatePhotoRepository;
            _mapper = mapper;
        }
        public bool Create(IssueStatePhotoDto issueDTO)
        {
            var issue = _mapper.Map<IssueStatePhoto>(issueDTO);
            issue.dateAdded = DateTime.Now;
            _issueStatePhotoRepository.Create(issue);
            return _issueStatePhotoRepository.SaveChanges();
        }

        public int Delete(Guid issueStatePhotoId)
        {
            if (_issueStatePhotoRepository.FindById(issueStatePhotoId) == null)
            {
                return 404;
            }
            else
            {
                var issueDTO = _issueStatePhotoRepository.FindById(issueStatePhotoId);
                _issueStatePhotoRepository.Delete(_mapper.Map<IssueStatePhoto>(issueDTO));
                _issueStatePhotoRepository.SaveChanges();

                if (_issueStatePhotoRepository.FindById(issueDTO.Id) == null)
                {
                    return 200;
                }
                else
                {
                    return 500;
                }
            }
        }

        public List<IssueStatePhotoDto> GetAll(Guid IssueStateId)
        {
            return _mapper.Map<List<IssueStatePhotoDto>>(_issueStatePhotoRepository.GetAllWithDetails(IssueStateId));
        }

        public bool Update(IssueStatePhotoDto issueDTO)
        {
            var issue = _issueStatePhotoRepository.FindById(issueDTO.Id);
            if (issue == null)
            {
                _issueStatePhotoRepository.Create(_mapper.Map<IssueStatePhoto>(issueDTO));
            }
            else
            {
                _mapper.Map(issueDTO, issue);
                _issueStatePhotoRepository.Update(issue);
            }
            return _issueStatePhotoRepository.SaveChanges();
        }
    }
}
