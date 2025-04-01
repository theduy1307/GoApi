using MasterData.Application.Dtos;
using MasterData.Application.Queries;
using MasterData.Core.Shared;
using MasterData.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterData.Api.Controllers;

[Authorize]
public class RecruitmentController(IMediator mediator, ILogger<RecruitmentController> logger) : ApiController
{
    [HttpGet]
    public async Task<ActionResult<Result<IReadOnlyList<RecruitmentCampaignDto>>>> GetPagingRecruitment(
        [FromQuery] GetRecruitmentCampaignPagingQuery request)
    {
        var result = await mediator.Send(request);
        return Ok(result);
    }
    
}