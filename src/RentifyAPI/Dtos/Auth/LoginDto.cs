using System.ComponentModel.DataAnnotations;

namespace RentifyAPI.Dtos.Auth;

public class LoginDto
{
    [Required(ErrorMessage = "E-mail é obrigatório")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Senha é obrigatória")]
    public required string Password { get; set; }
}
