using System.Net;
using MasterData.Application.Commands;
using MasterData.Application.Handlers.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace MasterData.Api.Controllers;

[Authorize]
public class AuthenticationController(IMediator mediator, ILogger<AuthenticationController> logger) : ApiController
{
    [HttpPost("[action]")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginCommand request, CancellationToken cancellationToken)
    {
        var tokenResult = await mediator.Send(request, cancellationToken);
        if (tokenResult.IsFailure)
        {
            return HandleFailure(tokenResult);
        }
        return Ok(tokenResult.Value);
    }
    
    [HttpGet("Menu")]
    public async Task<IActionResult> Menu([FromQuery] Guid employeeId, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetMenuByEmployeeId(employeeId), cancellationToken);
        return Ok(result);
    }
}