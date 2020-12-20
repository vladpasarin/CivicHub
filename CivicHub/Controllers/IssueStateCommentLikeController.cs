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
    public class IssueStateCommentLikeController : ControllerBase
    {
        private readonly IIssueStateCommentLikeService _issueStateCommentLikeService;
        public IssueStateCommentLikeController(IIssueStateCommentLikeService issueStateCommentService)
        {
            _issueStateCommentLikeService = issueStateCommentService;
        }

        [HttpGet("all/{issueStateCommentId}")]
        public IActionResult GetAll(Guid issueStateCommentId)
        {
            var result = _issueStateCommentLikeService.GetAll(issueStateCommentId);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpGet("numberOfLikes/{issueStateCommentId}")]
        public IActionResult GetNumberOfLikes(Guid issueStateCommentId)
        {
            var result = _issueStateCommentLikeService.GetAll(issueStateCommentId);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result.Count);
            }
        }

        [HttpGet("checkUserLiked/{userId}/{issueStateCommentId}")]
        public IActionResult CheckUserLiked(Guid userId, Guid issueStateCommentId)
        {
            var result = _issueStateCommentLikeService.UserVoted(userId, issueStateCommentId);
            return Ok(result);
        }


        [HttpPost]
        public IActionResult Create(IssueStateCommentLike issueDTO)
        {
            var createdIssueComment = _issueStateCommentLikeService.Create(issueDTO);

            switch (createdIssueComment.Item1)
            {
                case 200:
                    return Ok(createdIssueComment.Item2);
                    
                case 409:
                    return Conflict();
                case 500:
                    return StatusCode(500);
                default:
                    return StatusCode(500);

            }
        }


        [HttpDelete]
        public IActionResult Delete(IssueStateCommentLike issueDTO)
        {
            var result = _issueStateCommentLikeService.Delete(issueDTO);
            switch (result)
            {
                case 200:
                    return Ok();
                case 404:
                    return NotFound("Nu este niciun issue state comment cu id -ul dat");
                case 500:
                    return StatusCode(500, "Issue state comment-ul se afla in bd, dar nu a putut fi sters");
                default:
                    return StatusCode(500, null);
            }
        }
    }
}
