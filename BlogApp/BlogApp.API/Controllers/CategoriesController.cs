using BlogApp.BL.DTOs.CategoryDtos;
using BlogApp.BL.Services.Interfaces;
using BlogApp.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(ICategoryService _service):ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Post(CategoryCreateDto dto)
    {
        return Ok(await _service.CreateAsync(dto));
    }
}