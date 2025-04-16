namespace RentifyAPI.Dtos.Auth;
public class AuthResponse
{
    public bool Success { get; set; }
    public string? Token { get; set; }
    public string? ErrorMessage { get; set; }
    public AuthFailureType? FailureType { get; set; }
}

public enum AuthFailureType
{
    InvalidEmail,
    InvalidPassword,
    EmailAlreadyExists
}