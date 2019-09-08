using System;
using System.Collections.Generic;
using System.Text;
using DeratControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeratControl.Infrastructure.EntitiesConfigurations
{
    class FacilityConfiguration : BaseEntityConfiguration<Facility, int>
    {
        public override void Configure(EntityTypeBuilder<Facility> builder)
        {
            base.Configure(builder);

            builder.HasMany(f => f.Perimeters).WithOne(p => p.Facility).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(f => f.Reviews).WithOne(r => r.Facility).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(f => f.Organization).WithMany(o => o.Facilities);
        }
    }
}
