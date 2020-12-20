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
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public IssueStateSignatureService(IIssueStateSignatureRepository issueStateCommentRepository, IMapper mapper, IUserRepository userRepository)
        {
            _issueStateSignatureRepository = issueStateCommentRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public IssueStateSignatureResponseDto Create(IssueStateSignatureRequestDto issueDTO)
        {
            var issue = _mapper.Map<IssueStateSignature>(issueDTO);
            _issueStateSignatureRepository.Create(issue);
            _issueStateSignatureRepository.SaveChanges();
            var signature = _issueStateSignatureRepository.FindById(issue.Id);
            var user = _userRepository.FindById(signature.UserId);
            return new IssueStateSignatureResponseDto()
            {
                Id = signature.Id,
                IssueStateId = signature.IssueStateId,
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Mail = user.Mail,
                Name = signature.FirstName,
                DateSigned = signature.DateSigned,
                Cnp = signature.Cnp,
                Adresa = signature.Adresa,
                SerieBuletin = signature.SerieBuletin,
                NumarBuletin = signature.NumarBuletin
            };
        }

        public int Delete(IssueStateSignatureRequestDto issueDTO)
        {
            if (_issueStateSignatureRepository.FindById(issueDTO.Id) == null)
            {
                return 404;
            }
            else
            {
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
                    Name = signature.FirstName,
                    DateSigned = signature.DateSigned,
                    Cnp = signature.Cnp,
                    Adresa = signature.Adresa,
                    SerieBuletin = signature.SerieBuletin,
                    NumarBuletin = signature.NumarBuletin
                });
            }

            return signatureResponses;
        }
    }
}
