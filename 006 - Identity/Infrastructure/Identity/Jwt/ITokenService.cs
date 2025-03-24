using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Jwt
{
    public interface ITokenService
    {
        string GenerateToken(Guid userId, string email, List<string> roles);
        bool ValidateToken(string token);
    }
}