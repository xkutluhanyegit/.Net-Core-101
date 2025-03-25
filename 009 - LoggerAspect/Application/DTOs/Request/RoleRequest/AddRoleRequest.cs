using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.Request.RoleRequest
{
    public class AddRoleRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}