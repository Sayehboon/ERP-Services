using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Treasury;

/// <summary>
/// تطبیق بانکی
/// Bank Reconciliation
/// </summary>
public class BankReconciliation : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه حساب بانکی
    /// Bank account ID
    /// </summary>
    public Guid BankAccountId { get; set; }

    /// <summary>
    /// تاریخ تطبیق
    /// Reconciliation date
    /// </summary>
    public DateTime ReconciliationDate { get; set; }

    /// <summary>
    /// مانده دفتری
    /// Book balance
    /// </summary>
    public decimal BookBalance { get; set; }

    /// <summary>
    /// مانده بانکی
    /// Bank balance
    /// </summary>
    public decimal BankBalance { get; set; }

    /// <summary>
    /// اختلاف
    /// Difference
    /// </summary>
    public decimal Difference { get; set; }

    /// <summary>
    /// وضعیت
    /// Status
    /// </summary>
    public string Status { get; set; } = "draft";

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string? Description { get; set; }

    // Navigation Properties
    /// <summary>
    /// حساب بانکی مرتبط
    /// Related bank account
    /// </summary>
    public BankAccount BankAccount { get; set; } = null!;
}
