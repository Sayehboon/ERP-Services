using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Products;

/// <summary>
/// فایل‌های پیوست کالا مطابق Supabase
/// Product file entity based on Supabase schema
/// </summary>
public class ProductFile : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه کالا
    /// Product ID
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// نام فایل
    /// File name
    /// </summary>
    public required string FileName { get; set; }

    /// <summary>
    /// آدرس فایل
    /// File URL
    /// </summary>
    public required string FileUrl { get; set; }

    /// <summary>
    /// نوع فایل
    /// File type
    /// </summary>
    public string FileType { get; set; }

    /// <summary>
    /// ناوبری به کالا
    /// Navigation to product
    /// </summary>
    public Product Product { get; set; } = null!;
}

/// <summary>
/// پیکربندی موجودیت فایل کالا
/// ProductFile entity configuration
/// </summary>
public class ProductFileConfiguration : IEntityTypeConfiguration<ProductFile>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<ProductFile> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.FileName)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(e => e.FileUrl)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(e => e.FileType)
            .HasMaxLength(100);

        builder.HasOne(e => e.Product)
            .WithMany(p => p.Files)
            .HasForeignKey(e => e.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => new { e.ProductId, e.FileUrl })
            .IsUnique();
    }
}


