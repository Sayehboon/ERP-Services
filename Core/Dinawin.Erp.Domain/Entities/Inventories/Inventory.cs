using Dinawin.Erp.Domain.Common;
using Dinawin.Erp.Domain.Entities.Products;

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
