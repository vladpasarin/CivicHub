using AutoMapper;
using CivicHub.Entities;
using CivicHub.Interfaces;
using CivicHub.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Services
{
    public class IssueStateCommentLikeService : IIssueStateCommentLikeService
    {

        private readonly IIssueStateCommentLikeRepository _issueStateCommentLikeRepository;
        private readonly IMapper _mapper;

        public IssueStateCommentLikeService(IIssueStateCommentLikeRepository issueStateCommentRepository, IMapper mapper)
        {
            _issueStateCommentLikeRepository = issueStateCommentRepository;
            _mapper = mapper;
        }

        public Tuple<int, object> Create(IssueStateCommentLike issueStateReactionDTO)
        {
            
            if ( _issueStateCommentLikeRepository.getEntryByUserId(issueStateReactionDTO.IssueStateCommentId, issueStateReactionDTO.UserId) != null)
            {
                return new Tuple<int, object>(409, "Conflict");
            }
            _issueStateCommentLikeRepository.Create(issueStateReactionDTO);
            _issueStateCommentLikeRepository.SaveChanges();
            var createdObject = _issueStateCommentLikeRepository.FindById(issueStateReactionDTO.Id);
            if (createdObject == null)
            {
                return new Tuple<int, object>(500, "A fost executata comanda de creare, dar nu poate fi gasit in BD");
            }
            else
            {
                return new Tuple<int, object>(200, createdObject);
            }
        }

        public int Delete(IssueStateCommentLike issueDTO)
        {
            if (_issueStateCommentLikeRepository.FindById(issueDTO.Id) == null)
            {
                return 404;
            }
            else
            {
                _issueStateCommentLikeRepository.Delete(issueDTO);
                _issueStateCommentLikeRepository.SaveChanges();

                if (_issueStateCommentLikeRepository.FindById(issueDTO.Id) == null)
                {
                    return 200;
                }
                else
                {
                    return 500;
                }
            }


        }

        public List<IssueStateCommentLike> GetAll(Guid issueStateCommentId)
        {
            return _issueStateCommentLikeRepository.GetAllByCommentId(issueStateCommentId);
        }

        public bool UserVoted(Guid userid, Guid issueStateCommentId)
        {
            if ( _issueStateCommentLikeRepository.getEntryByUserId(issueStateCommentId, userid) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        
    }
}
