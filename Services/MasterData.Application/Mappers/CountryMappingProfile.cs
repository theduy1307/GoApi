using AutoMapper;
using GoSolution.Entity.Entities;
using MasterData.Application.Commands;
using MasterData.Application.Responses;
namespace MasterData.Application.Mappers;

public class CountryMappingProfile : Profile
{
    public CountryMappingProfile()
    {
        CreateMap<Country, CountryResponse>().ReverseMap();
        CreateMap<Country, CreateCountryCommand>().ReverseMap();
        CreateMap<Country, DeleteCountryCommand>().ReverseMap();
        CreateMap<Country, UpdateCountryCommand>().ReverseMap();
    }
}