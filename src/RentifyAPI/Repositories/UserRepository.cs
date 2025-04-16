using Microsoft.EntityFrameworkCore;
using RentifyAPI.Models;

namespace RentifyAPI.Repositories;

public class UserRepository : IUserRepository
{
    private readonly RentifyContext _context;
    public UserRepository(RentifyContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        return user;
    }


    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email == email);
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> FindByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }
}
