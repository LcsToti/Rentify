using System.ComponentModel.DataAnnotations;

namespace RentifyAPI.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [EmailAddress]
    [MaxLength(80)]
    public required string Email { get; set; }
    
    [Required]
    [MaxLength(255)]
    public required string PasswordHash { get; set; }
    
    public List<string> Roles { get; set; } = new() { "User" };

    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }
    
    public DateTime CreationDate { get; init; } = DateTime.Now;
}