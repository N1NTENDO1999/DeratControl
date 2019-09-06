using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DeratControl.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeratControl.Infrastructure.EntitiesConfigurations
{
    class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.CreatedBy).HasMaxLength(40).IsRequired();

            builder.Property(r => r.Date).IsRequired();

            builder.HasMany(o => o.ListOfTrapsToReview);
        }
    }
}
