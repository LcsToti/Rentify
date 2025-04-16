namespace RentifyAPI.Dtos.UserDtos;

public class GetUserDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
}