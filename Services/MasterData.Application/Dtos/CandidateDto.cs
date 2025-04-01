namespace MasterData.Application.Dtos;

public class CandidateDto
{
    public string FullName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Skills { get; set; } = string.Empty;
    public string CareerObjective { get; set; } = string.Empty;
    public string Interest { get; set; } = string.Empty;
    public string Award { get; set; } = string.Empty;
    public string Project { get; set; } = string.Empty;
    public string SocialActivities { get; set; } = string.Empty;
    public ICollection<JobHistoryDto> JobHistories { get; set; } = [];
    public ICollection<EducationHistoryDto> CandidateEducations { get; set; } = [];
}
