﻿using Application.Dtos;
using Application.Dtos.UserDtos;
using AutoMapper;
using Domain.Model;

namespace Application.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UpdateUserDto>();
            CreateMap<User, GetUserDto>();
            // Add other user-related mappings here } }
        }
    }
}