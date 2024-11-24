namespace Scheduling.Application.Responses;

public class ScheduleDetailResponse
{
    public string Name { get; set; } = string.Empty;
    public TimeSpan FromTime { get; set; }
    public TimeSpan ToTime { get; set; }
    public bool Required { get; set; }
}