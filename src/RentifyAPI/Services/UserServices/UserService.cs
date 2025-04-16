using RentifyAPI.Models;
using RentifyAPI.Dtos.UserDtos;
using Microsoft.EntityFrameworkCore;
using RentifyAPI.Utils;

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
            .Select(u => new GetUserDto { Id = u.Id, Name = u.Name, Email = u.Email })
            .ToListAsync();
        return users;
    }
    
    public async Task<GetUserDto?> GetUserAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            throw new DirectoryNotFoundException("Usuário não encontrado");
        }
        return UserMapper.ToDTO(user);
    }
}
