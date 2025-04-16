using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentifyAPI.Dtos.Auth;
using RentifyAPI.Dtos.UserDtos;
using RentifyAPI.Services.UserServices;

namespace RentifyAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [ProducesResponseType(typeof(List<GetUserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        [ProducesResponseType(typeof(GetUserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUserAsync(id);

            if (user is null)
            {
                return NotFound("Usuário não encontrado");
            }


            if (User.Identity.Name != user.Email && !User.IsInRole("Admin"))
            {
                return Forbid("Você não possui permissões para acessar este recurso.");
            }

            return Ok(user);
        }
    }
}
