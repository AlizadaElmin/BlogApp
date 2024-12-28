using AutoMapper;
using BlogApp.BL.DTOs.UserDtos;
using BlogApp.Core.Entities;

namespace BlogApp.BL.Profiles;

public class UserProfile:Profile
{
    public UserProfile()
    {
        CreateMap<UserCreateDto, User>()
            .ForMember(x=>x.PasswordHash,opt=>opt.MapFrom(y=>y.Password));
    }
}