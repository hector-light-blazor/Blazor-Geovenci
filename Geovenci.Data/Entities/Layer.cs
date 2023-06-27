using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geovenci.Data.Entities
{
    public class Layer : EntityBase 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public int MapProjectId { get; set; }

        [Column(TypeName = "geography")]
        public Geometry? Geometry { get; set; }

        public MapProject? MapProject { get; set; }  


        public ICollection<MapLayerUser> MapLayerUsers { get; set; }
    }
}
