namespace RentifyAPI.Dtos.ResponseDtos;

public class UserResponse : BaseResponse
{
    public UserResponse? User { get; set; }
    public List<UserResponse>? UsersList { get; set; }
}
