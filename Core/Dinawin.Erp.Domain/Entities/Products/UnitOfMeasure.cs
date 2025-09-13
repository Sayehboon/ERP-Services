using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Products;

/// <summary>
/// موجودیت واحد اندازه‌گیری
/// Unit of Measure entity
/// </summary>
public class UnitOfMeasure : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// کد واحد
    /// Unit code
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// نام واحد
    /// Unit name
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// نماد واحد
    /// Unit symbol
    /// </summary>
    public string? Symbol { get; set; }

    /// <summary>
    /// توضیحات واحد
    /// Unit description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// نوع واحد
    /// Unit type
    /// </summary>
    public UnitType Type { get; set; }

    /// <summary>
    /// شناسه واحد پایه
    /// Base unit ID
    /// </summary>
    public Guid? BaseUnitId { get; set; }

    /// <summary>
    /// واحد پایه
    /// Base unit
    /// </summary>
    public UnitOfMeasure? BaseUnit { get; set; }

    /// <summary>
    /// واحد پایه (نام مستعار)
    /// Base UOM (alias)
    /// </summary>
    public UnitOfMeasure? BaseUom => BaseUnit;

    /// <summary>
    /// ضریب تبدیل به واحد پایه
    /// Conversion factor to base unit
    /// </summary>
    public decimal ConversionFactor { get; set; } = 1;

    /// <summary>
    /// دقت اعشار
    /// Decimal precision
    /// </summary>
    public int Precision { get; set; }

    /// <summary>
    /// وضعیت فعال/غیرفعال
    /// Active status
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// آیا واحد پیش‌فرض سیستم است
    /// Is system default unit
    /// </summary>
    public bool IsSystemDefault { get; set; }

    /// <summary>
    /// کالاهایی که از این واحد استفاده می‌کنند
    /// Products using this unit
    /// </summary>
    public ICollection<Product> Products { get; set; } = new List<Product>();

    /// <summary>
    /// واحدهای وابسته
    /// Dependent units
    /// </summary>
    public ICollection<UnitOfMeasure> DependentUnits { get; set; } = new List<UnitOfMeasure>();
    public string UomType { get; set; } = string.Empty;
    public string? UnitType { get; set; }
    public int SortOrder { get; set; }
}

/// <summary>
/// پیکربندی موجودیت واحد اندازه‌گیری
/// Unit of Measure entity configuration
/// </summary>
public class UnitOfMeasureConfiguration : IEntityTypeConfiguration<UnitOfMeasure>
{
    public void Configure(EntityTypeBuilder<UnitOfMeasure> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Code).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Name).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Symbol).HasMaxLength(20);
        builder.Property(e => e.Description).HasMaxLength(1000);
        builder.Property(e => e.UomType).HasMaxLength(50);
        builder.Property(e => e.UnitType).HasMaxLength(50);

        builder.Property(e => e.ConversionFactor).HasPrecision(18, 6);

        builder.HasOne(e => e.BaseUnit)
            .WithMany()
            .HasForeignKey(e => e.BaseUnitId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(e => e.Code).IsUnique(false);
        builder.HasIndex(e => e.Name);
        builder.HasIndex(e => e.Type);
    }
}

/// <summary>
/// انواع واحد اندازه‌گیری
/// Unit of measure types
/// </summary>
public enum UnitType
{
    /// <summary>
    /// طول
    /// Length
    /// </summary>
    Length = 1,

    /// <summary>
    /// وزن
    /// Weight
    /// </summary>
    Weight = 2,

    /// <summary>
    /// حجم
    /// Volume
    /// </summary>
    Volume = 3,

    /// <summary>
    /// مساحت
    /// Area
    /// </summary>
    Area = 4,

    /// <summary>
    /// تعداد
    /// Count
    /// </summary>
    Count = 5,

    /// <summary>
    /// زمان
    /// Time
    /// </summary>
    Time = 6
}
