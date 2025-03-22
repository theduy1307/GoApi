using AutoMapper;
using MasterData.Application.Dtos;
using MasterData.Core.Shared;

namespace MasterData.Application.Mappers;

public class JobHistoryMappingProfile : Profile
{
    public JobHistoryMappingProfile()
    {
        CreateMap<JobHistoryDto, JobsGoJobHistory>()
            .ForMember(des => des.ExpPeriod, 
                act => act.MapFrom(src => src.Period))
            .ForMember(des => des.ExpPosition, 
                act => act.MapFrom(src => src.Position))
            .ForMember(des => des.ExpCompanyName, 
                act => act.MapFrom(src => src.Company))
            .ForMember(des => des.ExpDescription, 
                act => act.MapFrom(src => src.Description))
            .ReverseMap();
        // CreateMap<Employee, EmployeeDto>()
        //     .ForMember(des => des.RoleIds, 
        //         act => act.MapFrom(src => src.Roles.Select(x => x.Id)))
        //     .ReverseMap();
    }
}