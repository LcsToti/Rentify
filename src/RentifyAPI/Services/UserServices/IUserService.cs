using RentifyAPI.Dtos.UserDtos;

namespace RentifyAPI.Services.UserServices;
public interface IUserService
{
    Task<GetUserDto?> GetUserAsync(int id);
    Task<List<GetUserDto>> GetUsersAsync();
}
