using RentifyAPI.Dtos.ResponseDtos;

namespace RentifyAPI.Dtos.Response
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