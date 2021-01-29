using CivicHub.Dtos;
using CivicHub.Entities;
using CivicHub.Helpers;
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
        private readonly IIssueService _issueService;
        public IssueStateController(IIssueStateService issueStateService, IIssueService issueService)
        {
            _issueStateService = issueStateService;
            _issueService = issueService;
        }

        [HttpPost]
        public IActionResult Create(IssueStateDto issueStateDto)
        {
            var createdIssueState = _issueStateService.Create(issueStateDto);
            if (!createdIssueState)
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

            if (!updatedIssueState)
                return StatusCode(500);

            return Ok(updatedIssueState);
        }

        [HttpGet("latestState/{id}")]
        public IActionResult GetLatestIssueState(Guid id)
        {
            var latestIssueState = _issueStateService.GetLatestIssueState(id);

            if (latestIssueState == null)
                return StatusCode(500, "rahat");

            return Ok(latestIssueState);
        }

        // semnaturile au fost submise. se trimit niste poze, asta va contine dto-ul. si metoda va crea un nou state care va avea la fotografii pozele alea
        
        [HttpPost("signaturesSubmitted")]
        //[Authorize]
        public IActionResult signaturesSubmitted(SignaturesSubmittedDto signaturesSubmittedDto)
        {
            var issue = _issueService.GetById(signaturesSubmittedDto.IssueId);
            // get last tate
            // check type is 2
            // check the logged user is the organizer 
            // 
            //if ( ((User)HttpContext.Items["User"]).Id != issue.UserId )
            //{
            //    return StatusCode(400, "Only the organizer can change the status of the issue");
            //}

            var result = _issueStateService.ConfirmSignatureSubmission(signaturesSubmittedDto);
            if (result == null)
            {
                return StatusCode(400, "Last issue state must be waiting for signature submission");
            }
            else
            {
                return Ok(result);
            }

        }

        [HttpPost("responseGiven")]
        //[Authorize]
        public IActionResult responseGiven(ResponseGivenDto responseGivenDto)
        {
            var issue = _issueService.GetById(responseGivenDto.IssueId);
            // get last tate
            // check type is 2
            // check the logged user is the organizer 
            // 
            //if (((User)HttpContext.Items["User"]).Id != issue.UserId)
            //{
            //    return StatusCode(400, "Only the organizer can change the status of the issue");
            //}

            var result = _issueStateService.AddGivenResponse(responseGivenDto);
            if (result == null)
            {
                return StatusCode(400, "Last issue state must be waiting for signature submission");
            }
            else
            {
                return Ok(result);
            }

        }

        [HttpPost("reopenIssue/{issueId}")]
        //[Authorize]
        public IActionResult reopenIssue(Guid issueId)
        {
            var issue = _issueService.GetById(issueId);
            if (((User)HttpContext.Items["User"]).Id != issue.UserId)
            {
                return StatusCode(400, "Only the organizer can change the status of the issue");
            }
            var result = _issueStateService.ReopenIssue(issueId);
            return StatusCode(result.Item1, result.Item2);

        }

        [HttpPost("implemented")]
        //[Authorize]
        public IActionResult implemented(ResponseImplementedDto responseImplementedDto)
        {
            var issue = _issueService.GetById(responseImplementedDto.IssueId);
            // get last tate
            // check type is 2
            // check the logged user is the organizer 
            // 
            //if (((User)HttpContext.Items["User"]).Id != issue.UserId)
            //{
            //    return StatusCode(400, "Only the organizer can change the status of the issue");
            //}

            var result = _issueStateService.ChangeStateToImplemented(responseImplementedDto);
            if (result == null)
            {
                return StatusCode(400, "Last issue state must be waiting for signature submission");
            }
            else
            {
                return Ok(result);
            }

        }

    }
}
