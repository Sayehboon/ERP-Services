namespace Dinawin.Erp.Application.Features.Customers.Queries.GetCustomerTransactions;

/// <summary>
/// DTO تراکنش مشتری
/// </summary>
public class CustomerTransactionDto
{
    /// <summary>
    /// شناسه تراکنش
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// شناسه مشتری
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// نام مشتری
    /// </summary>
    public string CustomerName { get; set; } = string.Empty;

    /// <summary>
    /// نوع تراکنش
    /// </summary>
    public string TransactionType { get; set; } = string.Empty;

    /// <summary>
    /// نوع تراکنش به فارسی
    /// </summary>
    public string TransactionTypePersian { get; set; } = string.Empty;

    /// <summary>
    /// تاریخ تراکنش
    /// </summary>
    public DateTime TransactionDate { get; set; }

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
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// وضعیت تراکنش
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// وضعیت تراکنش به فارسی
    /// </summary>
    public string StatusPersian { get; set; } = string.Empty;

    /// <summary>
    /// شناسه کاربر ایجادکننده
    /// </summary>
    public Guid? CreatedBy { get; set; }

    /// <summary>
    /// نام کاربر ایجادکننده
    /// </summary>
    public string? CreatedByName { get; set; }

    /// <summary>
    /// تاریخ ایجاد
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// تاریخ آخرین به‌روزرسانی
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// مانده حساب قبل از تراکنش
    /// </summary>
    public decimal? BalanceBefore { get; set; }

    /// <summary>
    /// مانده حساب بعد از تراکنش
    /// </summary>
    public decimal? BalanceAfter { get; set; }

    /// <summary>
    /// شناسه صندوق نقدی
    /// </summary>
    public Guid? CashBoxId { get; set; }

    /// <summary>
    /// نام صندوق نقدی
    /// </summary>
    public string? CashBoxName { get; set; }

    /// <summary>
    /// شناسه حساب بانکی
    /// </summary>
    public Guid? BankAccountId { get; set; }

    /// <summary>
    /// نام حساب بانکی
    /// </summary>
    public string? BankAccountName { get; set; }

    /// <summary>
    /// شماره چک (در صورت پرداخت با چک)
    /// </summary>
    public string? CheckNumber { get; set; }

    /// <summary>
    /// تاریخ سررسید چک
    /// </summary>
    public DateTime? CheckDueDate { get; set; }

    /// <summary>
    /// شناسه بانک
    /// </summary>
    public Guid? BankId { get; set; }

    /// <summary>
    /// نام بانک
    /// </summary>
    public string? BankName { get; set; }
}
