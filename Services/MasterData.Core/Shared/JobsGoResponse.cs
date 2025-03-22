using System.Text.Json.Serialization;

namespace MasterData.Core.Shared;

public class JobsGoApiResult
{
    [JsonPropertyName("status")]
    public int Status { get; set; }

    [JsonPropertyName("data")] public JobsGoResponse Data { get; set; } = new JobsGoResponse();
}
public class JobsGoResponse
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    [JsonPropertyName("dob")]
    public string Dob { get; set; } = string.Empty;
    [JsonPropertyName("formated_dob")]
    public string FormatedDob { get; set; } = string.Empty;
    [JsonPropertyName("gender")]
    public byte Gender { get; set; }
    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;
    [JsonPropertyName("phone")]
    public string Phone { get; set; } = string.Empty;
    [JsonPropertyName("location1")]
    public string Location1 { get; set; } = string.Empty;
    [JsonPropertyName("job_history")]
    public IEnumerable<JobsGoJobHistory> JobHistory { get; set; } = [];
    [JsonPropertyName("education")]
    public IEnumerable<JobsGoEducation> Education { get; set; } = [];
    [JsonPropertyName("other_skill")]
    public string OtherSkill { get; set; } = string.Empty;
    [JsonPropertyName("other_certificate")]
    public string OtherCertificate { get; set; } = string.Empty;
    [JsonPropertyName("other_career_objective")]
    public string OtherCareerObjective { get; set; } = string.Empty;
    [JsonPropertyName("other_interest")]
    public string OtherInterest { get; set; } = string.Empty;
    [JsonPropertyName("other_award")]
    public string OtherAward { get; set; } = string.Empty;
    [JsonPropertyName("other_project")]
    public string OtherProject { get; set; } = string.Empty;
    [JsonPropertyName("other_social_activities")]
    public string OtherSocialActivities { get; set; } = string.Empty;
}

public class JobsGoJobHistory
{
    [JsonPropertyName("exp_period")]
    public string ExpPeriod { get; set; } = string.Empty;
    [JsonPropertyName("exp_position")]
    public string ExpPosition { get; set; } = string.Empty;
    [JsonPropertyName("exp_company_name")]
    public string ExpCompanyName { get; set; } = string.Empty;
    [JsonPropertyName("exp_description")]
    public string ExpDescription { get; set; } = string.Empty;
    [JsonPropertyName("normalized_period")]
    public TimePeriod NormalizedPeriod { get; set; } = new TimePeriod();
}

public class JobsGoEducation
{
    [JsonPropertyName("edu_school_univ")]
    public string EduSchoolUniv { get; set; } = string.Empty;
    [JsonPropertyName("edu_major")]
    public string EduMajor { get; set; } = string.Empty;
    [JsonPropertyName("edu_graduation")]
    public string EduGraduation { get; set; } = string.Empty;
    [JsonPropertyName("edu_period")]
    public string EduPeriod { get; set; } = string.Empty;
    [JsonPropertyName("normalized_period")]
    public TimePeriod NormalizedPeriod { get; set; } = new TimePeriod();
}

public class TimePeriod
{
    [JsonPropertyName("start")]
    public string Start { get; set; } = string.Empty;
    [JsonPropertyName("to")]
    public string To { get; set; } = string.Empty;
}