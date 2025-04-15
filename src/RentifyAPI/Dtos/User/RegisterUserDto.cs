using System.ComponentModel.DataAnnotations;

namespace RentifyAPI.Dtos.User;

public class RegisterUserDto
{
    [Required(ErrorMessage = "Nome é obrigatório")]
    [MinLength(5, ErrorMessage = "Nome deve ter pelo menos 5 dígitos")]
    [MaxLength(50, ErrorMessage = "Nome muito longo")]
    public required string Name { get; set; }
    
    [Required(ErrorMessage = "E-mail é obrigatório")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    [MaxLength(80, ErrorMessage = "E-mail muito longo")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Senha é obrigatória")]
    [MinLength(8, ErrorMessage = "Senha deve ter pelo menos 8 dígitos")]
    public required string Password { get; set; }
}