using Dinawin.Erp.Domain.Common;
using Dinawin.Erp.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Inventories;

/// <summary>
/// موجودیت موجودی انبار
/// Inventory entity
/// </summary>
public class Inventory : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه کالا
    /// Product ID
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// شناسه انبار
    /// Warehouse ID
    /// </summary>
    public Guid WarehouseId { get; set; }

    /// <summary>
    /// مقدار موجودی
    /// Current quantity
    /// </summary>
    public decimal Quantity { get; set; } = 0;

    /// <summary>
    /// حداقل موجودی هشدار
    /// Minimum stock alert level
    /// </summary>
    public decimal MinStockAlert { get; set; } = 0;

    /// <summary>
    /// شناسه قفسه
    /// Bin ID
    /// </summary>
    public Guid? BinId { get; set; }

    /// <summary>
    /// مقدار رزرو شده
    /// Reserved quantity
    /// </summary>
    public decimal ReservedQuantity { get; set; } = 0;

    /// <summary>
    /// حداقل مقدار
    /// Minimum quantity
    /// </summary>
    public decimal MinQuantity { get; set; } = 0;

    /// <summary>
    /// حداکثر مقدار
    /// Maximum quantity
    /// </summary>
    public decimal MaxQuantity { get; set; } = 0;

    /// <summary>
    /// قیمت واحد
    /// Unit price
    /// </summary>
    public decimal UnitPrice { get; set; } = 0;

    /// <summary>
    /// تاریخ انقضا
    /// Expiry date
    /// </summary>
    public DateTime? ExpiryDate { get; set; }

    /// <summary>
    /// شماره سریال
    /// Serial number
    /// </summary>
    public string SerialNumber { get; set; }

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string Description { get; set; }

    // Navigation Properties
    /// <summary>
    /// کالا
    /// Product
    /// </summary>
    public Product Product { get; set; } = null!;

    /// <summary>
    /// انبار
    /// Warehouse
    /// </summary>
    public Warehouse Warehouse { get; set; } = null!;

    /// <summary>
    /// قفسه
    /// Bin
    /// </summary>
    public Bin? Bin { get; set; }

    /// <summary>
    /// حرکات موجودی
    /// Inventory movements
    /// </summary>
    public ICollection<InventoryMovement> Movements { get; set; } = new List<InventoryMovement>();

    /// <summary>
    /// میانگین قیمت تمام شده
    /// Average cost
    /// </summary>
    public decimal AverageCost { get; set; } = 0;

    /// <summary>
    /// مقدار موجود
    /// Available quantity
    /// </summary>
    public decimal AvailableQuantity { get; set; }

    /// <summary>
    /// سطح سفارش مجدد
    /// Reorder level
    /// </summary>
    public decimal ReorderLevel { get; set; }

    /// <summary>
    /// هزینه واحد
    /// Unit cost
    /// </summary>
    public decimal UnitCost { get; set; }

    /// <summary>
    /// مقدار موجود قابل دسترس
    /// Quantity available
    /// </summary>
    public decimal QuantityAvailable { get; set; } = 0;

    /// <summary>
    /// مقدار رزرو شده
    /// Quantity reserved
    /// </summary>
    public decimal QuantityReserved { get; set; } = 0;

    /// <summary>
    /// مقدار موجود در دست
    /// Quantity on hand
    /// </summary>
    public decimal QuantityOnHand { get; set; } = 0;

    /// <summary>
    /// حداکثر سطح موجودی
    /// Max stock level
    /// </summary>
    public decimal MaxStockLevel { get; set; } = 0;

    /// <summary>
    /// نقطه سفارش مجدد
    /// Reorder point
    /// </summary>
    public decimal ReorderPoint { get; set; } = 0;

    /// <summary>
    /// موجودی ایمنی
    /// Safety stock
    /// </summary>
    public decimal SafetyStock { get; set; } = 0;
}

/// <summary>
/// پیکربندی موجودیت موجودی انبار
/// Inventory entity configuration
/// </summary>
public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Quantity).HasPrecision(18, 4);
        builder.Property(e => e.MinStockAlert).HasPrecision(18, 4);
        builder.Property(e => e.AverageCost).HasPrecision(18, 2);
        builder.Property(e => e.ReservedQuantity).HasPrecision(18, 4);
        builder.Property(e => e.MinQuantity).HasPrecision(18, 4);
        builder.Property(e => e.MaxQuantity).HasPrecision(18, 4);
        builder.Property(e => e.UnitPrice).HasPrecision(18, 2);
        builder.Property(e => e.SerialNumber).HasMaxLength(100);
        builder.Property(e => e.Description).HasMaxLength(1000);
        builder.Property(e => e.ReorderLevel).HasPrecision(18, 4);
        builder.Property(e => e.UnitCost).HasPrecision(18, 2);
        builder.Property(e => e.QuantityAvailable).HasPrecision(18, 4);
        builder.Property(e => e.QuantityReserved).HasPrecision(18, 4);
        builder.Property(e => e.QuantityOnHand).HasPrecision(18, 4);
        builder.Property(e => e.MaxStockLevel).HasPrecision(18, 4);
        builder.Property(e => e.ReorderPoint).HasPrecision(18, 4);
        builder.Property(e => e.SafetyStock).HasPrecision(18, 4);
        builder.Property(e => e.AvailableQuantity).HasPrecision(18, 4);

        builder.HasOne(e => e.Product)
            .WithMany(p => p.Inventories)
            .HasForeignKey(e => e.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Warehouse)
            .WithMany(w => w.Inventories)
            .HasForeignKey(e => e.WarehouseId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Bin)
            .WithMany()
            .HasForeignKey(e => e.BinId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

        builder.HasIndex(e => new { e.ProductId, e.WarehouseId })
            .IsUnique();
    }
}
