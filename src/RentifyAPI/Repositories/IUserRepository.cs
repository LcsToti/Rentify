using RentifyAPI.Models;

namespace RentifyAPI.Repositories;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task<bool> EmailExistsAsync(string email);
    Task AddAsync(User user);
    Task<List<User>> GetAllUsersAsync();

    Task<User?> FindByIdAsync(int id);
}
