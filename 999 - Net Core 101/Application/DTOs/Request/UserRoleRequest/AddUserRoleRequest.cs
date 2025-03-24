using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.Request.UserRoleRequest
{
    public class AddUserRoleRequest
    {
        public Guid userId { get; set; }
        public Guid roleId { get; set; }
    }
}