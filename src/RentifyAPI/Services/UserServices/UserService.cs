using RentifyAPI.Dtos.Response;
using RentifyAPI.Repositories;

namespace RentifyAPI.Services.UserServices;

public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<UserListResponse> GetUsersAsync()
    {
        var users = await _userRepository.GetAllUsersAsync();
        var userDtos = users.Select(u => new UserDTO(u)).ToList();

        return new UserListResponse 
        { 
            Success = true, 
            Users = userDtos 
        };
    }
    
    public async Task<SingleUserResponse> GetUserAsync(int id)
    {
        var user = await _userRepository.FindByIdAsync(id);

        if (user == null)
        {
            return new SingleUserResponse
            {
                Success = false,
                ErrorMessage = "Usuário não encontrado"
            };
        }

        var userDto = new UserDTO(user);

        return new SingleUserResponse
        {
            Success = true,
            User = userDto
        };

    }
}
