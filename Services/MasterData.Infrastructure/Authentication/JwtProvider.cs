using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GoSolution.Entity.Entities;
using MasterData.Application.Abtractions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace MasterData.Infrastructure.Authentication;

public class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _options;

    public JwtProvider(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }
    public string Generate(Employee employee)
    {
        var claims = new Claim[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, employee.Id.ToString()),
            new(JwtRegisteredClaimNames.Name, string.Join(" ", new[] { employee.FirstName, employee.MiddleName, employee.LastName }.Where(s => !string.IsNullOrWhiteSpace(s)))),
            new(JwtRegisteredClaimNames.Email, employee.Account?.Username ?? string.Empty)
        };
        var signinCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_options.SecretKey)),
            SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            _options.Issuer,
            _options.Audience,
            claims, null,
            DateTime.UtcNow.AddHours(1), 
            signinCredentials);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}