using Microsoft.AspNetCore.Mvc;
using RentifyAPI.Dtos;
using RentifyAPI.Dtos.Auth;
using RentifyAPI.Services.Auth;

namespace RentifyAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService _authService = authService;

    [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status401Unauthorized)]
    [Route("Login")]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem();
        }

        var response = await _authService.LoginAsync(dto);

        if(!response.Success)
        {
            if (response.FailureType == AuthFailureType.InvalidEmail)
            {
                return Unauthorized(response);
            }
            if (response.FailureType == AuthFailureType.InvalidPassword)
            {
                return Unauthorized(response);
            }
            return BadRequest("Ops! Erro inesperado no servidor.");
        }
        return Ok(response);
    }

    [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status409Conflict)]
    [Route("Register")]
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem();
        }

        var response = await _authService.RegisterAsync(dto);

        if (!response.Success)
        {
            if (response.FailureType == AuthFailureType.EmailAlreadyExists)
            {
                return Conflict(response);
            }
            return StatusCode(500, "Erro inesperado.");
        }

        return Created("/", response);
    }
}
