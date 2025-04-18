namespace RentifyAPI.Dtos.ResponseDtos;

public abstract class BaseResponse
{
    protected BaseResponse() { }
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }
}
