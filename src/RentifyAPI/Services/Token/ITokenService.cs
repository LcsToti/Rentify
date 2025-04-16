using RentifyAPI.Models;

namespace RentifyAPI.Services.Token;

public interface ITokenService
{
    string Generate(User user);
}
