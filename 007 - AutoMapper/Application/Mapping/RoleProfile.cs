using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Request.RoleRequest;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class RoleProfile:Profile
    {
        public RoleProfile()
        {
            CreateMap<Role,AddRoleRequest>();
            CreateMap<AddRoleRequest,Role>();
        }
    }
}