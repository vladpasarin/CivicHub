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
    public class IssueStateSignatureController : ControllerBase
    {

        private readonly IIssueStateSignatureService _issueStateSignatureService;
        public IssueStateSignatureController(IIssueStateSignatureService issueStateCommentService)
        {
            _issueStateSignatureService = issueStateCommentService;
        }

        [HttpGet("all/{issueStateId}")]
        public IActionResult GetAll(Guid issueStateId)
        {
            var result = _issueStateSignatureService.GetAll(issueStateId);
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
        public IActionResult Create(IssueStateSignatureRequestDto issueDTO)
        {
            var createdIssueComment = _issueStateSignatureService.Create(issueDTO);

            if (createdIssueComment == null)
                return StatusCode(500);

            return Ok(createdIssueComment);
        }
       

        [HttpDelete]
        public IActionResult Delete(IssueStateSignatureRequestDto issueDTO)
        {
            var result = _issueStateSignatureService.Delete(issueDTO);
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
}
