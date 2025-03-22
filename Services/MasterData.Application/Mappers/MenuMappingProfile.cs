using AutoMapper;
using GoSolution.Entity.Entities;
using MasterData.Application.Dtos;

namespace MasterData.Application.Mappers;

public class MenuMappingProfile : Profile
{
    public MenuMappingProfile()
    {
        CreateMap<Menu, MenuDto>().ReverseMap();
    }
}