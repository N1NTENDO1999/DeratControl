using DeratControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeratControl.Infrastructure.EntitiesConfigurations
{
    class TrapReviewConfiguration : BaseEntityConfiguration<TrapReview, int>
    {
        public override void Configure(EntityTypeBuilder<TrapReview> builder)
        {
            base.Configure(builder);

            builder.ToTable("TrapReviews");

            builder.Property(tr => tr.Comment).HasMaxLength(1000);
            builder.Property(tr => tr.TrapRewiewState).IsRequired();

            builder
                .HasOne(o => o.Point)
                .WithMany(r => r.ListOfReviews)
                .HasForeignKey(o => o.PointId);

            builder
                .HasMany(o => o.ListOfImages)
                .WithOne(r => r.TrapReview)
                .HasForeignKey(c => c.TrapReviewId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
