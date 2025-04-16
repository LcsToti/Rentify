using Microsoft.EntityFrameworkCore;
using RentifyAPI.Dtos.Auth;
using RentifyAPI.Models;

namespace RentifyAPI.Services.Auth;

public class AuthService : IAuthService
{
    private readonly RentifyContext _context;
    // private readonly RentifyContext _tokenService;
    public AuthService(RentifyContext context)
    {
        _context = context;
    }

    public async Task<AuthResponse> LoginAsync(LoginDto loginDto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);
        if (user == null)
        {
            return new AuthResponse { Success = false, FailureType = AuthFailureType.InvalidEmail, ErrorMessage = "Email não cadastrado." };
        }

        if (!PasswordService.Verify(loginDto.Password, user.PasswordHash))
        {
            return new AuthResponse { Success = false, FailureType = AuthFailureType.InvalidPassword, ErrorMessage = "Senha incorreta." };
        }

        return new AuthResponse { Success = true, Token = new TokenService().Generate(user) };
    }

    public async Task<AuthResponse> RegisterAsync(RegisterDto dto)
    {
        if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
        {
            return new AuthResponse { Success = false, FailureType = AuthFailureType.EmailAlreadyExists, ErrorMessage = "Email já cadastrado." };
        }

        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            PasswordHash = PasswordService.Hash(dto.Password),
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return new AuthResponse { Success = true, Token = new TokenService().Generate(user) };
    }
}
