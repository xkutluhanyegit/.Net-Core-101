using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Contexts.EntityFramework;
using Infrastructure.Repositories.GenericRepositoryBase;

namespace Infrastructure.Repositories.RoleRepository
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(AppDbContext context) : base(context)
        {
        }
    }
}