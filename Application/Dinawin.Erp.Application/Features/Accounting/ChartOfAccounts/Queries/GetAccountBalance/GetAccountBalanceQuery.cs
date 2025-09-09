using MediatR;

namespace Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.Queries.GetAccountBalance;

/// <summary>
/// پرس‌وجو دریافت مانده حساب
/// </summary>
public sealed class GetAccountBalanceQuery : IRequest<AccountBalanceDto>
{
    /// <summary>
    /// شناسه حساب
    /// </summary>
    public required Guid AccountId { get; init; }

    /// <summary>
    /// تاریخ شروع (اختیاری)
    /// </summary>
    public DateTime? FromDate { get; init; }

    /// <summary>
    /// تاریخ پایان (اختیاری)
    /// </summary>
    public DateTime? ToDate { get; init; }

    /// <summary>
    /// آیا شامل حساب‌های فرزند باشد
    /// </summary>
    public bool IncludeChildren { get; init; } = false;
}
