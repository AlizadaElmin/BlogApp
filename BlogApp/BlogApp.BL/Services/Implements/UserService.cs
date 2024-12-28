using AutoMapper;
using BlogApp.BL.DTOs.UserDtos;
using BlogApp.BL.Exceptions.UserExceptions;
using BlogApp.BL.Services.Interfaces;
using BlogApp.Core.Entities;
using BlogApp.Core.Repositories;

namespace BlogApp.BL.Services.Implements;

public class UserService(IMapper _mapper,IUserRepository _repo):IUserService
{
    public async Task<string> CreateAsync(UserCreateDto dto)
    {
        var existUser = await _repo.GetByUserNameAsync(dto.Username);
        if (existUser != null) throw new UserAlreadyExistsException();
        
       User user = _mapper.Map<User>(dto);
       await _repo.AddAsync(user);
       await _repo.SaveAsync();
       return user.Username;
    }

    public Task DeleteAsync(string username)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> LoginAsync(UserLoginDto dto)
    {
        var user = await _repo.GetByUserNameAsync(dto.Username);
        if (user == null) throw new UserNotFound();
        if (user.Username != dto.Username || user.PasswordHash != dto.Password) return false;
        return true;
    }
  
}