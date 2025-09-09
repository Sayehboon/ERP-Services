using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Accounting;

/// <summary>
/// تامین‌کننده حساب‌های پرداختنی
/// Accounts Payable Vendor
/// </summary>
public class ApVendor : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه کسب‌وکار
    /// Business ID
    /// </summary>
    public Guid BusinessId { get; set; }

    /// <summary>
    /// کد تامین‌کننده
    /// Vendor code
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// نام تامین‌کننده
    /// Vendor name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// شناسه مالیاتی
    /// Tax ID
    /// </summary>
    public string? TaxId { get; set; }

    /// <summary>
    /// فعال است؟
    /// Is active?
    /// </summary>
    public bool IsActive { get; set; } = true;

    // Navigation Properties
    /// <summary>
    /// فاکتورهای تامین‌کننده
    /// Vendor bills
    /// </summary>
    public ICollection<ApBill> Bills { get; set; } = new List<ApBill>();

    /// <summary>
    /// پرداخت‌های تامین‌کننده
    /// Vendor payments
    /// </summary>
    public ICollection<ApPayment> Payments { get; set; } = new List<ApPayment>();
}
