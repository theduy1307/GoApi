using MasterData.Application.Dtos;
using MasterData.Core.Shared;
using MasterData.Infrastructure.Data;
using MediatR;

namespace MasterData.Application.Queries;

public class GetCandidatePagingQuery : IRequest<Result<PagingResultBase<CandidateDto>>>
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
}