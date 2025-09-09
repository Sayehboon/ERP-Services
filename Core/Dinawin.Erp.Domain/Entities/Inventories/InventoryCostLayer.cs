using Dinawin.Erp.Domain.Common;

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
