using System.Net;
using MasterData.Application.Commands;
using MasterData.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;

namespace MasterData.Api.Controllers;

[Authorize]
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

    [HttpGet("{id}")]
    public async Task<ActionResult> GetEmployeeById(Guid id)
    {
        var result = await mediator.Send(new GetEmployeeByIdQuery(id));
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult> GetEmployeeInfo()
    {
        var identity = HttpContext.User.Identity as System.Security.Claims.ClaimsIdentity;
    
        if (identity == null || !identity.Claims.Any())
        {
            return Unauthorized(new { message = "Invalid token" });
        }
        var claims = identity.Claims.ToDictionary(c => c.Type, c => c.Value);
        if (!claims.ContainsKey(System.Security.Claims.ClaimTypes.NameIdentifier))
        {
            return Unauthorized(new { message = "Invalid token" });
        }

        var employeeId = Guid.Parse(claims[System.Security.Claims.ClaimTypes.NameIdentifier]);
        var result = await mediator.Send(new GetEmployeeByIdQuery(employeeId));
        return Ok(result);
    }
}