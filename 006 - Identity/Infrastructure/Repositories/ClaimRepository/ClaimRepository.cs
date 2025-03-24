using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Contexts.EntityFramework;
using Infrastructure.Repositories.GenericRepositoryBase;

namespace Infrastructure.Repositories.ClaimRepository
{
    public class ClaimRepository : GenericRepository<Claim>, IClaimRepository
    {
        public ClaimRepository(AppDbContext context) : base(context)
        {
        }
    }
}