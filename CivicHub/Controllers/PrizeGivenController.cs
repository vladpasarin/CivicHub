using CivicHub.Entities;
using CivicHub.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivicHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrizeGivenController : ControllerBase
    {
        private readonly IPrizeGivenService _prizeGivenService;
        public PrizeGivenController(IPrizeGivenService prizeService)
        {
            _prizeGivenService = prizeService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            PrizeGiven prize = _prizeGivenService.GetById(id);
            if (prize == null)
                return NotFound();

            return Ok(prize);
        }

        [HttpGet("userPrizes/{id}")]
        public IActionResult GetUserPrizes(Guid id)
        {
            List<PrizeGiven> prizes = _prizeGivenService.GetUserPrizes(id);
            return Ok(prizes);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_prizeGivenService.GetAll());
        }

        [HttpPost]
        public IActionResult Create(PrizeGiven prize)
        {
            Tuple<int,object> result = _prizeGivenService.Create(prize);
            return StatusCode(result.Item1, result.Item2);
        }

    }
}
