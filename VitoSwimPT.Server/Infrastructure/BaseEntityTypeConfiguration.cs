using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VitoSwimPT.Server.Infrastructure
{
    //public class BaseEntityTypeConfiguration
    public abstract class BaseEntityTypeConfiguration<T> : IEntityTypeConfiguration<T>
    where T : class
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property<DateTime>("InsertDateTime")
                .IsRequired()
                .HasDefaultValueSql("getdate()")
                .ValueGeneratedOnAdd();
            builder.Property<DateTime>("UpdateDateTime")
                .IsRequired()
                .HasDefaultValueSql("SYSDATETIME()")
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
