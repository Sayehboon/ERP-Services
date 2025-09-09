namespace Dinawin.Erp.Application.Features.Financial.CashBoxes.Queries.GetActiveCashBoxes;

/// <summary>
/// DTO صندوق نقدی
/// </summary>
public class CashBoxDto
{
    /// <summary>
    /// شناسه صندوق نقدی
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// نام صندوق نقدی
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// کد صندوق نقدی
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// آیا فعال است
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// شناسه شرکت
    /// </summary>
    public Guid? CompanyId { get; set; }

    /// <summary>
    /// نام شرکت
    /// </summary>
    public string? CompanyName { get; set; }

    /// <summary>
    /// شناسه بخش
    /// </summary>
    public Guid? DepartmentId { get; set; }

    /// <summary>
    /// نام بخش
    /// </summary>
    public string? DepartmentName { get; set; }

    /// <summary>
    /// موجودی فعلی
    /// </summary>
    public decimal CurrentBalance { get; set; }

    /// <summary>
    /// ارز
    /// </summary>
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// تاریخ ایجاد
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// تاریخ آخرین به‌روزرسانی
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}
