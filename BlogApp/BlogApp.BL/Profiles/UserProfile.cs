using AutoMapper;
using BlogApp.BL.DTOs.UserDtos;
using BlogApp.BL.Helpers;
using BlogApp.Core.Entities;
using BlogApp.Core.Enums;

namespace BlogApp.BL.Profiles;

public class UserProfile:Profile
{
    public UserProfile()
    {
        CreateMap<RegisterDto, User>()
            .ForMember(x => x.PasswordHash, opt => opt.MapFrom(y => HashHelper.HashPassword(y.Password)));
    }
}