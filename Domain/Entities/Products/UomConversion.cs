using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Products;

/// <summary>
/// موجودیت تبدیل واحد اندازه‌گیری
/// Unit of Measure Conversion entity
/// </summary>
public class UomConversion : BaseEntity
{
    /// <summary>
    /// شناسه واحد مبدا
    /// From unit ID
    /// </summary>
    public Guid FromUnitId { get; set; }

    /// <summary>
    /// شناسه واحد مقصد
    /// To unit ID
    /// </summary>
    public Guid ToUnitId { get; set; }

    /// <summary>
    /// شناسه واحد مبدا (نام مستعار)
    /// From UOM ID (alias)
    /// </summary>
    public Guid FromUomId => FromUnitId;

    /// <summary>
    /// شناسه واحد مقصد (نام مستعار)
    /// To UOM ID (alias)
    /// </summary>
    public Guid ToUomId => ToUnitId;

    /// <summary>
    /// ضریب تبدیل
    /// Conversion factor
    /// </summary>
    public decimal ConversionFactor { get; set; }

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// آیا فعال است
    /// Is active
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// واحد مبدا
    /// From unit
    /// </summary>
    public UnitOfMeasure FromUnit { get; set; } = null!;

    /// <summary>
    /// واحد مقصد
    /// To unit
    /// </summary>
    public UnitOfMeasure ToUnit { get; set; } = null!;

    /// <summary>
    /// واحد مبدا (نام مستعار)
    /// From UOM (alias)
    /// </summary>
    public UnitOfMeasure FromUom => FromUnit;

    /// <summary>
    /// واحد مقصد (نام مستعار)
    /// To UOM (alias)
    /// </summary>
    public UnitOfMeasure ToUom => ToUnit;

    /// <summary>
    /// نام تبدیل
    /// Conversion name
    /// </summary>
    public string Name { get; set; }
}

/// <summary>
/// پیکربندی موجودیت تبدیل واحد اندازه‌گیری
/// UOM Conversion entity configuration
/// </summary>
public class UomConversionConfiguration : IEntityTypeConfiguration<UomConversion>
{
    public void Configure(EntityTypeBuilder<UomConversion> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.ConversionFactor)
            .HasPrecision(18, 6);

        builder.Property(e => e.Description)
            .HasMaxLength(500);

        builder.HasOne(e => e.FromUnit)
            .WithMany()
            .HasForeignKey(e => e.FromUnitId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ToUnit)
            .WithMany()
            .HasForeignKey(e => e.ToUnitId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => new { e.FromUnitId, e.ToUnitId })
            .IsUnique();

        builder.HasIndex(e => e.IsActive);
    }
}