using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Geovenci.Data.Entities
{
    public class MapProject : EntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Extent { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;


        [Required]
        public DateTime ProjectStartDate { get; set; }

        [Required]

        public DateTime ProjectDueDate { get; set; }



        public ICollection<Layer> Layers { get; set; }
    }
}
