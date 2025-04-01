using AutoMapper;
using MasterData.Application.Dtos;
using MasterData.Application.Queries;
using MasterData.Core.Repositories;
using MasterData.Core.Shared;
using MasterData.Infrastructure.Data;
using MediatR;

namespace MasterData.Application.Handlers.Queries;

public class GetCandidatePagingQueryHandler(ICandidateRepository candidateRepository, IMapper mapper) : IRequestHandler<GetCandidatePagingQuery, Result<PagingResultBase<CandidateDto>>>
{
    private readonly ICandidateRepository _candidateRepository = candidateRepository;
    private readonly IMapper _mapper = mapper;
    
    public async Task<Result<PagingResultBase<CandidateDto>>> Handle(GetCandidatePagingQuery request, CancellationToken cancellationToken)
    {
        var query = await _candidateRepository.GetPagingAsync(request.PageIndex, request.PageSize);
        var totalCount = await _candidateRepository.CountAsync();
        var data = _mapper.Map<List<CandidateDto>>(query);
        return new PagingResultBase<CandidateDto>
        {
            PageSize = request.PageSize,
            Items = data,
            TotalRecords = totalCount
        };
    }
}