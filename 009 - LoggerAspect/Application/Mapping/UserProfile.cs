using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Request.AuthRequest;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User,RegisterRequest>();
            CreateMap<RegisterRequest,User>();

        }
    }
}