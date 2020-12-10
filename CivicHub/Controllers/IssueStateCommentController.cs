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
    public class IssueStateCommentController : ControllerBase
    {
        private readonly IIssueStateCommentService _issueStateCommentService;
        public IssueStateCommentController(IIssueStateCommentService issueStateCommentService)
        {
            _issueStateCommentService = issueStateCommentService;
        }

        [HttpGet("all/{issueStateId}")]
        public IActionResult GetAll(Guid issueStateId)
        {
            var result = _issueStateCommentService.GetAll(issueStateId);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }


        [HttpPost]
        public IActionResult Create(IssueStateCommentDto issueDTO)
        {
            var createdIssueComment = _issueStateCommentService.Create(issueDTO);

            if (createdIssueComment == null)
                return StatusCode(500);

            return Ok(createdIssueComment);
        }

        [HttpPut]
        public IActionResult Update(IssueStateCommentDto issueDTO)
        {
            var updatedIssue = _issueStateCommentService.Update(issueDTO);

            if (updatedIssue == null)
                return StatusCode(500);

            return Ok(updatedIssue);
        }

        [HttpDelete]
        public IActionResult Delete(IssueStateCommentDto issueDTO)
        {
            var result = _issueStateCommentService.Delete(issueDTO);
            switch (result)
            {
                case 200:
                    return Ok();
                    break;
                case 404:
                    return NotFound("Nu este niciun issue state comment cu id -ul dat");
                    break;
                case 500:
                    return StatusCode(500, "Issue state comment-ul se afla in bd, dar nu a putut fi sters");
                    break;
                default:
                    return StatusCode(500, null);
            }
        }
    }
}
