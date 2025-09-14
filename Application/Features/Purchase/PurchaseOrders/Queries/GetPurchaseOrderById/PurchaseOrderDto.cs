namespace Dinawin.Erp.Application.Features.Purchase.PurchaseOrders.Queries.GetPurchaseOrderById;

/// <summary>
/// DTO سفارش خرید
/// </summary>
public class PurchaseOrderDto
{
    /// <summary>
    /// شناسه سفارش خرید
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// شماره سفارش خرید
    /// </summary>
    public string OrderNumber { get; set; } = string.Empty;

    /// <summary>
    /// شناسه تامین‌کننده
    /// </summary>
    public Guid VendorId { get; set; }

    /// <summary>
    /// نام تامین‌کننده
    /// </summary>
    public string VendorName { get; set; }

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
    /// نوع سفارش
    /// </summary>
    public string OrderType { get; set; }

    /// <summary>
    /// شناسه انبار
    /// </summary>
    public Guid? WarehouseId { get; set; }

    /// <summary>
    /// نام انبار
    /// </summary>
    public string WarehouseName { get; set; }

    /// <summary>
    /// شناسه کاربر مسئول
    /// </summary>
    public Guid? AssignedToId { get; set; }

    /// <summary>
    /// نام کاربر مسئول
    /// </summary>
    public string AssignedToName { get; set; }

    /// <summary>
    /// شناسه کاربر ایجاد کننده
    /// </summary>
    public Guid? CreatedById { get; set; }

    /// <summary>
    /// نام کاربر ایجاد کننده
    /// </summary>
    public string CreatedByName { get; set; }

    /// <summary>
    /// مبلغ کل سفارش
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// مبلغ تخفیف
    /// </summary>
    public decimal DiscountAmount { get; set; }

    /// <summary>
    /// مبلغ مالیات
    /// </summary>
    public decimal TaxAmount { get; set; }

    /// <summary>
    /// مبلغ نهایی
    /// </summary>
    public decimal FinalAmount { get; set; }

    /// <summary>
    /// ارز
    /// </summary>
    public string Currency { get; set; } = string.Empty;

    /// <summary>
    /// نرخ تبدیل ارز
    /// </summary>
    public decimal ExchangeRate { get; set; }

    /// <summary>
    /// روش پرداخت
    /// </summary>
    public string PaymentMethod { get; set; }

    /// <summary>
    /// شرایط پرداخت
    /// </summary>
    public string PaymentTerms { get; set; }

    /// <summary>
    /// آدرس تحویل
    /// </summary>
    public string DeliveryAddress { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string Notes { get; set; }

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