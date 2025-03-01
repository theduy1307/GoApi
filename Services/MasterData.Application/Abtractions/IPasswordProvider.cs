using System.Security.Cryptography;

namespace MasterData.Application.Abtractions;

public interface IPasswordProvider
{
    (string salt, string hash) HashPassword(string password);
    bool VerifyPassword(string password, string storedSalt, string storedHash);
}