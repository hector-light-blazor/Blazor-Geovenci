using Geovenci.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geovenci.Data
{
    public class GeovenciAppDbContext : DbContext
    {
        public DbSet<MapProject> MapProjects { get; set; }

        public DbSet<Layer> Layers { get; set; }
        public GeovenciAppDbContext(DbContextOptions<GeovenciAppDbContext> options) : base(options)
        {
            
        }
    }
}
