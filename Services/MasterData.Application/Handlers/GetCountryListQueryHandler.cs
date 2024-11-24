using AutoMapper;
using MasterData.Application.Queries;
using MasterData.Application.Responses;
using MasterData.Core.Repositories;
using MediatR;

namespace MasterData.Application.Handlers;

public class GetCountryListQueryHandler : IRequestHandler<GetCountryListQuery, List<CountryResponse>>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;
    public GetCountryListQueryHandler(ICountryRepository countryRepository, IMapper mapper)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
    }
    public async Task<List<CountryResponse>> Handle(GetCountryListQuery request, CancellationToken cancellationToken)
    {
        var countryList = await _countryRepository.GetCountryByName(request.CountryName);
        return _mapper.Map<List<CountryResponse>>(countryList);
    }
}