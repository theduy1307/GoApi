using GoSolution.Entity.Entities;
using MasterData.Application.Abtractions;
using MasterData.Application.Commands;
using MasterData.Application.Exceptions;
using MasterData.Core.Errors;
using MasterData.Core.Repositories;
using MasterData.Core.Shared;
using MediatR;

namespace MasterData.Application.Handlers;

public class LoginCommandHandler(IAccountRepository accountRepository, IJwtProvider jwtProvider, IEmployeeRepository employeeRepository, IPasswordProvider passwordProvider) : IRequestHandler<LoginCommand, Result<string>>
{
    private readonly IAccountRepository _accountRepository = accountRepository;
    private readonly IJwtProvider _jwtProvider = jwtProvider;
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;
    private readonly IPasswordProvider _passwordProvider = passwordProvider;
    public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var account = await _accountRepository.GetByEmailAsync(request.Email);
        if (account is null)
        {
            throw new NotFoundException(nameof(Account), request.Email);
        }

        var password = _passwordProvider.HashPassword("P@ssw0rd&user=nimda-repus");
        var isAuthenticated = _passwordProvider.VerifyPassword(request.Password, account.Salt, account.Password);
        
        var employee = await _employeeRepository.GetByIdAsync(account.EmployeeId);
        if (employee is null)
        {
            return Result.Failure<string>(EntityErrors.Employee.InvalidCredentials);
        }

        var token = _jwtProvider.Generate(employee);
        return token;
    }
}