using DeratControl.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace DeratControl.Infrastructure.EntitiesConfigurations
{
    class PerimeterConfiguration : BaseEntityConfiguration<Perimeter, int>
    {
        public override void Configure(EntityTypeBuilder<Perimeter> builder)
        {
            base.Configure(builder);

            builder.ToTable("Perimeters");

            builder.Property(p => p.PerimeterType).IsRequired();

            builder
                .HasMany(p => p.TrapPoints)
                .WithOne(t => t.Perimeter)
                .HasForeignKey(c => c.PerimeterId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(p => p.Facility)
                .WithMany(f => f.Perimeters)
                .HasForeignKey(p => p.FacilityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
