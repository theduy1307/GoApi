namespace MasterData.Application.Dtos;

public class RecruitmentCampaignDto
{
    public string Name { get; set; } = string.Empty;
    public List<CandidateDto> Candidates { get; set; } = [];
}