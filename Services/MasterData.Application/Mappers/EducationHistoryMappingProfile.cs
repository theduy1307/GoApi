using AutoMapper;
using GoSolution.Entity.Entities;
using MasterData.Application.Dtos;
using MasterData.Core.Shared;

namespace MasterData.Application.Mappers;

public class EducationHistoryMappingProfile : Profile
{
    public EducationHistoryMappingProfile()
    {
        CreateMap<EducationHistoryDto, JobsGoEducation>()
            .ForMember(des => des.EduGraduation, 
                act => act.MapFrom(src => src.Graduation))
            .ForMember(des => des.EduMajor, 
                act => act.MapFrom(src => src.Major))
            .ForMember(des => des.EduPeriod, 
                act => act.MapFrom(src => src.Period))
            .ForMember(des => des.EduSchoolUniv, 
                act => act.MapFrom(src => src.SchoolName))
            .ReverseMap();
    }
}