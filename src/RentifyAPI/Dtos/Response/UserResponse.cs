using RentifyAPI.Dtos.ResponseDtos;
using RentifyAPI.Models;

namespace RentifyAPI.Dtos.Response;

public class SingleUserResponse : BaseResponse
{
    public UserDTO? User { get; set; }
}

public class UserListResponse : BaseResponse
{
    public List<UserDTO> Users { get; set; } = [];
}

public class UserDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public UserDTO(User user)
    {
        Id = user.Id;
        Name = user.Name;
        Email = user.Email;
    }
}