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

            builder.ToTable("Facilities");

            builder
                .HasMany(f => f.Perimeters)
                .WithOne(p => p.Facility)
                .HasForeignKey(c => c.FacilityId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(f => f.Organization)
                .WithMany(o => o.Facilities)
                .HasForeignKey(o => o.OrganizationId);

            builder
                .HasMany(f => f.Reviews)
                .WithOne(r => r.Facility)
                .HasForeignKey(c => c.FacilityId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
