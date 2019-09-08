using DeratControl.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeratControl.Infrastructure.EntitiesConfigurations
{
    class TrapConfiguration: BaseEntityConfiguration<Trap,int>
    {
        public override void Configure(EntityTypeBuilder<Trap> builder)
        {
            base.Configure(builder);
        }
    }
}
