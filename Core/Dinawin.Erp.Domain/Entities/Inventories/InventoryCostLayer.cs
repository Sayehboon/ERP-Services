using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Inventories;

/// <summary>
/// لایه هزینه موجودی
/// Inventory Cost Layer
/// </summary>
public class InventoryCostLayer : BaseEntity, IAggregateRoot
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
    /// تعداد در لایه
    /// Quantity in layer
    /// </summary>
    public decimal Quantity { get; set; }

    /// <summary>
    /// هزینه واحد
    /// Unit cost
    /// </summary>
    public decimal UnitCost { get; set; }

    /// <summary>
    /// هزینه کل
    /// Total cost
    /// </summary>
    public decimal TotalCost { get; set; }

    /// <summary>
    /// تاریخ ایجاد لایه
    /// Layer creation date
    /// </summary>
    public DateTime LayerDate { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// نوع لایه
    /// Layer type
    /// </summary>
    public string LayerType { get; set; } = string.Empty;

    /// <summary>
    /// شماره مرجع
    /// Reference number
    /// </summary>
    public string? ReferenceNumber { get; set; }

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string? Description { get; set; }

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
}

/// <summary>
/// پیکربندی موجودیت لایه هزینه موجودی
/// Inventory Cost Layer entity configuration
/// </summary>
public class InventoryCostLayerConfiguration : IEntityTypeConfiguration<InventoryCostLayer>
{
    public void Configure(EntityTypeBuilder<InventoryCostLayer> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.LayerType).HasMaxLength(50);
        builder.Property(e => e.ReferenceNumber).HasMaxLength(100);
        builder.Property(e => e.Description).HasMaxLength(1000);

        builder.Property(e => e.Quantity).HasPrecision(18, 4);
        builder.Property(e => e.UnitCost).HasPrecision(18, 2);
        builder.Property(e => e.TotalCost).HasPrecision(18, 2);

        builder.HasOne(e => e.Product)
            .WithMany()
            .HasForeignKey(e => e.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Warehouse)
            .WithMany()
            .HasForeignKey(e => e.WarehouseId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => e.ProductId);
        builder.HasIndex(e => e.WarehouseId);
        builder.HasIndex(e => e.LayerDate);
    }
}
