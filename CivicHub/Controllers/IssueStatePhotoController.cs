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
    public class IssueStatePhotoController : ControllerBase
    {
        private readonly IIssueStatePhotoService _issueStatePhotoService;
        public IssueStatePhotoController(IIssueStatePhotoService issueStateCommentService)
        {
            _issueStatePhotoService = issueStateCommentService;
        }

        [HttpGet("all/{issueStateId}")]
        public IActionResult GetAll(Guid issueStateId)
        {
            var result = _issueStatePhotoService.GetAll(issueStateId);
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
        public IActionResult Create(IssueStatePhotoDto issueDTO)
        {
            var created = _issueStatePhotoService.Create(issueDTO);

            if (!created)
                return StatusCode(500);

            return Ok(created);
        }

        [HttpPut]
        public IActionResult Update(IssueStatePhotoDto issueDTO)
        {
            var updated = _issueStatePhotoService.Update(issueDTO);

            if (!updated)
                return StatusCode(500);

            return Ok(updated);
        }

        [HttpDelete("{issueStatePhotoId}")]
        public IActionResult Delete(Guid issueStatePhotoId)
        {
            var result = _issueStatePhotoService.Delete(issueStatePhotoId);
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
}
