using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentifyAPI.Dtos.Response;
using RentifyAPI.Services.UserServices;

namespace RentifyAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class UsersController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [ProducesResponseType(typeof(UserListResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Users()
    {
        var response = await _userService.GetUsersAsync();
        return Ok(response);
    }

    [ProducesResponseType(typeof(SingleUserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(SingleUserResponse), StatusCodes.Status404NotFound)]
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UserById(int id)
    { 
        var response = await _userService.GetUserAsync(id);

        if (!response.Success)
        {
            return NotFound(response);
        }
        return Ok(response);
    }
}
