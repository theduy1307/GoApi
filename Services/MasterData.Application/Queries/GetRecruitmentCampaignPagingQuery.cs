using MasterData.Application.Dtos;
using MasterData.Core.Shared;
using MasterData.Infrastructure.Data;
using MediatR;

namespace MasterData.Application.Queries;

public class GetRecruitmentCampaignPagingQuery : IRequest<Result<PagingResultBase<RecruitmentCampaignDto>>>
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
}