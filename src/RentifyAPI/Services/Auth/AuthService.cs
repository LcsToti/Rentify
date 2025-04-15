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

    public async Task<AuthResponse> RegisterAsync(RegisterDto dto)
    {
        if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
        {
            throw new InvalidOperationException("E-mail já cadastrado.");
        }

        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            PasswordHash = PasswordService.Hash(dto.Password),
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return new AuthResponse { Token = new TokenService().Generate(user) };
    }
}
