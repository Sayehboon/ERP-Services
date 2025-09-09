using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Treasury;

/// <summary>
/// تراکنش بانکی
/// Bank Transaction
/// </summary>
public class BankTransaction : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه حساب بانکی
    /// Bank account ID
    /// </summary>
    public Guid BankAccountId { get; set; }

    /// <summary>
    /// تاریخ تراکنش
    /// Transaction date
    /// </summary>
    public DateTime TransactionDate { get; set; }

    /// <summary>
    /// نوع تراکنش
    /// Transaction type
    /// </summary>
    public string TransactionType { get; set; } = string.Empty;

    /// <summary>
    /// مبلغ
    /// Amount
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// ارز
    /// Currency
    /// </summary>
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// نرخ ارز
    /// Exchange rate
    /// </summary>
    public decimal? ExchangeRate { get; set; }

    /// <summary>
    /// مبلغ به ارز اصلی
    /// Amount in base currency
    /// </summary>
    public decimal? AmountInBaseCurrency { get; set; }

    /// <summary>
    /// شماره مرجع
    /// Reference number
    /// </summary>
    public string? ReferenceNumber { get; set; }

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// وضعیت
    /// Status
    /// </summary>
    public string Status { get; set; } = "pending";

    /// <summary>
    /// مانده قبل از تراکنش
    /// Balance before transaction
    /// </summary>
    public decimal? BalanceBefore { get; set; }

    /// <summary>
    /// مانده بعد از تراکنش
    /// Balance after transaction
    /// </summary>
    public decimal? BalanceAfter { get; set; }

    // Navigation Properties
    /// <summary>
    /// حساب بانکی مرتبط
    /// Related bank account
    /// </summary>
    public BankAccount BankAccount { get; set; } = null!;
}
