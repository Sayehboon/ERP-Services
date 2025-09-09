using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Products;

/// <summary>
/// تصاویر کالا مطابق Supabase
/// Product image entity based on Supabase schema
/// </summary>
public class ProductImage : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه کالا
    /// Product ID
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// آدرس تصویر
    /// Image URL
    /// </summary>
    public required string ImageUrl { get; set; }

    /// <summary>
    /// آیا تصویر اصلی است
    /// Is primary image
    /// </summary>
    public bool IsPrimary { get; set; }

    /// <summary>
    /// ناوبری به کالا
    /// Navigation to product
    /// </summary>
    public Product Product { get; set; } = null!;
}

/// <summary>
/// پیکربندی موجودیت تصویر کالا
/// ProductImage entity configuration
/// </summary>
public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.ImageUrl)
            .IsRequired()
            .HasMaxLength(1000);

        builder.HasOne(e => e.Product)
            .WithMany(p => p.Images)
            .HasForeignKey(e => e.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => new { e.ProductId, e.ImageUrl })
            .IsUnique();
    }
}


