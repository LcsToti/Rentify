using RentifyAPI.Dtos;
using RentifyAPI.Dtos.UserDtos;

namespace RentifyAPI.Services.UserServices;
public interface IUserService
{
    Task<Response> GetUsersAsync();
    Task<GetUserDto?> GetUserAsync(int id);
}
