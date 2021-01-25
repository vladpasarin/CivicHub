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

        [HttpGet("getAllReactionsByIssueStateId/{id}")]
        public async Task<IActionResult> GetAllByIssueStateIdAsync(Guid id)
        {
            return Ok(await _issueStateReactionService.GetAllByIssueStateIdAsync(id));
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

            var vote = IssueStateReactionDto.Vote.ToLower();
            if (!Equals(vote, "upvote") & !Equals(vote, "downvote"))
                return StatusCode(400, "Bad request, vote field must be either \"Upvote\" or \"Downvote\"");


            var created = _issueStateReactionService.Create(IssueStateReactionDto);

            if (!created)
                return StatusCode(500, "am crapat");

            return Ok(created);
        }

        [HttpPut]
        public IActionResult Update(IssueStateReactionDto IssueStateReactionDto)
        {
            var vote = IssueStateReactionDto.Vote.ToLower();
            if (!Equals(vote, "upvote") & !Equals(vote, "downvote"))
                return StatusCode(400, "Bad request, vote field must be either \"Upvote\" or \"Downvote\"");

            var updated = _issueStateReactionService.Update(IssueStateReactionDto);

            if (!updated)
                return StatusCode(500);

            return Ok(updated);
        }

        [HttpGet("numberOfDownVotes/{id}")]
        public IActionResult GetNumberOfDownVotes(Guid id)
        {
           return Ok(_issueStateReactionService.GetNumberOfDownVotes(id));
        }

        [HttpGet("numberOfUpVotes/{id}")]
        public IActionResult GetNumberOfUpVotes(Guid id)
        {
            return Ok(_issueStateReactionService.GetNumberOfUpVotes(id));
        }

        [HttpGet("getUserReactionToIssueState/{issueStateId}/{userId}")]
        public IActionResult GetUserReactionToIssueState(Guid issueStateId, Guid userId)
        {
            var response = _issueStateReactionService.GetUserReactionToIssueState(new IssueStateReactionDto()
            {
                IssueStateId = issueStateId,
                UserId = userId
            }); 

            if (response == null || response == "")
                return StatusCode(500, "wtf");

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok(_issueStateReactionService.Delete(id));
        }
    }
}
