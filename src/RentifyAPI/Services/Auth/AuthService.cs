using Microsoft.EntityFrameworkCore;
using RentifyAPI.Dtos.Auth;
using RentifyAPI.Models;
using RentifyAPI.Repositories;

namespace RentifyAPI.Services.Auth;

public class AuthService : IAuthService
{
    private readonly UserRepository _userRepository;
    private readonly IPasswordService _passwordService;
    public AuthService(UserRepository userRepository, IPasswordService passwordService)
    {
        _userRepository = userRepository;
        _passwordService = passwordService;
    }

    public async Task<AuthResponse> LoginAsync(LoginDto loginDto)
    {
        if (await _userRepository.EmailExists(loginDto.Email))
        {
            return new AuthResponse { Success = false, FailureType = AuthFailureType.InvalidEmail, ErrorMessage = "Email não cadastrado." };
        }

        var user = await _userRepository.GetByEmail(loginDto.Email);

        if (!_passwordService.Verify(loginDto.Password, user.PasswordHash))
        {
            return new AuthResponse { Success = false, FailureType = AuthFailureType.InvalidPassword, ErrorMessage = "Senha incorreta." };
        }

        return new AuthResponse { Success = true, Token = new TokenService().Generate(user) };
    }

    public async Task<AuthResponse> RegisterAsync(RegisterDto dto)
    {
        if (await _userRepository.EmailExists(dto.Email))
        {
            return new AuthResponse { Success = false, FailureType = AuthFailureType.EmailAlreadyExists, ErrorMessage = "Email já cadastrado." };
        }

        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            PasswordHash = _passwordService.Hash(dto.Password),
        };

        await _userRepository.Add(user);

        return new AuthResponse { Success = true, Token = new TokenService().Generate(user) };
    }
}
