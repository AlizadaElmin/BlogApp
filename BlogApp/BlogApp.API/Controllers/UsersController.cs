using BlogApp.BL.DTOs.UserDtos;
using BlogApp.BL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserService _service):ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(UserCreateDto dto)
    {
        return Ok(await _service.CreateAsync(dto));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginDto dto)
    {
        var result = await _service.LoginAsync(dto);
        if (result) return Ok(result);
        return BadRequest();
    }
}