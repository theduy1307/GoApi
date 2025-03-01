using System.Security.Cryptography;
using MasterData.Application.Abtractions;

namespace MasterData.Infrastructure.Authentication;

public class PasswordProvider : IPasswordProvider
{
    private const int SALT_SIZE = 16;
    private const int KEY_SIZE = 32;
    private const int INTERATIONS = 100000;
    public (string salt, string hash) HashPassword(string password)
    {
        using var rng = new RNGCryptoServiceProvider();
        //byte[] saltBytes = new byte[SALT_SIZE];
        var saltBytes = Convert.FromBase64String("8vNWcwRa+ThpJvLqUnlGRQ==");
        rng.GetBytes(saltBytes); // Tạo salt ngẫu nhiên

        using var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, INTERATIONS, HashAlgorithmName.SHA256);
        byte[] hashBytes = pbkdf2.GetBytes(KEY_SIZE);
        return (Convert.ToBase64String(saltBytes), Convert.ToBase64String(hashBytes));
    }

    public bool VerifyPassword(string password, string storedSalt, string storedHash)
    {
        var saltBytes = Convert.FromBase64String(storedSalt);
        var storedHashBytes = Convert.FromBase64String(storedHash);

        using var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, INTERATIONS, HashAlgorithmName.SHA256);
        var hashBytes = pbkdf2.GetBytes(KEY_SIZE);
        return CryptographicOperations.FixedTimeEquals(hashBytes, storedHashBytes);
    }
}