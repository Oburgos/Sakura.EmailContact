using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sakura.EmailContact.Features.Common;

namespace Sakura.EmailContact.Infrastructure.Maps
{
    public abstract class BaseMap<T>: IEntityTypeConfiguration<T> where T: BaseEntity
    {
        private readonly string tableName;

        public BaseMap(string tableName)
        {
            this.tableName = tableName;
        }

        protected abstract void ConfigureEntity(EntityTypeBuilder<T> builder);

        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.ToTable(tableName);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Active).HasDefaultValue(true);
            builder.Property(p => p.CreationDate).IsRequired();
            builder.Property(p => p.CreationTime).IsRequired();
            ConfigureEntity(builder);
        }
    }
}
