using Microsoft.AspNetCore.Mvc;
using UniBlog.Application.DTO;
using UniBlog.Application.Interfaces;

namespace UniBlog.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
    {
        try
        {
            var authResponse = await _userService.RegisterUserAsync(registerUserDto);
            return Ok(authResponse);
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }   
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserDto loginUserDto)
    {
        try
        {
            var authResponse = await _userService.LoginUserAsync(loginUserDto);
            return Ok(authResponse);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("profile/{id}")]
    public async Task<IActionResult> UpdateProfile(int id, UpdateUserProfileDto updateUserProfileDto)
    {
        try
        {
            var user = await _userService.UpdateUserProfileAsync(id, updateUserProfileDto);
            return Ok(user);
        }catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }

    // [HttpPut("change-password")]
    // // [Authorize]
    // public async Task<IActionResult> ChangePassword(ChangeUserPasswordDto changeUserPasswordDto)
    // {
    //     // var userId = ... // get from token
    //     var userId = 1;
    //     await _userService.ChangeUserPasswordAsync(userId, changeUserPasswordDto);
    //     return Ok();
    // }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        try
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
}
