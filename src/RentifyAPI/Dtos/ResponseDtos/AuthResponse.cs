using RentifyAPI.Dtos.ResponseDtos;
using RentifyAPI.Dtos.UserDtos;
using RentifyAPI.Dtos;

namespace RentifyAPI.Dtos.ResponseDtos
{
    public class AuthResponse
    {
    }
}
public class AuthResponse : BaseResponse
{
    public string? Token { get; set; }
    public AuthFailureType? FailureType { get; set; }
}
public enum AuthFailureType
{
    InvalidEmail,
    InvalidPassword,
    EmailAlreadyExists
}