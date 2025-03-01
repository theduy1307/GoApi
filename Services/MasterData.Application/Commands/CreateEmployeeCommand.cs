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
}