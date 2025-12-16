using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
	{
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(m => m.Name).HasMaxLength(50).IsRequired();
            builder.HasIndex(m => m.Name).IsUnique();
        }
    }
}

