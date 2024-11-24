using AutoMapper;
using GoSolution.Entity.Entities;
using MasterData.Application.Commands;

namespace MasterData.Application.Mappers;

public class EmployeeMappingProfile : Profile
{
    public EmployeeMappingProfile()
    {
        CreateMap<Employee, CreateEmployeeCommand>().ReverseMap();
    }
}