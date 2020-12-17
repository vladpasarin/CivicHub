using CivicHub.Dtos;
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
    public class IssueStateReactionController : ControllerBase
    {
        IIssueStateReactionService _issueStateReactionService;

        public IssueStateReactionController(IIssueStateReactionService issueStateReactionService)
        {
            _issueStateReactionService = issueStateReactionService;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_issueStateReactionService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            IssueStateReactionDto issueStateReactionDto = _issueStateReactionService.GetById(id);
           
            if (issueStateReactionDto == null)
                return NotFound();

            return Ok(issueStateReactionDto);
        }

        [HttpPost]
        public IActionResult Create(IssueStateReactionDto IssueStateReactionDto)
        {
            var created = _issueStateReactionService.Create(IssueStateReactionDto);

            if (!created)
                return StatusCode(500);

            return Ok(created);
        }

        [HttpPut]
        public IActionResult Update(IssueStateReactionDto IssueStateReactionDto)
        {
            var updated = _issueStateReactionService.Update(IssueStateReactionDto);

            if (!updated)
                return StatusCode(500);

            return Ok(updated);
        }
    }
}
