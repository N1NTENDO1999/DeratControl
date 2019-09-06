using System;
using System.Collections.Generic;
using System.Text;
using DeratControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeratControl.Infrastructure.EntitiesConfigurations
{
    class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.CreatedBy).HasMaxLength(40).IsRequired();

            builder.HasMany(o => o.ContactPeople).WithOne(p=>p.Organization).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(o => o.Facilities).WithOne(f=>f.Organization).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
