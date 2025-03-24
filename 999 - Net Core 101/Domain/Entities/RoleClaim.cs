using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Base;
using Domain.Interfaces.Entity;

namespace Domain.Entities
{
    public class RoleClaim:BaseEntity,IEntity
    {
        public Guid RoleId { get; set; } // Rol Kimliği (Foreign Key)
        public Guid ClaimId { get; set; } // Yetki Kimliği (Foreign Key)

        public Role Role { get; set; } // Rol ile ilişki
        public Claim Claim { get; set; } // Yetki ile ilişki
    }
}