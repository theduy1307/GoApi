using AutoMapper;
using GoSolution.Entity.Entities;
using MasterData.Application.Dtos;
using MasterData.Application.Extensions;
using MasterData.Core.Shared;

namespace MasterData.Application.Mappers;

public class CandidateMappingProfile : Profile
{
    public CandidateMappingProfile()
    {
        CreateMap<CandidateDto, JobsGoResponse>()
            .ReverseMap();
        CreateMap<Candidate, CandidateDto>()
            .ForMember(des => des.Gender, 
                act => act.MapFrom(src => src.Gender.ToGenderValue()))
            .ReverseMap();
    }
}