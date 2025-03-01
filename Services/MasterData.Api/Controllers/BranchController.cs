using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MasterData.Application.Commands;
using Microsoft.AspNetCore.Authorization;

namespace MasterData.Api.Controllers;

[Authorize]
public class BranchController(IMediator mediator, ILogger<BranchController> logger) : ApiController
{
    private readonly ILogger<BranchController> _logger = logger;

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> CreateBranch([FromBody] CreateBranchCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }
}