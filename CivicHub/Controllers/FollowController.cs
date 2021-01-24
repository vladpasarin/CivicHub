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
    public class FollowController : ControllerBase
    {
        private readonly IFollowService followService;
        public FollowController(IFollowService followService)
        {
            this.followService = followService;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(followService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            Follow issue = followService.GetById(id);
            if (issue == null)
                return NotFound();

            return Ok(issue);
        }

        [HttpPost]
        public IActionResult Create(Follow follow)
        {
            var res = followService.Create(follow);
            return StatusCode(res.Item1, res.Item2);
        }

        [HttpPut]
        public IActionResult Update(Follow follow)
        {
            var res = followService.Update(follow);

            return StatusCode(res.Item1, res.Item2);
        }

        [HttpGet("getAllByUser/{id}")]
        public IActionResult GetAllByUserId(Guid id)
        {
            var res = followService.GetByUserId(id);
            return StatusCode(res.Item1, res.Item2);
        }

        [HttpGet("getAllByIssue/{id}")]
        public IActionResult GetAllByIssueId(Guid id)
        {
            var res = followService.GetByIssueId(id);
            return StatusCode(res.Item1, res.Item2);
        }

        [HttpGet("getAllByIssueAndUser/{issueId}/{userId}")]
        public IActionResult GetAllByIssueAndUserId(Guid issueId, Guid userId)
        {
            var res = followService.GetByIssueAndUserId(userId, issueId);
            return StatusCode(res.Item1, res.Item2);
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var res = followService.Delete(id);
            return StatusCode(res.Item1, res.Item2);
        }
    }
}
