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
    public class MapLayerUserConfiguration : IEntityTypeConfiguration<MapLayerUser>
    {
        public void Configure(EntityTypeBuilder<MapLayerUser> builder)
        {
            builder.ToTable("MapLayerUsers");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Id);
            builder.HasIndex(x => x.ProjectId);
            builder.HasIndex(x => x.LayerId);
            builder.HasIndex(x => x.ApplicationUserId);

            builder.HasOne(ml => ml.Layer);
            builder.HasOne(ml => ml.Project);
            builder.HasOne(ml => ml.ApplicationUser);
        }
    }
}
