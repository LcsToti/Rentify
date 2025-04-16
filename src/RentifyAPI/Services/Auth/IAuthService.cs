using RentifyAPI.Dtos;
using RentifyAPI.Dtos.Auth;

namespace RentifyAPI.Services.Auth;

public interface IAuthService 
{
    Task<Response> LoginAsync(LoginDto loginDto);
    Task<Response> RegisterAsync(RegisterDto registerDto);
}

