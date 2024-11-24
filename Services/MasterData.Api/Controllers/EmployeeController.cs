using System.Net;
using MasterData.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MasterData.Api.Controllers;

public class EmployeeController : ApiController
{
    private readonly IMediator _mediator;
    private readonly ILogger<CountryController> _logger;

    public EmployeeController(IMediator mediator, ILogger<CountryController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }
    
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> CreateEmployee([FromBody] CreateEmployeeCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}