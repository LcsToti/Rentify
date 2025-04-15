using Microsoft.AspNetCore.Mvc;
using RentifyAPI.Dtos.Auth;
using RentifyAPI.Dtos.UserDtos;
using RentifyAPI.Services.UserServices;
using RentifyAPI.Services.Auth;

namespace RentifyAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService _authService = authService;

    [ProducesResponseType(typeof(GetUserDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem();
        }

        try
        {
            var response = await _authService.RegisterAsync(dto);

            return Created(string.Empty, new { response.Token });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception) // When needed, change to catach (Exception ex) to log the error message
        {
            return StatusCode(500, "Erro interno no servidor.");
        }
    }
}
