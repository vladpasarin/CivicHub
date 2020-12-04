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
    public class IssueController : ControllerBase
    {
        private readonly IIssueService _issueService;
        public IssueController(IIssueService issueService)
        {
            _issueService = issueService;
        }

        [HttpGet("all")]
        public IActionResult getAll()
        {
            return Ok(_issueService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult get(Guid id)
        {
            Issue issue = _issueService.GetById(id);
            //issue == null ? return NotFound() : return Ok(issue);
            if (issue == null)
                return NotFound();

            return Ok(issue);
        }

        [HttpPost]
        public IActionResult create(Issue issueDTO)
        {
            Issue createdIssue = _issueService.Create(issueDTO);

            if (createdIssue == null)
                return StatusCode(500);

            return Ok(createdIssue);
        }

        [HttpPut]
        public IActionResult update(Issue issueDTO)
        {
            Issue updatedIssue = _issueService.Update(issueDTO);

            if (updatedIssue == null)
                return StatusCode(500);

            return Ok(updatedIssue);
        }
    }
}
