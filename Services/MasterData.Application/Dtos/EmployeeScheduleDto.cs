namespace MasterData.Application.Dtos;

public abstract class EmployeeScheduleDto
{
    public Guid ScheduleId { get; set; }
    public Guid EmployeeId { get; set; }
    public DateTime Date { get; set; }
    public Guid Branch { get; set; }
}