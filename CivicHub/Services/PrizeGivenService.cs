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
        private readonly IMapper _mapper;

        public PrizeGivenService(IPrizeGivenRepository prizeGivenRepository, IMapper mapper)
        {
            _prizeGivenRepository = prizeGivenRepository;
            _mapper = mapper;
        }
        public PrizeGiven Create(PrizeGiven issueDTO)
        {
            _prizeGivenRepository.Create(issueDTO);
            _prizeGivenRepository.SaveChanges();
            return _prizeGivenRepository.FindById(issueDTO.Id);
        }

        public List<PrizeGiven> GetAll()
        {
            return _prizeGivenRepository.GetAll();
        }

        public PrizeGiven GetById(Guid id)
        {
            return _prizeGivenRepository.FindById(id);
        }

        public PrizeGiven Update(PrizeGiven issueDTO)
        {
            _prizeGivenRepository.Update(issueDTO);
            _prizeGivenRepository.SaveChanges();
            return _prizeGivenRepository.FindById(issueDTO.Id);
        }
    }
}
