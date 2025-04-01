namespace MasterData.Application.Dtos;

public class RecruitmentCampaignDto
{
    public string Name { get; set; } = string.Empty;
    public string JobDescription { get; set; } = string.Empty;
    public string? CreatedBy { get; set; } = string.Empty;
    public string? ModifiedBy { get; set; } = string.Empty;
    public DateTime? CreateDate { get; set; }
    public DateTime? LastModifiedDate { get; set; } 
    public List<CandidateDto> Candidates { get; set; } = [];
}