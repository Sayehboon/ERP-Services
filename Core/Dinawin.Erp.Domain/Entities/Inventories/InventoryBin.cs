using Dinawin.Erp.Domain.Common;

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
