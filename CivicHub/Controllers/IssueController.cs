using CivicHub.Dtos;
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
        public IActionResult GetAll()
        {
            return Ok(_issueService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            IssueDto issue = _issueService.GetById(id);
            //issue == null ? return NotFound() : return Ok(issue);
            if (issue == null)
                return NotFound();

            return Ok(issue);
        }

        [HttpPost]
        public IActionResult Create(IssueDto issueDTO)
        {
            var createdIssue = _issueService.Create(issueDTO);

            if (createdIssue == null)
                return StatusCode(500);

            return Ok(createdIssue);
        }

        [HttpPut]
        public IActionResult Update(IssueDto issueDTO)
        {
            var updatedIssue = _issueService.Update(issueDTO);

            if (updatedIssue == null)
                return StatusCode(500);

            return Ok(updatedIssue);
        }

        [HttpGet("getAllByUser/{id}")]
        public async Task<IActionResult> GetAllByUserIdAsync(Guid id)
        {
            return Ok(await _issueService.GetAllByUserIdAsync(id));
        }

        [HttpGet("getAllWithUserDetails")]
        public IActionResult GetAllWithUserDetails()
        {
            var issues = _issueService.GetAllWithUsersDetails();

            if (issues == null)
                return StatusCode(500);

            return Ok(issues);
        }
    }
}
