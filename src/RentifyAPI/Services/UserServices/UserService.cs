using RentifyAPI.Models;
using RentifyAPI.Dtos.UserDtos;
using RentifyAPI.Utils.Mappers;
using Microsoft.EntityFrameworkCore;
using RentifyAPI.Services.Auth;

namespace RentifyAPI.Services.UserServices;

public class UserService : IUserService
{
    private readonly RentifyContext _context;
    public UserService(RentifyContext context)
    {
        _context = context;
    }
    
    public async Task<List<GetUserDto>> GetUsersAsync()
    {
        var users = await _context.Users
            .Select(u => new GetUserDto { Id = u.Id, Name = u.Name })
            .ToListAsync();
        return users;
    }
    
    public async Task<GetUserDto?> GetUserAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        return user != null ? UserMapper.ToDTO(user) : null;
    }


    public async Task<GetUserDto> CreateUserAsync(RegisterUserDto dto)
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

        return new GetUserDto
        {
            Id = user.Id,
            Name = user.Name,
        };
    }
}
