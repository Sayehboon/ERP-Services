using Dinawin.Erp.Domain.Common;
using Dinawin.Erp.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Inventories;

/// <summary>
/// موجودیت انبار
/// Warehouse entity
/// </summary>
public class Warehouse : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// کد انبار
    /// Warehouse code
    /// </summary>
    public required string Code { get; set; }

    /// <summary>
    /// نام انبار
    /// Warehouse name
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// توضیحات انبار
    /// Warehouse description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// آدرس انبار
    /// Warehouse address
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// موقعیت/لوکیشن (مطابق Supabase: location)
    /// Location (Supabase column: location)
    /// </summary>
    public string? Location { get; set; }

    /// <summary>
    /// نوع انبار
    /// Warehouse type
    /// </summary>
    public WarehouseType Type { get; set; }

    /// <summary>
    /// ظرفیت انبار (متر مربع)
    /// Warehouse capacity (square meters)
    /// </summary>
    public decimal? Capacity { get; set; }

    /// <summary>
    /// وضعیت فعال/غیرفعال
    /// Active status
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// آیا انبار اصلی است
    /// Is main warehouse
    /// </summary>
    public bool IsMainWarehouse { get; set; }

    /// <summary>
    /// شناسه مدیر انبار
    /// Warehouse manager ID
    /// </summary>
    public Guid? ManagerId { get; set; }

    /// <summary>
    /// شماره تلفن انبار
    /// Warehouse phone number
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// ایمیل انبار
    /// Warehouse email
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// شناسه کسب‌وکار
    /// Business ID
    /// </summary>
    public string BusinessId { get; set; } = "default";

    /// <summary>
    /// موجودی‌های انبار
    /// Warehouse inventories
    /// </summary>
    public ICollection<Inventory> Inventories { get; set; } = [];

    /// <summary>
    /// حرکات موجودی انبار
    /// Warehouse inventory movements
    /// </summary>
    public ICollection<InventoryMovement> InventoryMovements { get; set; } = [];
    public string? ManagerName { get; set; }
    public string? CapacityUnit { get; set; }
    public string? WarehouseType { get; set; }
}

/// <summary>
/// انواع انبار
/// Warehouse types
/// </summary>
public enum WarehouseType
{
    /// <summary>
    /// انبار مواد اولیه
    /// Raw materials warehouse
    /// </summary>
    RawMaterials = 1,

    /// <summary>
    /// انبار کالای تمام شده
    /// Finished goods warehouse
    /// </summary>
    FinishedGoods = 2,

    /// <summary>
    /// انبار قطعات
    /// Parts warehouse
    /// </summary>
    Parts = 3,

    /// <summary>
    /// انبار عمومی
    /// General warehouse
    /// </summary>
    General = 4,

    /// <summary>
    /// انبار موقت
    /// Temporary warehouse
    /// </summary>
    Temporary = 5,

    /// <summary>
    /// انبار مرجوعی
    /// Returns warehouse
    /// </summary>
    Returns = 6
}

/// <summary>
/// پیکربندی موجودیت انبار
/// Warehouse entity configuration
/// </summary>
public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<Warehouse> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Code)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(e => e.Description).HasMaxLength(1000);
        builder.Property(e => e.Address).HasMaxLength(500);
        builder.Property(e => e.Location).HasMaxLength(200);
        builder.Property(e => e.PhoneNumber).HasMaxLength(20);
        builder.Property(e => e.Email).HasMaxLength(100);
        builder.Property(e => e.ManagerName).HasMaxLength(150);
        builder.Property(e => e.CapacityUnit).HasMaxLength(20);
        builder.Property(e => e.WarehouseType).HasMaxLength(50);

        // Configure decimal properties with precision
        builder.Property(e => e.Capacity).HasPrecision(18, 4);

        builder.HasIndex(e => e.Code).IsUnique();
    }
}
