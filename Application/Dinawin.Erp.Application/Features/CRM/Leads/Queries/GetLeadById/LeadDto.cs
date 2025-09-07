namespace Dinawin.Erp.Application.Features.CRM.Leads.Queries.GetLeadById;

/// <summary>
/// DTO لید
/// </summary>
public class LeadDto
{
    /// <summary>
    /// شناسه لید
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// نام لید
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// نام شرکت
    /// </summary>
    public string? CompanyName { get; set; }

    /// <summary>
    /// آدرس ایمیل
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// شماره تلفن
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// شماره موبایل
    /// </summary>
    public string? Mobile { get; set; }

    /// <summary>
    /// آدرس
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// شهر
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// استان
    /// </summary>
    public string? Province { get; set; }

    /// <summary>
    /// کد پستی
    /// </summary>
    public string? PostalCode { get; set; }

    /// <summary>
    /// منبع لید
    /// </summary>
    public string? LeadSource { get; set; }

    /// <summary>
    /// وضعیت لید
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// اولویت
    /// </summary>
    public string? Priority { get; set; }

    /// <summary>
    /// ارزش احتمالی
    /// </summary>
    public decimal? EstimatedValue { get; set; }

    /// <summary>
    /// تاریخ احتمالی بسته شدن
    /// </summary>
    public DateTime? ExpectedCloseDate { get; set; }

    /// <summary>
    /// شناسه کاربر مسئول
    /// </summary>
    public Guid? AssignedToId { get; set; }

    /// <summary>
    /// نام کاربر مسئول
    /// </summary>
    public string? AssignedToName { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Notes { get; set; }

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
