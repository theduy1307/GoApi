using MasterData.Application.Dtos;
using MasterData.Core.Shared;
using MediatR;

namespace MasterData.Application.Queries;

public class GetEmployeeByIdQuery(Guid id) : IRequest<Result<EmployeeDto>>
{
    public Guid Id { get; set; } = id;
}