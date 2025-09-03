namespace Dinawin.Erp.Domain.Entities.Treasury;

using Dinawin.Erp.Domain.Common;

/// <summary>
/// موجودیت صندوق نقدی
/// Cash box entity
/// </summary>
public class CashBox : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// نام صندوق
    /// Cash box name
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// مکان صندوق
    /// Cash box location
    /// </summary>
    public string? Location { get; set; }

    /// <summary>
    /// شناسه کسب‌وکار
    /// Business ID
    /// </summary>
    public string BusinessId { get; set; } = "default";

    /// <summary>
    /// فعال است؟
    /// Is active?
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// تراکنش‌های نقدی این صندوق
    /// Cash transactions for this box
    /// </summary>
    public ICollection<CashTransaction> CashTransactions { get; set; } = new List<CashTransaction>();
}
