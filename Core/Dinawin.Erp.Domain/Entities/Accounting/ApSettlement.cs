using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Accounting;

/// <summary>
/// تسویه حساب‌های پرداختنی
/// Accounts Payable Settlement
/// </summary>
public class ApSettlement : BaseEntity
{
    /// <summary>
    /// شناسه فاکتور
    /// Bill ID
    /// </summary>
    public Guid BillId { get; set; }

    /// <summary>
    /// شناسه پرداخت
    /// Payment ID
    /// </summary>
    public Guid PaymentId { get; set; }

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
    /// Related bill
    /// </summary>
    public ApBill Bill { get; set; } = null!;

    /// <summary>
    /// پرداخت مرتبط
    /// Related payment
    /// </summary>
    public ApPayment Payment { get; set; } = null!;
}
