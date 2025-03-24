using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Request.RoleRequest;
using Domain.Entities;
using Domain.Utilities.Results.Interfaces;

namespace Application.Interfaces
{
    public interface IRoleService
    {
        Task<IDataResult<IEnumerable<Role>>> GetAllRolesAsync();
        Task<IResult> AddRoleAsync(AddRoleRequest request);
    }
}