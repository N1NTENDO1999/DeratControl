using DeratControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeratControl.Infrastructure.EntitiesConfigurations
{
    class UserConfiguration : BaseEntityConfiguration<User, int>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.ToTable("Users");

            builder
                .Property(u => u.FirstName)
                .HasMaxLength(40)
                .IsRequired();

            builder
                .Property(u => u.LastName)
                .HasMaxLength(40)
                .IsRequired();

            builder
                .Property(u => u.Email)
                .HasMaxLength(40)
                .IsRequired();

            builder
                .HasOne(o => o.Organization)
                .WithMany(o => o.ContactPeople)
                .HasForeignKey(o => o.OrganizationId);
        }
    }
}
