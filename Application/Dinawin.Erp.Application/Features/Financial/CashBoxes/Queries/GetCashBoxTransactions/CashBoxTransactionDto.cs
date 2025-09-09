namespace Dinawin.Erp.Application.Features.Financial.CashBoxes.Queries.GetCashBoxTransactions;

/// <summary>
/// DTO تراکنش صندوق نقدی
/// </summary>
public class CashBoxTransactionDto
{
    /// <summary>
    /// شناسه تراکنش
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// شناسه صندوق نقدی
    /// </summary>
    public Guid? CashBoxId { get; set; }

    /// <summary>
    /// نام صندوق نقدی
    /// </summary>
    public string CashBoxName { get; set; } = string.Empty;

    /// <summary>
    /// تاریخ تراکنش
    /// </summary>
    public DateTime TransactionDate { get; set; }

    /// <summary>
    /// نوع تراکنش
    /// </summary>
    public string TransactionType { get; set; } = string.Empty;

    /// <summary>
    /// نوع تراکنش به فارسی
    /// </summary>
    public string TransactionTypePersian { get; set; } = string.Empty;

    /// <summary>
    /// مبلغ تراکنش
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// ارز
    /// </summary>
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// نرخ ارز
    /// </summary>
    public decimal? ExchangeRate { get; set; }

    /// <summary>
    /// مبلغ به ارز اصلی
    /// </summary>
    public decimal? AmountInBaseCurrency { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// شماره مرجع
    /// </summary>
    public string? ReferenceNumber { get; set; }

    /// <summary>
    /// نوع مرجع
    /// </summary>
    public string? ReferenceType { get; set; }

    /// <summary>
    /// شناسه مرجع
    /// </summary>
    public Guid? ReferenceId { get; set; }

    /// <summary>
    /// وضعیت تراکنش
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// وضعیت تراکنش به فارسی
    /// </summary>
    public string StatusPersian { get; set; } = string.Empty;

    /// <summary>
    /// مانده قبل از تراکنش
    /// </summary>
    public decimal? BalanceBefore { get; set; }

    /// <summary>
    /// مانده بعد از تراکنش
    /// </summary>
    public decimal? BalanceAfter { get; set; }

    /// <summary>
    /// شناسه کاربر ایجادکننده
    /// </summary>
    public Guid? CreatedBy { get; set; }

    /// <summary>
    /// نام کاربر ایجادکننده
    /// </summary>
    public string? CreatedByName { get; set; }

    /// <summary>
    /// شناسه کاربر تاییدکننده
    /// </summary>
    public Guid? ApprovedBy { get; set; }

    /// <summary>
    /// نام کاربر تاییدکننده
    /// </summary>
    public string? ApprovedByName { get; set; }

    /// <summary>
    /// تاریخ تایید
    /// </summary>
    public DateTime? ApprovedAt { get; set; }

    /// <summary>
    /// تاریخ ایجاد
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// تاریخ آخرین به‌روزرسانی
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// شناسه مشتری (در صورت تراکنش مشتری)
    /// </summary>
    public Guid? CustomerId { get; set; }

    /// <summary>
    /// نام مشتری
    /// </summary>
    public string? CustomerName { get; set; }

    /// <summary>
    /// شناسه تامین‌کننده (در صورت تراکنش تامین‌کننده)
    /// </summary>
    public Guid? VendorId { get; set; }

    /// <summary>
    /// نام تامین‌کننده
    /// </summary>
    public string? VendorName { get; set; }

    /// <summary>
    /// شناسه حساب بانکی (در صورت انتقال به بانک)
    /// </summary>
    public Guid? BankAccountId { get; set; }

    /// <summary>
    /// نام حساب بانکی
    /// </summary>
    public string? BankAccountName { get; set; }

    /// <summary>
    /// شناسه صندوق مقصد (در صورت انتقال بین صندوق‌ها)
    /// </summary>
    public Guid? TargetCashBoxId { get; set; }

    /// <summary>
    /// نام صندوق مقصد
    /// </summary>
    public string? TargetCashBoxName { get; set; }
}
