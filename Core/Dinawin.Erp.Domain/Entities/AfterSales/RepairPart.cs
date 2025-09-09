using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.AfterSales;

/// <summary>
/// قطعات تعمیرات
/// Repair Parts
/// </summary>
public class RepairPart : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه کسب و کار
    /// Business ID
    /// </summary>
    public Guid BusinessId { get; set; }

    /// <summary>
    /// شناسه محصول
    /// Product ID
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// شناسه خدمات تعمیرات
    /// Repair Service ID
    /// </summary>
    public Guid RepairServiceId { get; set; }

    /// <summary>
    /// تعداد مورد نیاز
    /// Required Quantity
    /// </summary>
    public decimal RequiredQuantity { get; set; }

    /// <summary>
    /// واحد اندازه گیری
    /// Unit of Measure
    /// </summary>
    public string Unit { get; set; } = string.Empty;

    /// <summary>
    /// آیا اجباری است
    /// Is Required
    /// </summary>
    public bool IsRequired { get; set; } = true;

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// قیمت واحد
    /// Unit Price
    /// </summary>
    public decimal? UnitPrice { get; set; }

    /// <summary>
    /// قیمت کل
    /// Total Price
    /// </summary>
    public decimal? TotalPrice { get; set; }

    // Navigation Properties
    /// <summary>
    /// محصول
    /// Product
    /// </summary>
    public virtual Product? Product { get; set; }

    /// <summary>
    /// خدمات تعمیرات
    /// Repair Service
    /// </summary>
    public virtual RepairService? RepairService { get; set; }
}

/// <summary>
/// پیکربندی موجودیت قطعات تعمیرات
/// Repair Part entity configuration
/// </summary>
public class RepairPartConfiguration : IEntityTypeConfiguration<RepairPart>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<RepairPart> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Unit)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Description)
            .HasMaxLength(1000);

        builder.Property(e => e.RequiredQuantity)
            .HasPrecision(18, 4);

        builder.Property(e => e.UnitPrice)
            .HasPrecision(18, 2);

        builder.Property(e => e.TotalPrice)
            .HasPrecision(18, 2);

        builder.HasOne(e => e.Product)
            .WithMany()
            .HasForeignKey(e => e.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.RepairService)
            .WithMany()
            .HasForeignKey(e => e.RepairServiceId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => e.ProductId);
        builder.HasIndex(e => e.RepairServiceId);
        builder.HasIndex(e => e.BusinessId);
    }
}
