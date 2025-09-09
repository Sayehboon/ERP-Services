using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Inventories;

/// <summary>
/// بین موجودی
/// Inventory Bin
/// </summary>
public class InventoryBin : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه محصول
    /// Product ID
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// شناسه بین
    /// Bin ID
    /// </summary>
    public Guid BinId { get; set; }

    /// <summary>
    /// موجودی در بین
    /// Quantity in bin
    /// </summary>
    public decimal Quantity { get; set; } = 0;

    /// <summary>
    /// آخرین تاریخ به‌روزرسانی
    /// Last updated date
    /// </summary>
    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

    // Navigation Properties
    /// <summary>
    /// محصول مرتبط
    /// Related product
    /// </summary>
    public Products.Product Product { get; set; } = null!;

    /// <summary>
    /// بین مرتبط
    /// Related bin
    /// </summary>
    public Bin Bin { get; set; } = null!;
}

/// <summary>
/// پیکربندی موجودیت بین موجودی
/// Inventory Bin entity configuration
/// </summary>
public class InventoryBinConfiguration : IEntityTypeConfiguration<InventoryBin>
{
    public void Configure(EntityTypeBuilder<InventoryBin> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Quantity).HasColumnType("decimal(18,4)");

        builder.HasOne(e => e.Product)
            .WithMany()
            .HasForeignKey(e => e.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Bin)
            .WithMany()
            .HasForeignKey(e => e.BinId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => new { e.ProductId, e.BinId }).IsUnique();
        builder.HasIndex(e => e.LastUpdated);
    }
}
