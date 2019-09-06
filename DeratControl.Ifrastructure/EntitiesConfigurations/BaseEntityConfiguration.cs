using System;
using System.Collections.Generic;
using System.Text;
using DeratControl.Domain.Root;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeratControl.Infrastructure.EntitiesConfigurations
{
   abstract class BaseEntityConfiguration<TEntity,TKey> : IEntityTypeConfiguration<TEntity> where TEntity : EntityBase<TKey>                                                                                            where TKey:struct
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreatedBy).HasMaxLength(40).IsRequired();
        }
    }
}
