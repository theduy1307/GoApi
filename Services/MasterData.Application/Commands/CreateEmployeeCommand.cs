using GoSolution.Entity.Enums;
using MediatR;

namespace MasterData.Application.Commands;

public class CreateEmployeeCommand : IRequest<Guid>
{
    public string FirstName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string NickName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string PlaceOfBirth { get; set; } = string.Empty;
    public byte Gender { get; set; }
    public Guid AncestralHomeId { get; set; } // Địa chỉ thường trú
    public Guid EthnicityId { get; set; } // Dân tộc
    public Guid ReligionId { get; set; } // Tôn giáo
    public Guid NationalityId { get; set; } // Quốc tịch
    public string NationalId { get; set; } = string.Empty; // Căn cước công dân
    public DateTime DateOfIssueOfNationalIdentification { get; set; } // Ngày cấp căn cước công dân
    public Guid PlaceOfIssueOfNationalIdentificationId { get; set; } // Nơi cấp căn cước công dân
    public string PassportNumber { get; set; } = string.Empty; // Số hộ chiếu
    public string TaxId { get; set; } = string.Empty; // Mã số thuế
    public DateTime DateOfIssueOfPassport { get; set; } // Ngày cấp hộ chiếu
    public Guid PlaceOfIssueOfPassportId { get; set; } // Nơi cấp hộ chiếu
    public Guid EducationLevelId { get; set; } // Trình độ học vấn
    public Guid SpecializationId { get; set; } // Chuyên môn
    public Guid PoliticalQualificationId { get; set; } // Trình độ chính trị
    public MaritalStatus MaritalStatus { get; set; }
    public DateTime DateOfJoiningTheTradeUnion { get; set; } // Ngày vào công đoàn
}