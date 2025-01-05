using System.Security.Claims;
using BlogApp.BL.DTOs.UserDtos;
using BlogApp.BL.Services.Interfaces;
using BlogApp.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService _service):ControllerBase
{
    [HttpPost("[action]")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        await _service.RegisterAsync(dto);
        return Created();
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        return Ok(await _service.LoginAsync(dto));
    }
}