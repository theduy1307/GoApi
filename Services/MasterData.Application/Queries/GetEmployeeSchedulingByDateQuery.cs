using MediatR;
using MasterData.Application.Dtos;

namespace MasterData.Application.Queries;

public class GetEmployeeSchedulingByDateQuery : IRequest<List<EmployeeScheduleDto>>
{
    public Guid EmployeeId { get; set; }
    public DateTime Date { get; set; }
}