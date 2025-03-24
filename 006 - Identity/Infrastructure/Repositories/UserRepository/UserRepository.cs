using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Contexts.EntityFramework;
using Infrastructure.Repositories.GenericRepositoryBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace Infrastructure.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<string>> GetUserRoleNameByUserId(Guid id)
        {
            var result = await (from user in _context.Users
                            join userRole in _context.UserRoles on user.Id equals userRole.UserId
                            join role in _context.Roles on userRole.RoleId equals role.Id
                            where user.Id == id
                            select role.Name).ToListAsync();
            
            return result;
        }
    }
}