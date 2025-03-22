using AutoMapper;
using MasterData.Application.Dtos;
using MasterData.Application.Queries;
using MasterData.Core.Repositories;
using MasterData.Core.Shared;
using MasterData.Infrastructure.Data;
using MediatR;

namespace MasterData.Application.Handlers.Queries;

public class GetRecruitmentCampaignPagingQueryHandler(IRecruitmentCampaignRepository recruitmentCampaignRepository, IMapper mapper) : IRequestHandler<GetRecruitmentCampaignPagingQuery, Result<PagingResultBase<RecruitmentCampaignDto>>>
{
    private readonly IRecruitmentCampaignRepository _recruitmentCampaignRepository = recruitmentCampaignRepository;
    private readonly IMapper _mapper = mapper;
    public async Task<Result<PagingResultBase<RecruitmentCampaignDto>>> Handle(GetRecruitmentCampaignPagingQuery request, CancellationToken cancellationToken)
    {
        var query = await _recruitmentCampaignRepository.GetPagingAsync(request.PageIndex, request.PageSize);
        var totalCount = await _recruitmentCampaignRepository.CountAsync();
        var data = _mapper.Map<List<RecruitmentCampaignDto>>(query);
        var result = new PagingResultBase<RecruitmentCampaignDto>
        {
            PageSize = request.PageSize,
            Items = data,
            TotalRecords = totalCount
        };
        return Result.Success(result);
    }
}