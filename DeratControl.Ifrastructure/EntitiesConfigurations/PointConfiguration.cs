using DeratControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
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

            builder.ToTable("Points");

            builder.Property(x => x.Description).HasMaxLength(255);
            builder.Property(x => x.Order).IsRequired();

            builder
                .HasMany(p => p.ListOfReviews)
                .WithOne(t => t.Point)
                .HasForeignKey(c => c.PointId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(p => p.Perimeter)
                .WithMany(f => f.TrapPoints)
                .HasForeignKey(p => p.PerimeterId);

            builder
                .HasOne(p => p.Trap)
                .WithOne(f => f.TrapPoint)
                .HasForeignKey<Point>(e => e.TrapId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
