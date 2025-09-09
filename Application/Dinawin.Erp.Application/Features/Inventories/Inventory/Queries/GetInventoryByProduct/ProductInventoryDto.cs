namespace Dinawin.Erp.Application.Features.Inventories.Inventories.Queries.GetInventoryByProduct;

/// <summary>
/// DTO موجودی محصول
/// </summary>
public class ProductInventoryDto
{
    /// <summary>
    /// شناسه محصول
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// نام محصول
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// کد محصول
    /// </summary>
    public string ProductCode { get; set; } = string.Empty;

    /// <summary>
    /// شناسه انبار
    /// </summary>
    public Guid? WarehouseId { get; set; }

    /// <summary>
    /// نام انبار
    /// </summary>
    public string? WarehouseName { get; set; }

    /// <summary>
    /// موجودی کل
    /// </summary>
    public decimal TotalQuantity { get; set; }

    /// <summary>
    /// موجودی رزرو شده
    /// </summary>
    public decimal ReservedQuantity { get; set; }

    /// <summary>
    /// موجودی قابل دسترس
    /// </summary>
    public decimal AvailableQuantity { get; set; }

    /// <summary>
    /// موجودی در راه
    /// </summary>
    public decimal InTransitQuantity { get; set; }

    /// <summary>
    /// حداقل موجودی
    /// </summary>
    public decimal MinStockLevel { get; set; }

    /// <summary>
    /// حداکثر موجودی
    /// </summary>
    public decimal MaxStockLevel { get; set; }

    /// <summary>
    /// نقطه سفارش مجدد
    /// </summary>
    public decimal ReorderPoint { get; set; }

    /// <summary>
    /// آیا موجودی کم است
    /// </summary>
    public bool IsLowStock { get; set; }

    /// <summary>
    /// آیا موجودی بیش از حد است
    /// </summary>
    public bool IsOverStock { get; set; }

    /// <summary>
    /// واحد اندازه‌گیری
    /// </summary>
    public string Unit { get; set; } = string.Empty;

    /// <summary>
    /// آخرین تاریخ به‌روزرسانی
    /// </summary>
    public DateTime? LastUpdated { get; set; }

    /// <summary>
    /// جزئیات موجودی در انبارهای مختلف
    /// </summary>
    public List<WarehouseInventoryDto> WarehouseInventories { get; set; } = new();
}

/// <summary>
/// DTO موجودی در انبار
/// </summary>
public class WarehouseInventoryDto
{
    /// <summary>
    /// شناسه انبار
    /// </summary>
    public Guid WarehouseId { get; set; }

    /// <summary>
    /// نام انبار
    /// </summary>
    public string WarehouseName { get; set; } = string.Empty;

    /// <summary>
    /// موجودی
    /// </summary>
    public decimal Quantity { get; set; }

    /// <summary>
    /// موجودی رزرو شده
    /// </summary>
    public decimal ReservedQuantity { get; set; }

    /// <summary>
    /// موجودی قابل دسترس
    /// </summary>
    public decimal AvailableQuantity { get; set; }

    /// <summary>
    /// آخرین تاریخ به‌روزرسانی
    /// </summary>
    public DateTime? LastUpdated { get; set; }
}
