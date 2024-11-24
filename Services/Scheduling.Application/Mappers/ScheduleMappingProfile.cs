using AutoMapper;
using GoSolution.Entity.Entities;
using Scheduling.Application.Commands;
using Scheduling.Application.Responses;
namespace Scheduling.Application.Mappers;

public class ScheduleMappingProfile : Profile
{
    public ScheduleMappingProfile()
    {
        CreateMap<Schedule, ScheduleResponse>().ReverseMap();
        CreateMap<Schedule, CreateScheduleCommand>().ReverseMap();
    }
}