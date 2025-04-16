namespace RentifyAPI.Services.Password;

public interface IPasswordService
{
    bool Verify(string password, string hash);
    string Hash(string password);
}
