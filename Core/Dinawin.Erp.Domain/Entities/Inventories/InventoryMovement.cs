using Dinawin.Erp.Domain.Common;

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
    public Guid? BinId { get; set; }
    public decimal? UnitPrice { get; set; }
    public string? ReferenceType { get; set; }
    public Guid? ReferenceId { get; set; }
}