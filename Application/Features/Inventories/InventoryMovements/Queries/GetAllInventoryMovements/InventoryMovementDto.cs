namespace Dinawin.Erp.Application.Features.Inventories.InventoryMovements.Queries.GetAllInventoryMovements;

/// <summary>
/// مدل انتقال داده حرکت موجودی
/// </summary>
public sealed class InventoryMovementDto
{
    /// <summary>
    /// شناسه حرکت موجودی
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
    /// نوع حرکت
    /// </summary>
    public string MovementType { get; set; } = string.Empty;

    /// <summary>
    /// مقدار حرکت
    /// </summary>
    public decimal Quantity { get; set; }

    /// <summary>
    /// واحد اندازه‌گیری
    /// </summary>
    public string Unit { get; set; } = string.Empty;

    /// <summary>
    /// قیمت واحد
    /// </summary>
    public decimal? UnitPrice { get; set; }

    /// <summary>
    /// قیمت کل
    /// </summary>
    public decimal? TotalPrice { get; set; }

    /// <summary>
    /// تاریخ حرکت
    /// </summary>
    public DateTime MovementDate { get; set; }

    /// <summary>
    /// شماره سند مرجع
    /// </summary>
    public string ReferenceNumber { get; set; }

    /// <summary>
    /// نوع سند مرجع
    /// </summary>
    public string ReferenceType { get; set; }

    /// <summary>
    /// شناسه سند مرجع
    /// </summary>
    public Guid? ReferenceId { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string Description { get; set; }

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
