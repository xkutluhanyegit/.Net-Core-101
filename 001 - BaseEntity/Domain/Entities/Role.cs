using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Base;
using Domain.Interfaces.Entity;

namespace Domain.Entities
{
    public class Role:BaseEntity,IEntity
    {
        public string Name { get; set; } // Rol Adı (örn: "Admin", "User", "Moderator")
        public string Description { get; set; } // Rol Açıklaması (Opsiyonel)

        public ICollection<UserRole> UserRoles { get; set; } // Rolün hangi kullanıcılara ait olduğunu tutar
        public ICollection<RoleClaim> RoleClaims { get; set; } // Role ait yetkilendirmeleri tutar
    }
}