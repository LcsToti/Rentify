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


    public async Task<User> GetByEmail(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        return user;
    }


    public async Task<bool> EmailExists(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email == email);
    }

    public async Task Add(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }
}
