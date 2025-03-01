using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MasterData.Application.Commands;
using Microsoft.AspNetCore.Authorization;

namespace MasterData.Api.Controllers;

[Authorize]
public class ScheduleController(IMediator mediator, ILogger<ScheduleController> logger) : ApiController
{
    private readonly ILogger<ScheduleController> _logger = logger;

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> CreateSchedule([FromBody] CreateScheduleCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }
}