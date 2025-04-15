using Microsoft.AspNetCore.Mvc;
using RentifyAPI.DTOs.User;
using RentifyAPI.Services;

namespace RentifyAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [ProducesResponseType(typeof(GetUserDTO), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        [ProducesResponseType(typeof(GetUserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUserAsync(id);
            if (user is null)
            {
                return NotFound("Usuário não encontrado");
            }
            return Ok(user);
        }

        [ProducesResponseType(typeof(GetUserDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] RegisterUserDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }

            try
            {
                var userDTO = await _userService.CreateUserAsync(dto);
                return CreatedAtAction(nameof(GetUser), new { id = userDTO.Id }, userDTO);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception) // TODO: Trocar pra uma Catch que faz sentido depois...
            {
                return StatusCode(500, "Erro interno no servidor.");
            }
        }
    }
}
