namespace Dinawin.Erp.Application.Features.Vendors.Queries.GetVendorOrders;

/// <summary>
/// DTO سفارش تامین‌کننده
/// </summary>
public class VendorOrderDto
{
    /// <summary>
    /// شناسه سفارش
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// شماره سفارش
    /// </summary>
    public string OrderNumber { get; set; } = string.Empty;

    /// <summary>
    /// شناسه تامین‌کننده
    /// </summary>
    public Guid VendorId { get; set; }

    /// <summary>
    /// نام تامین‌کننده
    /// </summary>
    public string VendorName { get; set; } = string.Empty;

    /// <summary>
    /// تاریخ سفارش
    /// </summary>
    public DateTime OrderDate { get; set; }

    /// <summary>
    /// تاریخ تحویل مورد انتظار
    /// </summary>
    public DateTime? ExpectedDeliveryDate { get; set; }

    /// <summary>
    /// تاریخ تحویل واقعی
    /// </summary>
    public DateTime? ActualDeliveryDate { get; set; }

    /// <summary>
    /// وضعیت سفارش
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// وضعیت سفارش به فارسی
    /// </summary>
    public string StatusPersian { get; set; } = string.Empty;

    /// <summary>
    /// نوع سفارش
    /// </summary>
    public string OrderType { get; set; } = string.Empty;

    /// <summary>
    /// مبلغ کل سفارش
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// مبلغ پرداخت شده
    /// </summary>
    public decimal PaidAmount { get; set; }

    /// <summary>
    /// مبلغ باقی‌مانده
    /// </summary>
    public decimal RemainingAmount => TotalAmount - PaidAmount;

    /// <summary>
    /// ارز
    /// </summary>
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// نرخ ارز
    /// </summary>
    public decimal? ExchangeRate { get; set; }

    /// <summary>
    /// مبلغ کل به ارز اصلی
    /// </summary>
    public decimal? TotalAmountInBaseCurrency { get; set; }

    /// <summary>
    /// تعداد اقلام سفارش
    /// </summary>
    public int ItemCount { get; set; }

    /// <summary>
    /// تعداد کل محصولات
    /// </summary>
    public decimal TotalQuantity { get; set; }

    /// <summary>
    /// درصد پیشرفت
    /// </summary>
    public decimal ProgressPercentage { get; set; }

    /// <summary>
    /// شناسه انبار مقصد
    /// </summary>
    public Guid? WarehouseId { get; set; }

    /// <summary>
    /// نام انبار مقصد
    /// </summary>
    public string? WarehouseName { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// یادداشت‌های داخلی
    /// </summary>
    public string? InternalNotes { get; set; }

    /// <summary>
    /// شناسه کاربر ایجادکننده
    /// </summary>
    public Guid? CreatedBy { get; set; }

    /// <summary>
    /// نام کاربر ایجادکننده
    /// </summary>
    public string? CreatedByName { get; set; }

    /// <summary>
    /// شناسه کاربر تاییدکننده
    /// </summary>
    public Guid? ApprovedBy { get; set; }

    /// <summary>
    /// نام کاربر تاییدکننده
    /// </summary>
    public string? ApprovedByName { get; set; }

    /// <summary>
    /// تاریخ تایید
    /// </summary>
    public DateTime? ApprovedAt { get; set; }

    /// <summary>
    /// تاریخ ایجاد
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// تاریخ آخرین به‌روزرسانی
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// اقلام سفارش
    /// </summary>
    public List<VendorOrderItemDto> Items { get; set; } = new();
}

/// <summary>
/// DTO آیتم سفارش تامین‌کننده
/// </summary>
public class VendorOrderItemDto
{
    /// <summary>
    /// شناسه آیتم
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
    /// مقدار سفارش
    /// </summary>
    public decimal Quantity { get; set; }

    /// <summary>
    /// مقدار تحویل شده
    /// </summary>
    public decimal DeliveredQuantity { get; set; }

    /// <summary>
    /// مقدار باقی‌مانده
    /// </summary>
    public decimal RemainingQuantity => Quantity - DeliveredQuantity;

    /// <summary>
    /// قیمت واحد
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// مبلغ کل
    /// </summary>
    public decimal TotalPrice => Quantity * UnitPrice;

    /// <summary>
    /// درصد تخفیف
    /// </summary>
    public decimal? DiscountPercentage { get; set; }

    /// <summary>
    /// مبلغ تخفیف
    /// </summary>
    public decimal? DiscountAmount { get; set; }

    /// <summary>
    /// مبلغ نهایی
    /// </summary>
    public decimal FinalAmount => TotalPrice - (DiscountAmount ?? 0);

    /// <summary>
    /// شناسه واحد اندازه‌گیری
    /// </summary>
    public Guid? UomId { get; set; }

    /// <summary>
    /// نام واحد اندازه‌گیری
    /// </summary>
    public string? UomName { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }
}
