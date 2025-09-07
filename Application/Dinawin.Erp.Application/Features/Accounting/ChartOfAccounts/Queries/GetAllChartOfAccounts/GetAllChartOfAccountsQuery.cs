using MediatR;

namespace Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.Queries.GetAllChartOfAccounts;

/// <summary>
/// پرس‌وجو لیست حساب‌های کل
/// </summary>
public sealed class GetAllChartOfAccountsQuery : IRequest<IEnumerable<ChartOfAccountDto>>
{
    /// <summary>
    /// عبارت جستجو
    /// </summary>
    public string? SearchTerm { get; init; }

    /// <summary>
    /// شناسه حساب والد برای فیلتر
    /// </summary>
    public Guid? ParentAccountId { get; init; }

    /// <summary>
    /// نوع حساب برای فیلتر
    /// </summary>
    public string? AccountType { get; init; }

    /// <summary>
    /// دسته حساب برای فیلتر
    /// </summary>
    public string? AccountCategory { get; init; }

    /// <summary>
    /// سطح حساب برای فیلتر
    /// </summary>
    public int? Level { get; init; }

    /// <summary>
    /// وضعیت فعال بودن برای فیلتر
    /// </summary>
    public bool? IsActive { get; init; }

    /// <summary>
    /// شماره صفحه
    /// </summary>
    public int Page { get; init; } = 1;

    /// <summary>
    /// تعداد آیتم در هر صفحه
    /// </summary>
    public int PageSize { get; init; } = 25;
}
