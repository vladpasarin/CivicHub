using CivicHub.Entities;
using CivicHub.Interfaces;
using CivicHub.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Services
{
    public class FollowService : IFollowService
    {
        private readonly IFollowRepository followRepository;
        private readonly IUserRepository userRepository;
        private readonly IIssueRepository issueRepository;
        public FollowService(IFollowRepository followRepository, IUserRepository userRepository, IIssueRepository issueRepository)
        {
            this.followRepository = followRepository;
            this.userRepository = userRepository;
            this.issueRepository = issueRepository;
        }
        public Tuple<int, object> Create(Follow follow)
        {
            if (followRepository.getByUserAndIssue(follow.UserId, follow.IssueId) != null)
            {
                return new Tuple<int, object>(400, "User already following");
            }
            followRepository.Create(follow);
            followRepository.SaveChanges();
            return new Tuple<int, object>(200, followRepository.FindById(follow.Id));
        }

        public Tuple<int, object> Delete(Guid id)
        {
            if(followRepository.FindById(id) == null)
            {
                return new Tuple<int, object>(400, "Follow with id = " + id.ToString() + " not found");
            }

            followRepository.Delete(followRepository.FindById(id));
            followRepository.SaveChanges();
            return new Tuple<int, object>(200, "Sters cu succes");
        }

        public List<Follow> GetAll()
        {
            return followRepository.GetAll();
        }

        public Follow GetById(Guid id)
        {
            return followRepository.FindById(id);
        }

        public Tuple<int, object> GetByIssueAndUserId(Guid userId, Guid issueId)
        {
            var result = followRepository.getByUserAndIssue(userId, issueId);
            if ( result == null)
            {
                return new Tuple<int, object>(404, "Follow not found");
            }else
            {
                return new Tuple<int, object>(200, result);
            }
        }

        public Tuple<int, object> GetByIssueId(Guid id)
        {
            if(issueRepository.FindById(id) == null )
            {
                return new Tuple<int, object>(404, "There is no issue with id " + id.ToString());
            }
            return new Tuple<int, object>(200, followRepository.getByIssue(id));
        }

        public Tuple<int, object> GetByUserId(Guid id)
        {
            if (userRepository.FindById(id) == null)
            {
                return new Tuple<int, object>(404, "There is no user with id " + id.ToString());
            }
            return new Tuple<int, object>(200, followRepository.getByUser(id));
        }

        public Tuple<int, object> Update(Follow follow)
        {
            if (followRepository.FindById(follow.Id) == null)
            {
                return new Tuple<int, object>(404, "There is no follow with id " + follow.Id.ToString());
            }
            followRepository.Update(follow);
            followRepository.SaveChanges();
            return new Tuple<int, object>(200, followRepository.FindById(follow.Id));
        }
    }
}
