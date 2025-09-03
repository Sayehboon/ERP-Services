using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dinawin.Erp.Domain.Entities.Products;

namespace Dinawin.Erp.Persistence.Configurations;

/// <summary>
/// پیکربندی موجودیت برند
/// Brand entity configuration
/// </summary>
public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    /// <summary>
    /// پیکربندی موجودیت برند
    /// Configure brand entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable("Brands", "Product");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(b => b.Description)
            .HasMaxLength(1000);

        builder.Property(b => b.LogoUrl)
            .HasMaxLength(500);

        builder.Property(b => b.Website)
            .HasMaxLength(500);

        builder.Property(b => b.SortOrder)
            .HasDefaultValue(0);

        // روابط
        builder.HasMany(b => b.Products)
            .WithOne(p => p.Brand)
            .HasForeignKey(p => p.BrandId)
            .OnDelete(DeleteBehavior.SetNull);

        // ایندکس‌ها
        builder.HasIndex(b => b.Name)
            .IsUnique()
            .HasDatabaseName("IX_Brands_Name");

        builder.HasIndex(b => b.SortOrder)
            .HasDatabaseName("IX_Brands_SortOrder");
    }
}
