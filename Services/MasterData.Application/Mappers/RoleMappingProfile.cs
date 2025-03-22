using AutoMapper;
using GoSolution.Entity.Entities;
using MasterData.Application.Dtos;

namespace MasterData.Application.Mappers;

public class RoleMappingProfile : Profile
{
    public RoleMappingProfile()
    {
        CreateMap<Role, RoleDto>().ReverseMap();
    }
}