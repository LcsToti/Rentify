using RentifyAPI.DTOs.User;
using RentifyAPI.Models;

namespace RentifyAPI.Utils.Mappers
{
    public class UserMapper
    {
        public static GetUserDTO ToDTO(User user)
        {
            return new GetUserDTO
            {
                Id = user.Id,
                Name = user.Name,
            };
        }
    } 
}
