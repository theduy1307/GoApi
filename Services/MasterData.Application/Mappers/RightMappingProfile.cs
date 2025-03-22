using AutoMapper;
using GoSolution.Entity.Entities;
using MasterData.Application.Dtos;

namespace MasterData.Application.Mappers;

public class RightMappingProfile : Profile
{
    public RightMappingProfile()
    {
        CreateMap<Right, RightDto>().ReverseMap();
    }
}