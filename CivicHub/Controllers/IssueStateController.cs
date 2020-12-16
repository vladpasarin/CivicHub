using CivicHub.Dtos;
using CivicHub.IServices;
using CivicHub.Services;
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
    public class IssueStateController : ControllerBase
    {
        private readonly IIssueStateService _issueStateService;
        public IssueStateController(IIssueStateService issueStateService)
        {
            _issueStateService = issueStateService;
        }

        [HttpPost]
        public IActionResult Create(IssueStateDto issueStateDto)
        {
            var createdIssueState = _issueStateService.Create(issueStateDto);
            if (createdIssueState == null)
                return StatusCode(500);

            return Ok(createdIssueState);
        }

        [HttpGet("GetAllByIssueId/{id}")]
        public async Task<IActionResult> GetAllByIssueIdAsync(Guid id)
        {
            return Ok(await _issueStateService.GetAllByIssueIdAsync(id));
        }

        [HttpPut]
        public IActionResult Update(IssueStateDto issueStateDTO)
        {
            var updatedIssueState = _issueStateService.Update(issueStateDTO);

            if (updatedIssueState == null)
                return StatusCode(500);

            return Ok(updatedIssueState);
        }
    }
}
