using BlogApp.BL.DTOs.UserDtos;
using BlogApp.Core.Entities;

namespace BlogApp.BL.Services.Interfaces;

public interface IUserService
{
    Task<string> CreateAsync(UserCreateDto dto);
    Task<bool> LoginAsync(UserLoginDto dto);
    Task DeleteAsync(string username);
}