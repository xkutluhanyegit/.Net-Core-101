using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Base;
using Domain.Interfaces.Entity;

namespace Domain.Entities
{
    public class UserClaim:BaseEntity,IEntity
    {
        public Guid UserId { get; set; } // Kullanıcı Kimliği (Foreign Key)
        public Guid ClaimId { get; set; } // Yetki Kimliği (Foreign Key)
        
        public DateTime AssignedAt { get; set; } = DateTime.UtcNow; // Yetkinin atandığı tarih
        public string AssignedBy { get; set; } // Yetkiyi atayan kişi veya sistem

        public User User { get; set; } // Kullanıcı ile ilişki
        public Claim Claim { get; set; } // Yetki ile ilişki
    }
}