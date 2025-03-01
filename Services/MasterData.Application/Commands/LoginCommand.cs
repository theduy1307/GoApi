using MasterData.Core.Shared;
using MediatR;

namespace MasterData.Application.Commands;

public class LoginCommand(string email, string password) : IRequest<Result<string>>
{
    public string Email { get; set; } = email;
    public string Password { get; set; } = password;
}