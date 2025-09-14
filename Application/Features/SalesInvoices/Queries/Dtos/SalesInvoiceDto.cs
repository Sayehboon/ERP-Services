namespace Dinawin.Erp.Application.Features.SalesInvoices.Queries.Dtos;

/// <summary>
/// DTO فاکتور فروش
/// Sales invoice Data Transfer Object
/// </summary>
public class SalesInvoiceDto
{
    /// <summary>
    /// شناسه فاکتور
    /// Invoice ID
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// شماره فاکتور
    /// Invoice number
    /// </summary>
    public string Number { get; set; }

    /// <summary>
    /// تاریخ فاکتور
    /// Invoice date
    /// </summary>
    public DateTime InvoiceDate { get; set; }

    /// <summary>
    /// شناسه مشتری
    /// Customer ID
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// نام مشتری
    /// Customer name
    /// </summary>
    public string CustomerName { get; set; } = string.Empty;

    /// <summary>
    /// مجموع کل فاکتور
    /// Total amount
    /// </summary>
    public decimal Total { get; set; }

    /// <summary>
    /// مالیات
    /// Tax amount
    /// </summary>
    public decimal Tax { get; set; }

    /// <summary>
    /// تخفیف
    /// Discount amount
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// یادداشت
    /// Notes
    /// </summary>
    public string Notes { get; set; }

    /// <summary>
    /// وضعیت فاکتور
    /// Invoice status
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// تاریخ ایجاد
    /// Creation date
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// تاریخ بروزرسانی
    /// Last update date
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    /// <summary>
    /// آیا فاکتور ثبت شده است
    /// Is invoice posted
    /// </summary>
    public bool IsPosted => Status.ToLower() == "posted";

    /// <summary>
    /// آیا فاکتور پیش‌نویس است
    /// Is invoice draft
    /// </summary>
    public bool IsDraft => Status.ToLower() == "draft";
}
