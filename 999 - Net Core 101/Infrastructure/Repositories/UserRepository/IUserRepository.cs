using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.GenericRepositoryBase;

namespace Infrastructure.Repositories.UserRepository
{
    public interface IUserRepository:IGenericRepository<User>
    {
        Task<List<string>> GetUserRoleNameByUserId(Guid id);
    }
}