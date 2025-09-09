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
    /// حرکات موجودی
    /// Inventory movements
    /// </summary>
    public ICollection<InventoryMovement> Movements { get; set; } = new List<InventoryMovement>();
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

        builder.HasOne(e => e.Product)
            .WithMany(p => p.Inventories)
            .HasForeignKey(e => e.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Warehouse)
            .WithMany(w => w.Inventories)
            .HasForeignKey(e => e.WarehouseId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => new { e.ProductId, e.WarehouseId })
            .IsUnique();
    }
}
