using DeratControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeratControl.Infrastructure.EntitiesConfigurations
{
    class TrapConfiguration: BaseEntityConfiguration<Trap,int>
    {
        public override void Configure(EntityTypeBuilder<Trap> builder)
        {
            base.Configure(builder);

            builder.ToTable("Traps");

            builder.Property(x => x.Data).HasMaxLength(50).IsRequired();
            builder.Property(x => x.TrapType).IsRequired();

            builder.HasOne(x => x.TrapPoint).WithOne(x => x.Trap);
        }
    }
}
