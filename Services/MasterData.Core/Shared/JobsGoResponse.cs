namespace MasterData.Core.Shared;

public class JobsGoResponse
{
    public string Name { get; set; } = string.Empty;
    public string Dob { get; set; } = string.Empty;
    public string FormatedDob { get; set; } = string.Empty;
    public byte Gender { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Location1 { get; set; } = string.Empty;
    public IEnumerable<JobsGoJobHistory> JobHistory { get; set; } = [];
    public IEnumerable<JobsGoEducation> Education { get; set; } = [];
    public string OtherSkill { get; set; } = string.Empty;
    public string OtherCertificate { get; set; } = string.Empty;
    public string OtherCareerObjective { get; set; } = string.Empty;
    public string OtherInterest { get; set; } = string.Empty;
    public string OtherAward { get; set; } = string.Empty;
    public string OtherProject { get; set; } = string.Empty;
    public string OtherSocialActivities { get; set; } = string.Empty;
}

public class JobsGoJobHistory
{
    public string ExpPeriod { get; set; } = string.Empty;
    public string ExpPosition { get; set; } = string.Empty;
    public string ExpCompanyName { get; set; } = string.Empty;
    public string ExpDescription { get; set; } = string.Empty;
    public TimePeriod NormalizedPeriod { get; set; } = new TimePeriod();
}

public class JobsGoEducation
{
    public string EduSchoolUniv { get; set; } = string.Empty;
    public string EduMajor { get; set; } = string.Empty;
    public string EduGraduation { get; set; } = string.Empty;
    public string EduPeriod { get; set; } = string.Empty;
    public TimePeriod NormalizedPeriod { get; set; } = new TimePeriod();
}

public class TimePeriod
{
    public string Start { get; set; } = string.Empty;
    public string To { get; set; } = string.Empty;
}