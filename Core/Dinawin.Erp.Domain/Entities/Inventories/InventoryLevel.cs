using Dinawin.Erp.Domain.Common;
using Dinawin.Erp.Domain.Entities.Products;

namespace Dinawin.Erp.Domain.Entities.Inventories;

/// <summary>
/// موجودیت سطوح موجودی انبار
/// Inventory Level entity for detailed level management
/// </summary>
public class InventoryLevel : BaseEntity, IAggregateRoot
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
    /// حداقل موجودی
    /// Minimum quantity
    /// </summary>
    public decimal? MinQty { get; set; }

    /// <summary>
    /// حداکثر موجودی
    /// Maximum quantity
    /// </summary>
    public decimal? MaxQty { get; set; }

    /// <summary>
    /// نقطه سفارش مجدد
    /// Reorder point
    /// </summary>
    public decimal? ReorderPoint { get; set; }

    /// <summary>
    /// موجودی ایمن
    /// Safety stock
    /// </summary>
    public decimal? SafetyStock { get; set; }

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
}