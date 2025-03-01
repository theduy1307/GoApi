using MediatR;
using MasterData.Application.Dtos;

namespace MasterData.Application.Commands;

public class CreateEmployeeSchedulingCommand : IRequest<Guid[]>
{
    public Guid ScheduleId { get; set; }
    public Guid EmployeeId { get; set; }
    public DateTime Date { get; set; }
    public Guid Branch { get; set; }
}

