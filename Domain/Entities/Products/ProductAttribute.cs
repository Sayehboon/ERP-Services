using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Products;

/// <summary>
/// ویژگی‌های کالا مطابق اسکیما Supabase
/// Product attribute entity based on Supabase schema
/// </summary>
public class ProductAttribute : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه کالا
    /// Product ID
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// نام ویژگی
    /// Attribute name
    /// </summary>
    public required string AttributeName { get; set; }

    /// <summary>
    /// مقدار ویژگی
    /// Attribute value
    /// </summary>
    public required string AttributeValue { get; set; }

    /// <summary>
    /// ناوبری به کالا
    /// Navigation to product
    /// </summary>
    public Product Product { get; set; } = null!;
}

/// <summary>
/// پیکربندی موجودیت ویژگی‌های کالا
/// ProductAttribute entity configuration
/// </summary>
public class ProductAttributeConfiguration : IEntityTypeConfiguration<ProductAttribute>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<ProductAttribute> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.AttributeName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(e => e.AttributeValue)
            .IsRequired()
            .HasMaxLength(500);

        builder.HasOne(e => e.Product)
            .WithMany(p => p.Attributes)
            .HasForeignKey(e => e.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => new { e.ProductId, e.AttributeName })
            .IsUnique();
    }
}


