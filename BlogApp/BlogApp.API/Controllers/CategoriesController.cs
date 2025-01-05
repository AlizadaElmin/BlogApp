using BlogApp.BL.DTOs.CategoryDtos;
using BlogApp.BL.Helpers;
using BlogApp.BL.Services.Interfaces;
using BlogApp.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(ICategoryService _service):ControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Post(CategoryCreateDto dto)
    {
        return Ok(await _service.CreateAsync(dto));
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> Byte(string value)
    {
        return Ok(HashHelper.HashPassword(value));
    }
    [HttpGet("[action]")]
    public async Task<IActionResult> Verify(string hash,string pass)
    {
        return Ok(HashHelper.VerifyHashedPassword(hash,pass));
    }
    
}