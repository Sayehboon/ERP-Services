namespace Dinawin.Erp.Application.Features.Inventories.Inventories.Queries.GetAllInventory;

/// <summary>
/// DTO موجودی
/// </summary>
public class InventoryDto
{
    /// <summary>
    /// شناسه موجودی
    /// </summary>
    public Guid Id { get; set; }

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
    public Guid WarehouseId { get; set; }

    /// <summary>
    /// نام انبار
    /// </summary>
    public string WarehouseName { get; set; } = string.Empty;

    /// <summary>
    /// شناسه مکان
    /// </summary>
    public Guid? BinId { get; set; }

    /// <summary>
    /// نام مکان
    /// </summary>
    public string BinName { get; set; }

    /// <summary>
    /// مقدار موجودی
    /// </summary>
    public decimal Quantity { get; set; }

    /// <summary>
    /// مقدار رزرو شده
    /// </summary>
    public decimal ReservedQuantity { get; set; }

    /// <summary>
    /// مقدار موجود
    /// </summary>
    public decimal AvailableQuantity => Quantity - ReservedQuantity;

    /// <summary>
    /// حداقل موجودی
    /// </summary>
    public decimal MinQuantity { get; set; }

    /// <summary>
    /// حداکثر موجودی
    /// </summary>
    public decimal MaxQuantity { get; set; }

    /// <summary>
    /// قیمت واحد
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// ارزش کل موجودی
    /// </summary>
    public decimal TotalValue => Quantity * UnitPrice;

    /// <summary>
    /// تاریخ انقضا
    /// </summary>
    public DateTime? ExpiryDate { get; set; }

    /// <summary>
    /// شماره سریال/بچ
    /// </summary>
    public string SerialNumber { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// آیا موجودی کم است
    /// </summary>
    public bool IsLowStock => Quantity <= MinQuantity;

    /// <summary>
    /// آیا منقضی شده است
    /// </summary>
    public bool IsExpired => ExpiryDate.HasValue && ExpiryDate.Value < DateTime.UtcNow;

    /// <summary>
    /// تاریخ ایجاد
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// تاریخ به‌روزرسانی
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// شناسه کاربر ایجاد کننده
    /// </summary>
    public Guid? CreatedBy { get; set; }

    /// <summary>
    /// شناسه کاربر به‌روزرسانی کننده
    /// </summary>
    public Guid? UpdatedBy { get; set; }
}
