using MediatR;

namespace Dinawin.Erp.Application.Features.Financial.BankAccounts.Queries.GetAllBankAccounts;

/// <summary>
/// پرس‌وجو لیست حساب‌های بانکی
/// </summary>
public sealed class GetAllBankAccountsQuery : IRequest<IEnumerable<BankAccountDto>>
{
    /// <summary>
    /// عبارت جستجو
    /// </summary>
    public string? SearchTerm { get; init; }

    /// <summary>
    /// نام بانک برای فیلتر
    /// </summary>
    public string? BankName { get; init; }

    /// <summary>
    /// نوع حساب برای فیلتر
    /// </summary>
    public string? AccountType { get; init; }

    /// <summary>
    /// ارز برای فیلتر
    /// </summary>
    public string? Currency { get; init; }

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
