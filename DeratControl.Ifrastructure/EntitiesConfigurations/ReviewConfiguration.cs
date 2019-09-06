using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DeratControl.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeratControl.Infrastructure.EntitiesConfigurations
{
    class ReviewConfiguration : BaseEntityConfiguration<Review,int>
    {
        public override void Configure(EntityTypeBuilder<Review> builder)
        {
            base.Configure(builder);

            builder.Property(r => r.Date).IsRequired();

            builder.HasMany(o => o.ListOfTrapsToReview);
        }
    }
}
