using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PropertyNow.Core.Domain.Entities;

namespace PropertyNow.Infrastructure.Persistence.EntityConfigurations
{
    public class PropertyTypeEntityConfiguration : IEntityTypeConfiguration<PropertyType>
    {
        public void Configure(EntityTypeBuilder<PropertyType> builder)
        {
            builder.ToTable("PropertyTypes");

            builder.HasKey(pt => pt.Id);

            builder.Property(pt => pt.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(pt => pt.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasMany(pt => pt.Properties)
                   .WithOne(p => p.PropertyType)
                   .HasForeignKey("PropertyTypeId")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}