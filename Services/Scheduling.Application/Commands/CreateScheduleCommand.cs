using MediatR;
using Scheduling.Application.Responses;

namespace Scheduling.Application.Commands;

public class CreateScheduleCommand : IRequest<ScheduleResponse>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TimeSpan FromTime { get; set; }
    public TimeSpan ToTime { get; set; }
}

