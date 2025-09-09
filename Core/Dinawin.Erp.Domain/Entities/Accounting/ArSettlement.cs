using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Accounting;

/// <summary>
/// تسویه حساب‌های دریافتنی
/// Accounts Receivable Settlement
/// </summary>
public class ArSettlement : BaseEntity
{
    /// <summary>
    /// شناسه فاکتور
    /// Invoice ID
    /// </summary>
    public Guid InvoiceId { get; set; }

    /// <summary>
    /// شناسه دریافت
    /// Receipt ID
    /// </summary>
    public Guid ReceiptId { get; set; }

    /// <summary>
    /// مبلغ تسویه
    /// Settlement amount
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// تاریخ تسویه
    /// Settled at
    /// </summary>
    public DateTime SettledAt { get; set; } = DateTime.UtcNow;

    // Navigation Properties
    /// <summary>
    /// فاکتور مرتبط
    /// Related invoice
    /// </summary>
    public ArInvoice Invoice { get; set; } = null!;

    /// <summary>
    /// دریافت مرتبط
    /// Related receipt
    /// </summary>
    public ArReceipt Receipt { get; set; } = null!;
}
