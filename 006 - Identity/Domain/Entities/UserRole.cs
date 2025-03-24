using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Base;
using Domain.Interfaces.Entity;

namespace Domain.Entities
{
    public class UserRole:BaseEntity,IEntity
    {
        public Guid UserId { get; set; } // Kullanıcı Kimliği (Foreign Key)
        public Guid RoleId { get; set; } // Rol Kimliği (Foreign Key)

        public User User { get; set; } // Kullanıcı ile ilişki
        public Role Role { get; set; } // Rol ile ilişki
    }
}