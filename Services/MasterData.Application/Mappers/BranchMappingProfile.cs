using AutoMapper;
using GoSolution.Entity.Entities;
using MasterData.Application.Commands;
using MasterData.Application.Responses;

namespace MasterData.Application.Mappers;

public class BranchMappingProfile : Profile
{
    public BranchMappingProfile()
    {
        CreateMap<Branch, BranchResponse>().ReverseMap();
        CreateMap<Branch, CreateBranchCommand>().ReverseMap();
    }
}