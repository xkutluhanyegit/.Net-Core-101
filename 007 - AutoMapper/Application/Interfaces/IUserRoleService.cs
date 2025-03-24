using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Request.UserRoleRequest;
using Domain.Utilities.Results.Interfaces;

namespace Application.Interfaces
{
    public interface IUserRoleService
    {
        Task<IResult> AddAsync(AddUserRoleRequest request);
    }
}