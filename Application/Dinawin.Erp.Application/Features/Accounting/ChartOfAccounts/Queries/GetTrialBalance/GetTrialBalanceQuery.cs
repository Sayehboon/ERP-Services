using MediatR;

namespace Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.Queries.GetTrialBalance;

/// <summary>
/// پرس‌وجو دریافت تراز آزمایشی
/// </summary>
public sealed class GetTrialBalanceQuery : IRequest<TrialBalanceDto>
{
    /// <summary>
    /// تاریخ شروع
    /// </summary>
    public DateTime? FromDate { get; init; }

    /// <summary>
    /// تاریخ پایان
    /// </summary>
    public DateTime? ToDate { get; init; }

    /// <summary>
    /// نوع حساب (اختیاری)
    /// </summary>
    public string? AccountType { get; init; }

    /// <summary>
    /// دسته‌بندی حساب (اختیاری)
    /// </summary>
    public string? AccountCategory { get; init; }

    /// <summary>
    /// سطح حساب (اختیاری)
    /// </summary>
    public int? Level { get; init; }

    /// <summary>
    /// آیا فقط حساب‌های با مانده غیر صفر را نمایش دهد
    /// </summary>
    public bool OnlyNonZeroBalances { get; init; } = false;

    /// <summary>
    /// آیا شامل حساب‌های غیرفعال باشد
    /// </summary>
    public bool IncludeInactiveAccounts { get; init; } = false;
}
