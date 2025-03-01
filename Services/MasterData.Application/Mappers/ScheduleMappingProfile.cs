using AutoMapper;
using GoSolution.Entity.Entities;
using MasterData.Application.Commands;
using MasterData.Application.Responses;
namespace MasterData.Application.Mappers;

public class ScheduleMappingProfile : Profile
{
    public ScheduleMappingProfile()
    {
        CreateMap<Schedule, ScheduleResponse>().ReverseMap();
        CreateMap<Schedule, CreateScheduleCommand>().ReverseMap();
    }
}