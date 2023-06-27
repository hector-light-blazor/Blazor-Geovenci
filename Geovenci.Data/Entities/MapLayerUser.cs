using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geovenci.Data.Entities
{
    public class MapLayerUser
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }

        public int LayerId { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual Layer Layer {get; set;}

        public virtual MapProject Project { get; set; }

        public virtual ApplicationUser   ApplicationUser { get; set; }
    }
}
