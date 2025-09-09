using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Accounting;

/// <summary>
/// دریافت حساب‌های دریافتنی
/// Accounts Receivable Receipt
/// </summary>
public class ArReceipt : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه کسب‌وکار
    /// Business ID
    /// </summary>
    public Guid BusinessId { get; set; }

    /// <summary>
    /// شناسه مشتری
    /// Customer ID
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// تاریخ دریافت
    /// Receipt date
    /// </summary>
    public DateTime ReceiptDate { get; set; }

    /// <summary>
    /// روش پرداخت
    /// Payment method
    /// </summary>
    public string? Method { get; set; }

    /// <summary>
    /// شناسه حساب بانکی
    /// Bank account ID
    /// </summary>
    public Guid? BankAccountId { get; set; }

    /// <summary>
    /// شناسه صندوق نقدی
    /// Cash box ID
    /// </summary>
    public Guid? CashBoxId { get; set; }

    /// <summary>
    /// ارز
    /// Currency
    /// </summary>
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// نرخ ارز
    /// Exchange rate
    /// </summary>
    public decimal ExchangeRate { get; set; } = 1;

    /// <summary>
    /// مبلغ
    /// Amount
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// وضعیت
    /// Status
    /// </summary>
    public string Status { get; set; } = "draft";

    /// <summary>
    /// پست شده؟
    /// Is posted?
    /// </summary>
    public bool Posted { get; set; } = false;

    /// <summary>
    /// تاریخ پست
    /// Posted at
    /// </summary>
    public DateTime? PostedAt { get; set; }

    // Navigation Properties
    /// <summary>
    /// مشتری مرتبط
    /// Related customer
    /// </summary>
    public ArCustomer Customer { get; set; } = null!;

    /// <summary>
    /// حساب بانکی مرتبط
    /// Related bank account
    /// </summary>
    public Treasury.BankAccount? BankAccount { get; set; }

    /// <summary>
    /// صندوق نقدی مرتبط
    /// Related cash box
    /// </summary>
    public Treasury.CashBox? CashBox { get; set; }

    /// <summary>
    /// تسویه‌های دریافت
    /// Receipt settlements
    /// </summary>
    public ICollection<ArSettlement> Settlements { get; set; } = new List<ArSettlement>();
}
