using AutoMapper;
using MasterData.Application.Dtos;
using MasterData.Core.Errors;
using MasterData.Core.Repositories;
using MasterData.Core.Shared;
using MediatR;

namespace MasterData.Application.Handlers.Queries;

public record GetMenuByEmployeeId(Guid EmployeeId) : IRequest<Result<List<MenuDto>>>;
public class GetMenuByEmployeeIdQueryHandler(IEmployeeRepository employeeRepository, IMenuRepository menuRepository, IMapper mapper) : IRequestHandler<GetMenuByEmployeeId, Result<List<MenuDto>>>
{
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;
    private readonly IMenuRepository _menuRepository = menuRepository;
    private readonly IMapper _mapper = mapper;
    public async Task<Result<List<MenuDto>>> Handle(GetMenuByEmployeeId request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetEmployeeById(request.EmployeeId);
        if (employee is null)
        {
            return Result.Failure<List<MenuDto>>(EntityErrors.Employee.InvalidCredentials);
        }

        var menu = await _menuRepository.GetMenuByRolesId(employee.Roles.Select(x => x.Id).ToList());
        var menuDto = _mapper.Map<List<MenuDto>>(menu);
        return Result.Success<List<MenuDto>>(menuDto);
    }
}