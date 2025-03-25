using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Request.UserRoleRequest;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class UserRoleProfile:Profile
    {
        public UserRoleProfile()
        {
            CreateMap<UserRole,AddUserRoleRequest>();
            CreateMap<AddUserRoleRequest,UserRole>();
        }
    }
}