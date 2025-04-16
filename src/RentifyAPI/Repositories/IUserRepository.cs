using RentifyAPI.Models;

namespace RentifyAPI.Repositories;

public interface IUserRepository
{
    Task<User> GetByEmail(string email);
    Task<bool> EmailExists(string email);
    Task Add(User user);
}
