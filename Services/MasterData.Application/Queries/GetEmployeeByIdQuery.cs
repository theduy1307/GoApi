using MasterData.Application.Dtos;
using MediatR;

namespace MasterData.Application.Queries;

public class GetEmployeeByIdQuery(Guid id) : IRequest<EmployeeDto>
{
    public Guid Id { get; set; } = id;
}