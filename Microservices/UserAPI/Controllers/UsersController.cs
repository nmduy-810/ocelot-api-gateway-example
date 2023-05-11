using Microsoft.AspNetCore.Mvc;
using UserAPI.Models;
using UserAPI.Services;

namespace UserAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> UserListAsync() => Ok(await _userService.GetUserListAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetUserById(int id) => Ok(await _userService.GetUserByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> AddUser(User user) => Ok(await _userService.AddUser(user));

    [HttpPut]
    public async Task<IActionResult> UpdateUser(User user) => Ok(await _userService.UpdateUser(user));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteUser(int id) => Ok(await _userService.DeleteUser(id));
}