using RentifyAPI.Dtos.User;

namespace RentifyAPI.Services
{
    public interface IUserService
    {
        Task<GetUserDto?> GetUserAsync(int id);
        Task<List<GetUserDto>> GetUsersAsync();
        Task<GetUserDto> CreateUserAsync(RegisterUserDto dto);
    }
}
