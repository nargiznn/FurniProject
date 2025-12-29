using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        void IEntityTypeConfiguration<Product>.Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.Property(m => m.Name)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(m => m.Slug)
                   .HasMaxLength(150)
                   .IsRequired();

            builder.HasIndex(m => m.Slug)
                   .IsUnique();

            builder.Property(m => m.Description)
                   .HasMaxLength(350)
                   .IsRequired();

            builder.Property(m => m.Price)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(m => m.Stock)
                   .IsRequired();

            builder.Property(m => m.IsFeatured)
                   .HasDefaultValue(false);

            builder.HasOne(m => m.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(m => m.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

