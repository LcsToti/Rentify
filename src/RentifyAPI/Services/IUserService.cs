using RentifyAPI.DTOs.User;

namespace RentifyAPI.Services
{
    public interface IUserService
    {
        Task<GetUserDTO> GetUserAsync(int id);
        Task<List<GetUserDTO>> GetUsersAsync();
        Task<GetUserDTO> CreateUserAsync(RegisterUserDTO dto);
    }
}
