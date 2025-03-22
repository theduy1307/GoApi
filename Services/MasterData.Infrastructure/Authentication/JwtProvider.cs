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
            new(JwtRegisteredClaimNames.Name, employee.FullName),
            new(JwtRegisteredClaimNames.Email, employee.Account?.Username ?? string.Empty)
        };
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_options.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _options.Issuer,
            _options.Audience,
            claims,
            null,
            DateTime.UtcNow.AddHours(1),
            signingCredentials);

        var tokenValue = new JwtSecurityTokenHandler()
            .WriteToken(token);

        return tokenValue;
    }
}