namespace RentifyAPI.Services.Auth;

public interface IPasswordService
{
    bool Verify(string password, string hash);
    string Hash(string password);
}
