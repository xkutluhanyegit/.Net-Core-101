using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Utilities.Results.Interfaces;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<IResult> AddUserAsync(User user);
        Task<IDataResult<IEnumerable<User>>> GetAllUserAsync();
    }
}