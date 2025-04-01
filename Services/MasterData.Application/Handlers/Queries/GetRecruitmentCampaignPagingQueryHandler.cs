using AutoMapper;
using MasterData.Application.Dtos;
using MasterData.Application.Queries;
using MasterData.Core.Repositories;
using MasterData.Core.Shared;
using MasterData.Infrastructure.Data;
using MediatR;

namespace MasterData.Application.Handlers.Queries;

public class GetRecruitmentCampaignPagingQueryHandler(IRecruitmentCampaignRepository recruitmentCampaignRepository, IEmployeeRepository employeeRepository, IMapper mapper) : IRequestHandler<GetRecruitmentCampaignPagingQuery, Result<PagingResultBase<RecruitmentCampaignDto>>>
{
    private readonly IRecruitmentCampaignRepository _recruitmentCampaignRepository = recruitmentCampaignRepository;
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;
    private readonly IMapper _mapper = mapper;
    public async Task<Result<PagingResultBase<RecruitmentCampaignDto>>> Handle(GetRecruitmentCampaignPagingQuery request, CancellationToken cancellationToken)
    {
        var query = await _recruitmentCampaignRepository.GetPagingAsync(request.PageIndex, request.PageSize);
        var listEmployeeIds = query.Where(x => !string.IsNullOrEmpty(x.CreatedBy)).Select(x =>x.CreatedBy).Concat(query.Where(x => !string.IsNullOrEmpty(x.LastModifiedBy)).Select(x => x.LastModifiedBy));
        var employees = await _employeeRepository.GetAllAsync(x => listEmployeeIds.Contains(x.Id.ToString()));
        var totalCount = await _recruitmentCampaignRepository.CountAsync();
        var data = _mapper.Map<List<RecruitmentCampaignDto>>(query);
        foreach (var recruitmentCampaignDto in data)
        {
            if (!string.IsNullOrEmpty(recruitmentCampaignDto.CreatedBy))
                recruitmentCampaignDto.CreatedBy = employees
                    .FirstOrDefault(x => x.Id.ToString() == recruitmentCampaignDto.CreatedBy)?.FullName;
            
            if (!string.IsNullOrEmpty(recruitmentCampaignDto.ModifiedBy))
                recruitmentCampaignDto.CreatedBy = employees
                    .FirstOrDefault(x => x.Id.ToString() == recruitmentCampaignDto.ModifiedBy)?.FullName;
        }
        var result = new PagingResultBase<RecruitmentCampaignDto>
        {
            PageSize = request.PageSize,
            Items = data,
            TotalRecords = totalCount
        };
        return result;
    }
}