using RentifyAPI.Dtos.Auth;
using RentifyAPI.Models;
using RentifyAPI.Repositories;
using RentifyAPI.Services.Password;
using RentifyAPI.Services.Token;

namespace RentifyAPI.Services.Auth;

public class AuthService(IUserRepository userRepository, IPasswordService passwordService, ITokenService tokenService) : IAuthService
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IPasswordService _passwordService = passwordService;
    private readonly ITokenService _tokenService = tokenService;

    public async Task<AuthResponse> LoginAsync(LoginDto loginDto)
    {
        if (!await _userRepository.EmailExistsAsync(loginDto.Email))
        {
            return new AuthResponse { Success = false, FailureType = AuthFailureType.InvalidEmail, ErrorMessage = "Email não cadastrado." };
        }

        var user = await _userRepository.GetByEmailAsync(loginDto.Email);

        if (!_passwordService.Verify(loginDto.Password, user.PasswordHash))
        {
            return new AuthResponse { Success = false, FailureType = AuthFailureType.InvalidPassword, ErrorMessage = "Senha incorreta." };
        }

        return new AuthResponse { Success = true, Token = _tokenService.Generate(user) };
    }

    public async Task<AuthResponse> RegisterAsync(RegisterDto dto)
    {
        if (await _userRepository.EmailExistsAsync(dto.Email))
        {
            return new AuthResponse { Success = false, FailureType = AuthFailureType.EmailAlreadyExists, ErrorMessage = "Email já cadastrado." };
        }

        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            PasswordHash = _passwordService.Hash(dto.Password),
        };
       

        await _userRepository.AddAsync(user);

        return new AuthResponse { Success = true, Token = _tokenService.Generate(user) };
    }
}
