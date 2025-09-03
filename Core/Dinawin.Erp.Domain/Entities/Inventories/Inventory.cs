using Dinawin.Erp.Domain.Common;
using Dinawin.Erp.Domain.Entities.Products;
using Dinawin.Erp.Domain.ValueObjects;

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
    public required Guid ProductId { get; set; }

    /// <summary>
    /// کالا
    /// Product
    /// </summary>
    public Product Product { get; set; } = null!;

    /// <summary>
    /// شناسه انبار
    /// Warehouse ID
    /// </summary>
    public required Guid WarehouseId { get; set; }

    /// <summary>
    /// انبار
    /// Warehouse
    /// </summary>
    public Warehouse Warehouse { get; set; } = null!;

    /// <summary>
    /// مقدار موجودی
    /// Current quantity
    /// </summary>
    public decimal Quantity { get; set; }

    /// <summary>
    /// مقدار رزروی
    /// Reserved quantity
    /// </summary>
    public decimal ReservedQuantity { get; set; }

    /// <summary>
    /// موجودی قابل فروش
    /// Available quantity for sale
    /// </summary>
    public decimal AvailableQuantity => Quantity - ReservedQuantity;

    /// <summary>
    /// میانگین موزون بهای تمام شده
    /// Weighted average cost
    /// </summary>
    public Money? AverageCost { get; set; }

    /// <summary>
    /// آخرین قیمت خرید
    /// Last purchase cost
    /// </summary>
    public Money? LastPurchaseCost { get; set; }

    /// <summary>
    /// حداقل موجودی هشدار
    /// Minimum stock alert level
    /// </summary>
    public decimal MinStockAlert { get; set; }

    /// <summary>
    /// حداکثر موجودی
    /// Maximum stock level
    /// </summary>
    public decimal MaxStockLevel { get; set; }

    /// <summary>
    /// نقطه سفارش مجدد
    /// Reorder point
    /// </summary>
    public decimal ReorderPoint { get; set; }

    /// <summary>
    /// موجودی ایمن
    /// Safety stock
    /// </summary>
    public decimal SafetyStock { get; set; }

    /// <summary>
    /// آیا در وضعیت کمبود موجودی است
    /// Is in low stock status
    /// </summary>
    public bool IsLowStock => MinStockAlert > 0 && AvailableQuantity <= MinStockAlert;

    /// <summary>
    /// آیا نیاز به سفارش مجدد دارد
    /// Needs reorder
    /// </summary>
    public bool NeedsReorder => ReorderPoint > 0 && AvailableQuantity <= ReorderPoint;

    /// <summary>
    /// تاریخ آخرین حرکت موجودی
    /// Last inventory movement date
    /// </summary>
    public DateTime? LastMovementDate { get; set; }

    /// <summary>
    /// حرکات موجودی
    /// Inventory movements
    /// </summary>
    public ICollection<InventoryMovement> Movements { get; set; } = new List<InventoryMovement>();
}
