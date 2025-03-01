using AutoMapper;
using GoSolution.Entity.Entities;
using MasterData.Application.Commands;
using MasterData.Application.Dtos;

namespace MasterData.Application.Mappers;

public class EmployeeMappingProfile : Profile
{
    public EmployeeMappingProfile()
    {
        CreateMap<Employee, CreateEmployeeCommand>().ReverseMap();
        CreateMap<Employee, EmployeeDto>().ReverseMap();
    }
}