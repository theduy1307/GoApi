using AutoMapper;
using GoSolution.Entity.Entities;
using MasterData.Application.Dtos;
using MasterData.Application.Exceptions;
using MasterData.Application.Queries;
using MasterData.Application.Responses;
using MasterData.Core.Repositories;
using MediatR;

namespace MasterData.Application.Handlers;

public class GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
    : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
{
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetEmployeeById(request.Id);
        if (employee is null)
        {
            throw new NotFoundException(nameof(Employee), request.Id);
        }
        return _mapper.Map<EmployeeDto>(employee);
    }
}