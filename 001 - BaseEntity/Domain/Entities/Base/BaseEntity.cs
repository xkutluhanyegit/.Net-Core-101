using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities.Base
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; //oluşturulma tarihi
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public string CreatedBy { get; set; } = ".net core 101";
        public string? UpdatedBy { get; set; }
        public string? DeletedBy { get; set; }
    }
}