using RentifyAPI.Dtos.UserDtos;
using RentifyAPI.Models;

namespace RentifyAPI.Utils;

public class UserMapper
{
    public static GetUserDto ToDTO(User user)
    {
        return new GetUserDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
        };
    }
} 
