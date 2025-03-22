using System.Net;
using MasterData.Application.Dtos;
using MasterData.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterData.Api.Controllers;

[Authorize]
public class CandidateController(IMediator mediator, ILogger<BranchController> logger) : ApiController
{
    [HttpPost("[action]")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<CandidateDto>> ParseCvInformation([FromBody] ParseCvInformationQuery command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }
}