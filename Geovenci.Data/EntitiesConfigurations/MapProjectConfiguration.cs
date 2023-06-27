using Geovenci.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geovenci.Data.EntitiesConfigurations
{
    public class MapProjectConfiguration : IEntityTypeConfiguration<MapProject>
    {
        public void Configure(EntityTypeBuilder<MapProject> builder)
        {
            builder.ToTable("MapProjects");

         
            builder.Property(x => x.Id).UseHiLo();

            builder.HasKey(x => x.Id);

            builder.HasMany(mp => mp.Layers)
               .WithOne(l => l.MapProject)
               .HasForeignKey(l => l.MapProjectId);

            builder.HasMany(mp => mp.MapLayerUsers)
                .WithOne(mlu => mlu.Project)
                .HasForeignKey(mlu => mlu.ProjectId);
        }
    }
}
