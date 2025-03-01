using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MasterData.Application.Commands;
using MasterData.Application.Handlers;
using Microsoft.AspNetCore.Authorization;

namespace MasterData.Api.Controllers;

[Authorize]
public class EmployeeSchedulingController(IMediator mediator, ILogger<ScheduleController> logger) : ApiController
{
    private readonly ILogger<ScheduleController> _logger = logger;

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> ModifyEmployeeScheduling([FromBody] CreateEmployeeSchedulingCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }
}