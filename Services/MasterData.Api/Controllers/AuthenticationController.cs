using System.Net;
using MasterData.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace MasterData.Api.Controllers;

public class AuthenticationController(IMediator mediator, ILogger<AuthenticationController> logger) : ApiController
{
    [HttpPost]
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