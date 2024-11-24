using MediatR;
using Scheduling.Application.Dtos;

namespace Scheduling.Application.Commands;

public class CreateEmployeeSchedulingCommand : IRequest<Guid[]>
{
    public Guid ScheduleId { get; set; }
    public Guid EmployeeId { get; set; }
    public DateTime Date { get; set; }
    public Guid Branch { get; set; }
}

