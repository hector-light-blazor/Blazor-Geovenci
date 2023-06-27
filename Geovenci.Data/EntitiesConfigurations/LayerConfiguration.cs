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
    public class LayerConfiguration : IEntityTypeConfiguration<Layer>
    {
        

        public void Configure(EntityTypeBuilder<Layer> builder)
        {
            builder.ToTable("Layers");

            builder.HasKey(x => x.Id);

            builder.HasMany(l => l.MapLayerUsers)
                .WithOne(mlu => mlu.Layer)
                .HasForeignKey(mlu => mlu.LayerId);

          
        }
    }
}
