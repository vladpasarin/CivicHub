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
    public class PrizeGivenService : IPrizeGivenService
    {

        private readonly IPrizeGivenRepository _prizeGivenRepository;
        private readonly IPrizeRepository _prizeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public PrizeGivenService(IPrizeGivenRepository prizeGivenRepository, IMapper mapper, IPrizeRepository prizeRepository, IUserRepository userRepository)
        {
            _prizeGivenRepository = prizeGivenRepository;
            _prizeRepository = prizeRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public Tuple<int, object> Create(PrizeGiven issueDTO)
        {
            issueDTO.DateGiven = DateTime.Now;
            issueDTO.EstimatedDelivery = DateTime.Now.AddDays(7);
            issueDTO.DeliveryState = 0;
            Prize prize = _prizeRepository.FindById(issueDTO.PrizeId);
            User user = _userRepository.FindById(issueDTO.UserId);
            int pointsBefore = user.PointsUsed;
            if (user.Points - user.PointsUsed < prize.Price)
            {
                return new Tuple<int, object>(400, "Userul nu are destule puncte ramase pentru a cumpara");
            }
            _prizeGivenRepository.Create(issueDTO);
            _prizeGivenRepository.SaveChanges();
            PrizeGiven prizeCreated = _prizeGivenRepository.FindById(issueDTO.Id);
            if (prizeCreated == null)
            {
                return new Tuple<int, object>(500, "Obiectul PrizeGiven nu a putut fi gasit in bd dupa creare");
            }else
            {
                user.PointsUsed += prize.Price;
                _userRepository.Update(user);
                _userRepository.SaveChanges();
                var user2 = _userRepository.FindById(user.Id);
                if (user2.PointsUsed == pointsBefore)
                {
                    return new Tuple<int, object>(500, "Can't add points used to user");
                }
                return new Tuple<int, object>(200, _prizeGivenRepository.FindById(issueDTO.Id));
            }   
        }

        public List<PrizeGiven> GetAll()
        {
            return _prizeGivenRepository.GetAll();
        }

        public PrizeGiven GetById(Guid id)
        {
            return _prizeGivenRepository.FindById(id);
        }

        public List<PrizeGiven> GetUserPrizes(Guid id)
        {
            return _prizeGivenRepository.getUserPrizes(id);
        }

        public PrizeGiven Update(PrizeGiven issueDTO)
        {
            _prizeGivenRepository.Update(issueDTO);
            _prizeGivenRepository.SaveChanges();
            return _prizeGivenRepository.FindById(issueDTO.Id);
        }
    }
}
