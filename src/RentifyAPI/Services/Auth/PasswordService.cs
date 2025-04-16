namespace RentifyAPI.Services.Auth;

public class PasswordService : IPasswordService
{
    public string Hash(string password)
    {
        const int workFactor = 12;
        return BCrypt.Net.BCrypt.HashPassword(password, workFactor);
    }
    public bool Verify(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}
