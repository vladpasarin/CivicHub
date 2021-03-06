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
    public class IssueStateSignatureService : IIssueStateSignatureService
    {
        private readonly IIssueStateSignatureRepository _issueStateSignatureRepository;
        private readonly IIssueService _issueService;
        private readonly IIssueStateRepository _issueStateRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public IssueStateSignatureService(IIssueStateSignatureRepository issueStateCommentRepository, IMapper mapper, IUserRepository userRepository, IUserService userService, IIssueService issueService, IIssueStateRepository issueStateRepository)
        { 
            _issueStateSignatureRepository = issueStateCommentRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _userService = userService;
            _issueService = issueService;
            _issueStateRepository = issueStateRepository;
        }

        public IssueStateSignatureResponseDto Create(IssueStateSignatureRequestDto issueDTO)
        {
            var issue = _mapper.Map<IssueStateSignature>(issueDTO);
            if (_issueStateSignatureRepository.GetByUserIdAndIssueStateId(issue.UserId, issue.IssueStateId) != null)
            {
                return null;
            }
            issue.DateSigned = DateTime.Now;
            _issueStateSignatureRepository.Create(issue);
            _issueStateSignatureRepository.SaveChanges();
            var signature = _issueStateSignatureRepository.FindById(issue.Id);
            var user = _userRepository.FindById(signature.UserId);
            //add points
            _userService.AddPoints(user.Id, 4);
            return new IssueStateSignatureResponseDto()
            {
                Id = signature.Id,
                IssueStateId = signature.IssueStateId,
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Mail = user.Mail,
                DateSigned = signature.DateSigned
            };
        }

        public int Delete(Guid issueStateSignatureId)
        {
            if (_issueStateSignatureRepository.FindById(issueStateSignatureId) == null)
            {
                return 404;
            }
            else
            {
                var issueDTO = _issueStateSignatureRepository.FindById(issueStateSignatureId);
                _issueStateSignatureRepository.Delete(_mapper.Map<IssueStateSignature>(issueDTO));
                _issueStateSignatureRepository.SaveChanges();

                if (_issueStateSignatureRepository.FindById(issueDTO.Id) == null)
                {
                    return 200;
                }
                else
                {
                    return 500;
                }
            }
        }

        public List<IssueStateSignatureResponseDto> GetAll(Guid issueStateId)
        {
            List<IssueStateSignatureResponseDto> signatureResponses = new List<IssueStateSignatureResponseDto>();

            List<IssueStateSignature> allSignatures = _issueStateSignatureRepository.GetAllWithDetails(issueStateId);

            foreach (IssueStateSignature signature in allSignatures)
            {
                var user = _userRepository.FindById(signature.UserId);
                signatureResponses.Add(new IssueStateSignatureResponseDto()
                {
                    Id = signature.Id,
                    IssueStateId = signature.IssueStateId,
                    UserId = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Mail = user.Mail,
                    DateSigned = signature.DateSigned
                });
            }

            return signatureResponses;
        }

        public List<IssueDto> GetAllSignedIssuesByUser(Guid userId)
        {
            var signedIssues = _issueStateSignatureRepository.GetAllSignedIssuesByUser(userId);

            List<IssueDto> userIssues = new List<IssueDto>();

            foreach(var signedIssue in signedIssues){

               var issueState = _issueStateRepository.FindById(signedIssue.IssueStateId);
               var issue = _issueService.GetById(issueState.IssueId);
               if(issue != null)
                  userIssues.Add(issue);
            }

            return userIssues;
        }
    }
}
