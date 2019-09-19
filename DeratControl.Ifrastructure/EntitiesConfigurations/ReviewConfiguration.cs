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

            builder.ToTable("Reviews");

            builder.Property(r => r.Date).IsRequired();
            
            builder
                .HasOne(r => r.Facility)
                .WithMany(f => f.Reviews)
                .HasForeignKey(k => k.FacilityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(o => o.ListOfTrapsToReview)
                .WithOne(c => c.Review)
                .HasForeignKey(c => c.ReviewId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(c => c.AssignedEmployee)
                .WithMany(c => c.Reviews)
                .HasForeignKey(c=>c.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
