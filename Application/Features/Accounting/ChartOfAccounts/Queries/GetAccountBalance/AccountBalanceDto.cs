using Dinawin.Erp.Domain.Enums;

namespace Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.Queries.GetAccountBalance;

/// <summary>
/// DTO مانده حساب
/// </summary>
public class AccountBalanceDto
{
    /// <summary>
    /// شناسه حساب
    /// </summary>
    public Guid AccountId { get; set; }

    /// <summary>
    /// کد حساب
    /// </summary>
    public string AccountCode { get; set; } = string.Empty;

    /// <summary>
    /// نام حساب
    /// </summary>
    public string AccountName { get; set; } = string.Empty;

    /// <summary>
    /// نوع حساب
    /// </summary>
    public AccountTypeEnum AccountType { get; set; }

    /// <summary>
    /// دسته‌بندی حساب
    /// </summary>
    public string AccountCategory { get; set; } = string.Empty;

    /// <summary>
    /// مانده بدهکار
    /// </summary>
    public decimal DebitBalance { get; set; }

    /// <summary>
    /// مانده بستانکار
    /// </summary>
    public decimal CreditBalance { get; set; }

    /// <summary>
    /// مانده خالص
    /// </summary>
    public decimal NetBalance { get; set; }

    /// <summary>
    /// نوع مانده (بدهکار یا بستانکار)
    /// </summary>
    public string BalanceType { get; set; } = string.Empty;

    /// <summary>
    /// ارز
    /// </summary>
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// نرخ ارز
    /// </summary>
    public decimal? ExchangeRate { get; set; }

    /// <summary>
    /// مانده به ارز اصلی
    /// </summary>
    public decimal? BalanceInBaseCurrency { get; set; }

    /// <summary>
    /// تاریخ شروع دوره
    /// </summary>
    public DateTime? FromDate { get; set; }

    /// <summary>
    /// تاریخ پایان دوره
    /// </summary>
    public DateTime? ToDate { get; set; }

    /// <summary>
    /// تعداد تراکنش‌ها
    /// </summary>
    public int TransactionCount { get; set; }

    /// <summary>
    /// مبلغ کل بدهکار
    /// </summary>
    public decimal TotalDebit { get; set; }

    /// <summary>
    /// مبلغ کل بستانکار
    /// </summary>
    public decimal TotalCredit { get; set; }

    /// <summary>
    /// مانده اولیه
    /// </summary>
    public decimal OpeningBalance { get; set; }

    /// <summary>
    /// مانده نهایی
    /// </summary>
    public decimal ClosingBalance { get; set; }

    /// <summary>
    /// آیا شامل حساب‌های فرزند است
    /// </summary>
    public bool IncludesChildren { get; set; }

    /// <summary>
    /// تعداد حساب‌های فرزند
    /// </summary>
    public int ChildrenCount { get; set; }

    /// <summary>
    /// مانده‌های حساب‌های فرزند
    /// </summary>
    public List<AccountBalanceDto> ChildrenBalances { get; set; } = new();

    /// <summary>
    /// تاریخ آخرین تراکنش
    /// </summary>
    public DateTime? LastTransactionDate { get; set; }

    /// <summary>
    /// تاریخ محاسبه
    /// </summary>
    public DateTime CalculatedAt { get; set; } = DateTime.UtcNow;
}
