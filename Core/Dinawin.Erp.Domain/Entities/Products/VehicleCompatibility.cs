using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Products;

/// <summary>
/// سازگاری قطعه با خودروها مطابق Supabase
/// Vehicle compatibility for a product based on Supabase schema
/// </summary>
public class VehicleCompatibility : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه کالا
    /// Product ID
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// برند خودرو
    /// Vehicle brand
    /// </summary>
    public required string Brand { get; set; }

    /// <summary>
    /// مدل خودرو
    /// Vehicle model
    /// </summary>
    public required string Model { get; set; }

    /// <summary>
    /// بازه سال ساخت
    /// Year range
    /// </summary>
    public string? YearRange { get; set; }

    /// <summary>
    /// ناوبری به کالا
    /// Navigation to product
    /// </summary>
    public Product Product { get; set; } = null!;
}

/// <summary>
/// پیکربندی موجودیت سازگاری خودرو
/// VehicleCompatibility entity configuration
/// </summary>
public class VehicleCompatibilityConfiguration : IEntityTypeConfiguration<VehicleCompatibility>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<VehicleCompatibility> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Brand)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Model)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(e => e.YearRange)
            .HasMaxLength(50);

        builder.HasOne(e => e.Product)
            .WithMany(p => p.VehicleCompatibilities)
            .HasForeignKey(e => e.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => new { e.ProductId, e.Brand, e.Model, e.YearRange })
            .IsUnique();
    }
}


