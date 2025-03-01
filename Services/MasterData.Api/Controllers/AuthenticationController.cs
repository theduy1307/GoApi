using System.Net;
using MasterData.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace MasterData.Api.Controllers;

[Authorize]
public class AuthenticationController(IMediator mediator, ILogger<AuthenticationController> logger) : ApiController
{
    [HttpPost]
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
}