namespace Scheduling.Application.Responses;

public class ScheduleResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TimeSpan FromTime { get; set; }
    public TimeSpan ToTime { get; set; }
}