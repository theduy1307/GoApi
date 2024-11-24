using AutoMapper;
using GoSolution.Entity.Entities;
using Scheduling.Application.Commands;
using Scheduling.Application.Responses;

namespace Scheduling.Application.Mappers;

public class BranchMappingProfile : Profile
{
    public BranchMappingProfile()
    {
        CreateMap<Branch, BranchResponse>().ReverseMap();
        CreateMap<Branch, CreateBranchCommand>().ReverseMap();
    }
}