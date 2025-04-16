using RentifyAPI.Models;

namespace RentifyAPI.Services.Auth;

public interface ITokenService
{
    string Generate(User user);
}
