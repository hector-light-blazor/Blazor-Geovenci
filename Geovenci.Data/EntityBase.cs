using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geovenci.Data
{
    public class EntityBase
    {
        [Required]
        public string CreatedBy { get; set; } = string.Empty;

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public string UpdatedBy { get; set; } = string.Empty;

        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}
