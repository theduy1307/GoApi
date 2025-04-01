using AutoMapper;
using GoSolution.Entity.Entities;
using MasterData.Application.Dtos;

namespace MasterData.Application.Mappers;

public class MenuMappingProfile : Profile
{
    public MenuMappingProfile()
    {
        CreateMap<Menu, MenuDto>()
            .ForMember(des => des.Label, 
                act => act.MapFrom(src => src.Name))
            .ForMember(des => des.To, 
                act => act.MapFrom(src => src.Url))
            .ForMember(des => des.Items, 
                act => act.MapFrom(src => src.SubMenus != null && src.SubMenus.Any() ? src.SubMenus : null))
            .ForMember(des => des.Visible, 
                act => act.MapFrom(src => true))

            .ReverseMap();
    }
}