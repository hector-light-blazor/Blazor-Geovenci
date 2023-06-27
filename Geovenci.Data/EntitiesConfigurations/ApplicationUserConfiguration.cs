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
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasMany(a => a.MapLayerUsers)
                .WithOne(mlu => mlu.ApplicationUser)
                .HasForeignKey(mlu => mlu.ApplicationUserId);
        }
    }
}
