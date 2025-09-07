namespace Dinawin.Erp.Application.Features.Financial.CashBoxes.Queries.GetAllCashBoxes;

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
    /// نام صندوق
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// کد صندوق
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// مکان صندوق
    /// </summary>
    public string? Location { get; set; }

    /// <summary>
    /// شناسه مسئول صندوق
    /// </summary>
    public Guid? ResponsiblePersonId { get; set; }

    /// <summary>
    /// نام مسئول صندوق
    /// </summary>
    public string? ResponsiblePersonName { get; set; }

    /// <summary>
    /// موجودی فعلی
    /// </summary>
    public decimal CurrentBalance { get; set; }

    /// <summary>
    /// ارز
    /// </summary>
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// آیا فعال است
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// تاریخ ایجاد
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// تاریخ آخرین به‌روزرسانی
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}
