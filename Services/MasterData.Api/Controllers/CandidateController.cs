using System.Net;
using System.Text.Json;
using MasterData.Application.Dtos;
using MasterData.Application.Queries;
using MasterData.Core.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterData.Api.Controllers;

[Authorize]
public class CandidateController(IMediator mediator, ILogger<BranchController> logger) : ApiController
{
    [HttpPost("[action]")]
    [Consumes("multipart/form-data")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<JobsGoResponse>> ParseCvInformation([FromForm] IFormFile file)
    {
        var result = await mediator.Send(new ParseCvInformationQuery(){CvFile = file});
        return Ok(result);
    }
    
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<Result<IReadOnlyList<CandidateDto>>>> GetCandidatePaging(
        [FromQuery] GetCandidatePagingQuery request)
    {
        var result = await mediator.Send(request);
        return Ok(result);
    }
    
    [HttpPost("[action]")]
    [AllowAnonymous]
    public async Task<ActionResult> VisionApi([FromForm] List<IFormFile> lstFile)
    {
        var result = await mediator.Send(new ImportCertificateQuery(){CvFile = lstFile});
        return Ok(result);
    }
}