using MediatR;
using Scheduling.Application.Dtos;

namespace Scheduling.Application.Queries;

public class GetEmployeeSchedulingByDateQuery : IRequest<List<EmployeeScheduleDto>>
{
    public Guid EmployeeId { get; set; }
    public DateTime Date { get; set; }
}