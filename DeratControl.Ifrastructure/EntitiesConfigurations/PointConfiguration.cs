using DeratControl.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Infrastructure.EntitiesConfigurations
{
    class PointConfiguration : BaseEntityConfiguration<Point, int>
    {
        public override void Configure(EntityTypeBuilder<Point> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Description).HasMaxLength(255);
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired();
            builder.Property(x => x.Order).HasMaxLength(255).IsRequired();
        }
    }
}
