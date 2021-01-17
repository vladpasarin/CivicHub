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
    public class PrizeController : ControllerBase
    {
        private readonly IPrizeService _prizeService;
        public PrizeController(IPrizeService prizeService)
        {
            _prizeService = prizeService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            Prize prize = _prizeService.GetById(id);
            if (prize == null)
                return NotFound();

            return Ok(prize);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_prizeService.GetAll());
        }

        [HttpPost]
        public IActionResult Create(Prize prize)
        {
            var createdPrize = _prizeService.Create(prize);

            if (createdPrize == null)
                return StatusCode(500);

            return Ok(createdPrize);
        }

        [HttpPut]
        public IActionResult Update(Prize prize)
        {
            var updatedPrize = _prizeService.Update(prize);

            if (updatedPrize == null)
                return StatusCode(500);

            return Ok(updatedPrize);
        }
    }
}
