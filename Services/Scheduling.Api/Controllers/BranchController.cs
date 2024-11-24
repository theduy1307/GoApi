using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scheduling.Application.Commands;

namespace Scheduling.Api.Controllers;

public class BranchController(IMediator mediator, ILogger<ScheduleController> logger) : ApiController
{
    private readonly ILogger<ScheduleController> _logger = logger;

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> CreateBranch([FromBody] CreateBranchCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }
}