using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geovenci.Data
{
    public abstract class EntityGeoBase
    {
        [Column(TypeName = "geography")]
        public Geometry? Geometry { get; set; }

    }
}
