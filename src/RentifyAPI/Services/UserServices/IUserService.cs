using RentifyAPI.Dtos.Response;

namespace RentifyAPI.Services.UserServices;
public interface IUserService
{
    Task<UserListResponse> GetUsersAsync();
    Task<SingleUserResponse> GetUserAsync(int id);
}
