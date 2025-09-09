using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Accounting;

/// <summary>
/// مشتری حساب‌های دریافتنی
/// Accounts Receivable Customer
/// </summary>
public class ArCustomer : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه کسب‌وکار
    /// Business ID
    /// </summary>
    public Guid BusinessId { get; set; }

    /// <summary>
    /// کد مشتری
    /// Customer code
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// نام مشتری
    /// Customer name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// شناسه مالیاتی
    /// Tax ID
    /// </summary>
    public string? TaxId { get; set; }

    /// <summary>
    /// حد اعتبار
    /// Credit limit
    /// </summary>
    public decimal CreditLimit { get; set; } = 0;

    /// <summary>
    /// فعال است؟
    /// Is active?
    /// </summary>
    public bool IsActive { get; set; } = true;

    // Navigation Properties
    /// <summary>
    /// فاکتورهای مشتری
    /// Customer invoices
    /// </summary>
    public ICollection<ArInvoice> Invoices { get; set; } = new List<ArInvoice>();

    /// <summary>
    /// دریافت‌های مشتری
    /// Customer receipts
    /// </summary>
    public ICollection<ArReceipt> Receipts { get; set; } = new List<ArReceipt>();
}
