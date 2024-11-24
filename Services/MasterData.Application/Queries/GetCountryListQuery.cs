using MasterData.Application.Responses;
using MediatR;

namespace MasterData.Application.Queries;

public class GetCountryListQuery : IRequest<List<CountryResponse>>
{
    public string CountryName { get; set; }
    public GetCountryListQuery(string countryName)
    {
        CountryName = countryName;
    }
}