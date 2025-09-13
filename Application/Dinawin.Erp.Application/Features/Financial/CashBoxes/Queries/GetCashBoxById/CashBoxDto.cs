namespace Dinawin.Erp.Application.Features.Financial.CashBoxes.Queries.GetCashBoxById;

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
    /// مکان صندوق
    /// </summary>
    public string? Location { get; set; }

    /// <summary>
    /// شناسه کسب‌وکار
    /// </summary>
    public Guid? BusinessId { get; set; }

    /// <summary>
    /// شناسه حساب کنترل
    /// </summary>
    public Guid? ControlAccountId { get; set; }

    /// <summary>
    /// تاریخ ایجاد
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// تاریخ آخرین به‌روزرسانی
    /// </summary>
    public DateTime UpdatedAt { get; set; }
    public object CurrentBalance { get; set; }
    public object Currency { get; set; }
}
