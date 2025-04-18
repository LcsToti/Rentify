using RentifyAPI.Dtos.Request;

namespace RentifyAPI.Services.Auth;

public interface IAuthService 
{
    Task<AuthResponse> LoginAsync(LoginRequest loginDto);
    Task<AuthResponse> RegisterAsync(RegisterRequest registerDto);
}

