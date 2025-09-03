namespace Dinawin.Erp.Application.Features.Inventory.Queries.Dtos;

/// <summary>
/// DTO موجودی انبار
/// Inventory Data Transfer Object
/// </summary>
public class InventoryDto
{
    /// <summary>
    /// شناسه موجودی
    /// Inventory ID
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// شناسه کالا
    /// Product ID
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// نام کالا
    /// Product name
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// کد SKU کالا
    /// Product SKU
    /// </summary>
    public string ProductSku { get; set; } = string.Empty;

    /// <summary>
    /// شناسه انبار
    /// Warehouse ID
    /// </summary>
    public Guid WarehouseId { get; set; }

    /// <summary>
    /// نام انبار
    /// Warehouse name
    /// </summary>
    public string WarehouseName { get; set; } = string.Empty;

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
    public decimal AvailableQuantity { get; set; }

    /// <summary>
    /// میانگین موزون بهای تمام شده
    /// Weighted average cost
    /// </summary>
    public decimal? AvgCost { get; set; }

    /// <summary>
    /// آخرین قیمت خرید
    /// Last purchase cost
    /// </summary>
    public decimal? LastPurchaseCost { get; set; }

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
    public bool IsLowStock { get; set; }

    /// <summary>
    /// آیا نیاز به سفارش مجدد دارد
    /// Needs reorder
    /// </summary>
    public bool NeedsReorder { get; set; }

    /// <summary>
    /// تاریخ آخرین حرکت موجودی
    /// Last inventory movement date
    /// </summary>
    public DateTime? LastMovementDate { get; set; }

    /// <summary>
    /// تاریخ بروزرسانی
    /// Last update date
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}

/// <summary>
/// DTO انبار
/// Warehouse Data Transfer Object
/// </summary>
public class WarehouseDto
{
    /// <summary>
    /// شناسه انبار
    /// Warehouse ID
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// کد انبار
    /// Warehouse code
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// نام انبار
    /// Warehouse name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات انبار
    /// Warehouse description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// نوع انبار
    /// Warehouse type
    /// </summary>
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// ظرفیت انبار (متر مربع)
    /// Warehouse capacity (square meters)
    /// </summary>
    public decimal? Capacity { get; set; }

    /// <summary>
    /// وضعیت فعال/غیرفعال
    /// Active status
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// آیا انبار اصلی است
    /// Is main warehouse
    /// </summary>
    public bool IsMainWarehouse { get; set; }

    /// <summary>
    /// تاریخ ایجاد
    /// Creation date
    /// </summary>
    public DateTime CreatedAt { get; set; }
}

/// <summary>
/// DTO حرکت موجودی
/// Inventory movement Data Transfer Object
/// </summary>
public class InventoryMovementDto
{
    /// <summary>
    /// شناسه حرکت
    /// Movement ID
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// نام کالا
    /// Product name
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// نام انبار
    /// Warehouse name
    /// </summary>
    public string WarehouseName { get; set; } = string.Empty;

    /// <summary>
    /// نوع حرکت
    /// Movement type
    /// </summary>
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// مقدار حرکت
    /// Movement quantity
    /// </summary>
    public decimal Quantity { get; set; }

    /// <summary>
    /// قیمت واحد
    /// Unit cost
    /// </summary>
    public decimal? UnitCost { get; set; }

    /// <summary>
    /// مجموع ارزش حرکت
    /// Total movement value
    /// </summary>
    public decimal? TotalValue { get; set; }

    /// <summary>
    /// موجودی قبل از حرکت
    /// Balance before movement
    /// </summary>
    public decimal BalanceBefore { get; set; }

    /// <summary>
    /// موجودی بعد از حرکت
    /// Balance after movement
    /// </summary>
    public decimal BalanceAfter { get; set; }

    /// <summary>
    /// شماره مرجع
    /// Reference number
    /// </summary>
    public string? ReferenceNumber { get; set; }

    /// <summary>
    /// دلیل حرکت
    /// Movement reason
    /// </summary>
    public string Reason { get; set; } = string.Empty;

    /// <summary>
    /// یادداشت
    /// Notes
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// تاریخ حرکت
    /// Movement date
    /// </summary>
    public DateTime MovementDate { get; set; }

    /// <summary>
    /// تاریخ ایجاد
    /// Creation date
    /// </summary>
    public DateTime CreatedAt { get; set; }
}
