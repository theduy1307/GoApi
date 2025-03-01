using System.Net;
using MasterData.Application.Commands;
using MasterData.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MasterData.Api.Controllers;

public class EmployeeController(IMediator mediator, ILogger<EmployeeController> logger) : ApiController
{
    private readonly ILogger<EmployeeController> _logger = logger;

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> CreateEmployee([FromBody] CreateEmployeeCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetEmployeeById([FromQuery] Guid id)
    {
        var result = await mediator.Send(new GetEmployeeByIdQuery(id));
        return Ok(result);
    }
}