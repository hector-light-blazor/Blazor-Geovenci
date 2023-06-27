using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geovenci.Data
{
    public abstract class EntityBase
    {
        [Required]
        public string CreatedBy { get; set; } = string.Empty;

        [Required]
        public DateTime CreatedAtUtc { get; set; }

    
        public string? UpdatedBy { get; set; } = string.Empty;

  
        public DateTime? UpdatedAtUtc { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
