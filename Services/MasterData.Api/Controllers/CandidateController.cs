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
    [AllowAnonymous]
    [HttpPost("[action]")]
    [Consumes("multipart/form-data")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<JobsGoResponse>> ParseCvInformation(IFormFile file)
    {
        var result = await mediator.Send(new ParseCvInformationQuery(){CvFile = file});
        return Ok(result);
    }
}