using DeratControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeratControl.Infrastructure.EntitiesConfigurations
{
    class TrapReviewImageConfiguration : BaseEntityConfiguration<TrapReview, int>
    {
        public override void Configure(EntityTypeBuilder<TrapReview> builder)
        {

        }
    }
}
