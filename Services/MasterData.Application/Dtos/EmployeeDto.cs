namespace MasterData.Application.Dtos;

public class EmployeeDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string NickName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string PlaceOfBirth { get; set; } = string.Empty;
    public byte Gender { get; set; }
    public Guid AncestralHomeId { get; set; }
    public string AncestralHomeLabel { get; set; } = string.Empty;
    public string PassportNumber { get; set; } = string.Empty;
    public string TaxId { get; set; } = string.Empty;
    public List<Guid> RoleIds { get; set; } = [];
}