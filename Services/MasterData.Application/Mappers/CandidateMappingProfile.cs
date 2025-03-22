using AutoMapper;
using MasterData.Application.Dtos;
using MasterData.Core.Shared;

namespace MasterData.Application.Mappers;

public class CandidateMappingProfile : Profile
{
    public CandidateMappingProfile()
    {
        CreateMap<CandidateDto, JobsGoResponse>()
            .ReverseMap();
    }
}