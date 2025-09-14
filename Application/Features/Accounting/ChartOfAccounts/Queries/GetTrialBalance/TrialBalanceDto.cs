using Dinawin.Erp.Domain.Enums;

namespace Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.Queries.GetTrialBalance;

/// <summary>
/// DTO تراز آزمایشی
/// </summary>
public class TrialBalanceDto
{
    /// <summary>
    /// تاریخ شروع دوره
    /// </summary>
    public DateTime? FromDate { get; set; }

    /// <summary>
    /// تاریخ پایان دوره
    /// </summary>
    public DateTime? ToDate { get; set; }

    /// <summary>
    /// تاریخ تهیه تراز
    /// </summary>
    public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// ارز
    /// </summary>
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// تعداد کل حساب‌ها
    /// </summary>
    public int TotalAccounts { get; set; }

    /// <summary>
    /// تعداد حساب‌های با مانده غیر صفر
    /// </summary>
    public int NonZeroBalanceAccounts { get; set; }

    /// <summary>
    /// مجموع بدهکار
    /// </summary>
    public decimal TotalDebit { get; set; }

    /// <summary>
    /// مجموع بستانکار
    /// </summary>
    public decimal TotalCredit { get; set; }

    /// <summary>
    /// تفاوت تراز (باید صفر باشد)
    /// </summary>
    public decimal BalanceDifference => TotalDebit - TotalCredit;

    /// <summary>
    /// آیا تراز متعادل است
    /// </summary>
    public bool IsBalanced => Math.Abs(BalanceDifference) < 0.01m;

    /// <summary>
    /// اقلام تراز آزمایشی
    /// </summary>
    public List<TrialBalanceItemDto> Items { get; set; } = new();

    /// <summary>
    /// خلاصه بر اساس نوع حساب
    /// </summary>
    public List<TrialBalanceSummaryDto> SummaryByType { get; set; } = new();

    /// <summary>
    /// خلاصه بر اساس دسته‌بندی حساب
    /// </summary>
    public List<TrialBalanceSummaryDto> SummaryByCategory { get; set; } = new();
}

/// <summary>
/// DTO آیتم تراز آزمایشی
/// </summary>
public class TrialBalanceItemDto
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
    /// سطح حساب
    /// </summary>
    public int Level { get; set; }

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
    /// تاریخ آخرین تراکنش
    /// </summary>
    public DateTime? LastTransactionDate { get; set; }

    /// <summary>
    /// آیا فعال است
    /// </summary>
    public bool IsActive { get; set; }
}

/// <summary>
/// DTO خلاصه تراز آزمایشی
/// </summary>
public class TrialBalanceSummaryDto
{
    /// <summary>
    /// نام گروه
    /// </summary>
    public string GroupName { get; set; } = string.Empty;

    /// <summary>
    /// تعداد حساب‌ها
    /// </summary>
    public int AccountCount { get; set; }

    /// <summary>
    /// مجموع بدهکار
    /// </summary>
    public decimal TotalDebit { get; set; }

    /// <summary>
    /// مجموع بستانکار
    /// </summary>
    public decimal TotalCredit { get; set; }

    /// <summary>
    /// مانده خالص
    /// </summary>
    public decimal NetBalance { get; set; }

    /// <summary>
    /// نوع مانده (بدهکار یا بستانکار)
    /// </summary>
    public string BalanceType { get; set; } = string.Empty;
}
