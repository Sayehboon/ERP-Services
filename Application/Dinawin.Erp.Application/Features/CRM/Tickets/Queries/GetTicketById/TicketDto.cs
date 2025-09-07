namespace Dinawin.Erp.Application.Features.CRM.Tickets.Queries.GetTicketById;

/// <summary>
/// DTO تیکت
/// </summary>
public class TicketDto
{
    /// <summary>
    /// شناسه تیکت
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// عنوان تیکت
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات تیکت
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// نوع تیکت
    /// </summary>
    public string TicketType { get; set; } = string.Empty;

    /// <summary>
    /// اولویت تیکت
    /// </summary>
    public string Priority { get; set; } = string.Empty;

    /// <summary>
    /// وضعیت تیکت
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// شناسه مشتری
    /// </summary>
    public Guid? CustomerId { get; set; }

    /// <summary>
    /// نام مشتری
    /// </summary>
    public string? CustomerName { get; set; }

    /// <summary>
    /// شناسه کاربر ایجاد کننده
    /// </summary>
    public Guid? CreatedById { get; set; }

    /// <summary>
    /// نام کاربر ایجاد کننده
    /// </summary>
    public string? CreatedByName { get; set; }

    /// <summary>
    /// شناسه کاربر مسئول
    /// </summary>
    public Guid? AssignedToId { get; set; }

    /// <summary>
    /// نام کاربر مسئول
    /// </summary>
    public string? AssignedToName { get; set; }

    /// <summary>
    /// شناسه محصول مرتبط
    /// </summary>
    public Guid? ProductId { get; set; }

    /// <summary>
    /// نام محصول مرتبط
    /// </summary>
    public string? ProductName { get; set; }

    /// <summary>
    /// شناسه سفارش فروش مرتبط
    /// </summary>
    public Guid? SalesOrderId { get; set; }

    /// <summary>
    /// شماره سفارش فروش مرتبط
    /// </summary>
    public string? SalesOrderNumber { get; set; }

    /// <summary>
    /// شناسه فرصت مرتبط
    /// </summary>
    public Guid? OpportunityId { get; set; }

    /// <summary>
    /// نام فرصت مرتبط
    /// </summary>
    public string? OpportunityName { get; set; }

    /// <summary>
    /// تاریخ مهلت
    /// </summary>
    public DateTime? DueDate { get; set; }

    /// <summary>
    /// تاریخ بسته شدن
    /// </summary>
    public DateTime? ClosedDate { get; set; }

    /// <summary>
    /// دلیل بسته شدن
    /// </summary>
    public string? CloseReason { get; set; }

    /// <summary>
    /// تگ‌ها
    /// </summary>
    public string? Tags { get; set; }

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
