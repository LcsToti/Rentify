using RentifyAPI.Dtos.Auth;

namespace RentifyAPI.Services.Auth;

public interface IAuthService 
{
    // Task<AuthResponse> LoginAsync(LoginDto loginDto);
    Task<AuthResponse> RegisterAsync(RegisterDto registerDto);
}

