using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Inventories;

/// <summary>
/// حرکت موجودی (کاردکس)
/// Inventory Movement (Kardex)
/// </summary>
public class InventoryMovement : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه محصول
    /// Product ID
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// شناسه انبار
    /// Warehouse ID
    /// </summary>
    public Guid WarehouseId { get; set; }

    /// <summary>
    /// جهت حرکت
    /// Movement direction
    /// </summary>
    public string Direction { get; set; } = string.Empty; // 'in' or 'out'

    /// <summary>
    /// تعداد
    /// Quantity
    /// </summary>
    public decimal Quantity { get; set; }

    /// <summary>
    /// هزینه واحد
    /// Unit cost
    /// </summary>
    public decimal? UnitCost { get; set; }

    /// <summary>
    /// هزینه کل
    /// Total cost
    /// </summary>
    public decimal? TotalCost { get; set; }

    /// <summary>
    /// موجودی باقیمانده
    /// Balance quantity
    /// </summary>
    public decimal BalanceQuantity { get; set; }

    /// <summary>
    /// میانگین هزینه موجودی
    /// Average cost of inventory
    /// </summary>
    public decimal? BalanceAverageCost { get; set; }

    /// <summary>
    /// تاریخ حرکت
    /// Movement date
    /// </summary>
    public DateTime MovementDate { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// نوع حرکت
    /// Movement type
    /// </summary>
    public string MovementType { get; set; } = string.Empty;

    /// <summary>
    /// نوع حرکت
    /// Movement type
    /// </summary>
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// شماره مرجع
    /// Reference number
    /// </summary>
    public string ReferenceNumber { get; set; }

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// مقدار کل
    /// Total value
    /// </summary>
    public decimal? TotalValue { get; set; }

    /// <summary>
    /// موجودی قبل از حرکت
    /// Balance before movement
    /// </summary>
    public decimal? BalanceBefore { get; set; }

    /// <summary>
    /// موجودی بعد از حرکت
    /// Balance after movement
    /// </summary>
    public decimal? BalanceAfter { get; set; }

    /// <summary>
    /// دلیل حرکت
    /// Movement reason
    /// </summary>
    public string Reason { get; set; }

    /// <summary>
    /// یادداشت‌ها
    /// Notes
    /// </summary>
    public string Notes { get; set; }

    // Navigation Properties
    /// <summary>
    /// محصول مرتبط
    /// Related product
    /// </summary>
    public Products.Product Product { get; set; } = null!;

    /// <summary>
    /// انبار مرتبط
    /// Related warehouse
    /// </summary>
    public Warehouse Warehouse { get; set; } = null!;

    /// <summary>
    /// شناسه مکان (بین)
    /// Bin ID
    /// </summary>
    public Guid? BinId { get; set; }

    /// <summary>
    /// قیمت واحد
    /// Unit price
    /// </summary>
    public decimal? UnitPrice { get; set; }

    /// <summary>
    /// نوع مرجع
    /// Reference type
    /// </summary>
    public string ReferenceType { get; set; }

    /// <summary>
    /// شناسه مرجع
    /// Reference ID
    /// </summary>
    public Guid? ReferenceId { get; set; }

    /// <summary>
    /// مکان (بین) مرتبط
    /// Related bin
    /// </summary>
    public Bin? Bin { get; set; }

    /// <summary>
    /// واحد اندازه‌گیری
    /// Unit of measure
    /// </summary>
    public string Unit { get; set; }

    /// <summary>
    /// قیمت کل
    /// Total price
    /// </summary>
    public decimal? TotalPrice { get; set; }

    /// <summary>
    /// شناسه موجودی
    /// Inventory ID
    /// </summary>
    public Guid? InventoryId { get; set; }
}

/// <summary>
/// پیکربندی موجودیت حرکت موجودی
/// Inventory Movement entity configuration
/// </summary>
public class InventoryMovementConfiguration : IEntityTypeConfiguration<InventoryMovement>
{
    public void Configure(EntityTypeBuilder<InventoryMovement> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Direction).HasMaxLength(10);
        builder.Property(e => e.MovementType).HasMaxLength(50);
        builder.Property(e => e.ReferenceNumber).HasMaxLength(100);
        builder.Property(e => e.Description).HasMaxLength(1000);
        builder.Property(e => e.ReferenceType).HasMaxLength(50);
        builder.Property(e => e.Reason).HasMaxLength(500);
        builder.Property(e => e.Notes).HasMaxLength(1000);
        builder.Property(e => e.Unit).HasMaxLength(50);

        builder.Property(e => e.Quantity).HasPrecision(18, 4);
        builder.Property(e => e.UnitCost).HasPrecision(18, 2);
        builder.Property(e => e.TotalCost).HasPrecision(18, 2);
        builder.Property(e => e.BalanceQuantity).HasPrecision(18, 4);
        builder.Property(e => e.BalanceAverageCost).HasPrecision(18, 2);
        builder.Property(e => e.UnitPrice).HasPrecision(18, 2);
        builder.Property(e => e.TotalValue).HasPrecision(18, 2);
        builder.Property(e => e.BalanceBefore).HasPrecision(18, 4);
        builder.Property(e => e.BalanceAfter).HasPrecision(18, 4);
        builder.Property(e => e.TotalPrice).HasPrecision(18, 2);

        builder.HasOne(e => e.Product)
            .WithMany(p => p.InventoryMovements)
            .HasForeignKey(e => e.ProductId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.Warehouse)
            .WithMany(w => w.InventoryMovements)
            .HasForeignKey(e => e.WarehouseId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.Bin)
            .WithMany()
            .HasForeignKey(e => e.BinId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasIndex(e => e.ProductId);
        builder.HasIndex(e => e.WarehouseId);
        builder.HasIndex(e => e.MovementDate);
        builder.HasIndex(e => e.MovementType);
    }
}
