using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Contexts.EntityFramework;
using Infrastructure.Repositories.GenericRepositoryBase;

namespace Infrastructure.Repositories.UserRoleRepository
{
    public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(AppDbContext context) : base(context)
        {
        }
    }
}