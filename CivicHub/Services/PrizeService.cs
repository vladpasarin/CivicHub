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
    public class PrizeService : IPrizeService
    {
        private readonly IPrizeRepository _prizeRepository;
        private readonly IMapper _mapper;

        public PrizeService(IPrizeRepository prizeRepository, IMapper mapper)
        {
            _prizeRepository = prizeRepository;
            _mapper = mapper;
        }

        public Prize Create(Prize issueDTO)
        {
            _prizeRepository.Create(issueDTO);
            _prizeRepository.SaveChanges();
            return _prizeRepository.FindById(issueDTO.Id);
        }

        public List<Prize> GetAll()
        {
            return _prizeRepository.GetAll();
        }

        public Prize GetById(Guid id)
        {
            return _prizeRepository.FindById(id);
        }

        public Prize Update(Prize issueDTO)
        {
            _prizeRepository.Update(issueDTO);
            _prizeRepository.SaveChanges();
            return _prizeRepository.FindById(issueDTO.Id);
        }
    }
}
