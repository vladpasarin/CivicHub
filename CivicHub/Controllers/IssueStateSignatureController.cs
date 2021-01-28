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

        [HttpGet("GetIssuesSignedByUser/{id}")]
        public IActionResult GetIssuesSignedByUser(Guid id)
        {
            var issues = _issueStateSignatureService.GetAllSignedIssuesByUser(id);
            if (issues == null)
            {
                return NotFound();
            }
            if (issues.Count() == 0)
            {
                return StatusCode(200, "Nu s-a gasit nicio petitie semnata");
            }

            return Ok(issues);
        }

        [HttpPost]
        public IActionResult Create(IssueStateSignatureRequestDto issueDTO)
        {
            var createdIssueComment = _issueStateSignatureService.Create(issueDTO);

            if (createdIssueComment == null)
                return Conflict("Userul deja a semnat aceasta petitie");

            return Ok(createdIssueComment);
        }
       

        [HttpDelete("{issueStateSignatureId}")]
        public IActionResult Delete(Guid issueStateSignatureId)
        {
            var result = _issueStateSignatureService.Delete(issueStateSignatureId);
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
