using RentifyAPI.Dtos;
using RentifyAPI.Dtos.Auth;
using RentifyAPI.Models;
using RentifyAPI.Repositories;
using RentifyAPI.Services.Password;
using RentifyAPI.Services.Token;

namespace RentifyAPI.Services.Auth;

public class AuthService(UserRepository userRepository, IPasswordService passwordService, ITokenService tokenService) : IAuthService
{
    private readonly UserRepository _userRepository = userRepository;
    private readonly IPasswordService _passwordService = passwordService;
    private readonly ITokenService _tokenService = tokenService;

    public async Task<Response> LoginAsync(LoginDto loginDto)
    {
        if (!await _userRepository.EmailExists(loginDto.Email))
        {
            return new Response { Success = false, FailureType = AuthFailureType.InvalidEmail, ErrorMessage = "Email não cadastrado." };
        }

        var user = await _userRepository.GetByEmail(loginDto.Email);

        if (!_passwordService.Verify(loginDto.Password, user.PasswordHash))
        {
            return new Response { Success = false, FailureType = AuthFailureType.InvalidPassword, ErrorMessage = "Senha incorreta." };
        }

        return new Response { Success = true, Token = _tokenService.Generate(user) };
    }

    public async Task<Response> RegisterAsync(RegisterDto dto)
    {
        if (await _userRepository.EmailExists(dto.Email))
        {
            return new Response { Success = false, FailureType = AuthFailureType.EmailAlreadyExists, ErrorMessage = "Email já cadastrado." };
        }

        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            PasswordHash = _passwordService.Hash(dto.Password),
        };
       

        await _userRepository.Add(user);

        return new Response { Success = true, Token = _tokenService.Generate(user) };
    }
}
