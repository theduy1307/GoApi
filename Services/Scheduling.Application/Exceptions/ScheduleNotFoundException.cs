namespace Scheduling.Application.Exceptions;

public class ScheduleNotFoundException : ApplicationException
{
    public ScheduleNotFoundException(string name, Object key) : base($"Entity {name} - {key} is not found.")
    {
        
    }
}