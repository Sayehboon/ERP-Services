using MediatR;

namespace Dinawin.Erp.Application.Features.Customers.Queries.GetAllCustomers;

/// <summary>
/// پرس‌وجو لیست مشتریان
/// </summary>
public sealed class GetAllCustomersQuery : IRequest<IEnumerable<CustomerDto>>
{
    /// <summary>
    /// عبارت جستجو
    /// </summary>
    public string? SearchTerm { get; init; }

    /// <summary>
    /// نوع مشتری برای فیلتر
    /// </summary>
    public string? CustomerType { get; init; }

    /// <summary>
    /// شهر برای فیلتر
    /// </summary>
    public string? City { get; init; }

    /// <summary>
    /// استان برای فیلتر
    /// </summary>
    public string? Province { get; init; }

    /// <summary>
    /// کشور برای فیلتر
    /// </summary>
    public string? Country { get; init; }

    /// <summary>
    /// وضعیت فعال بودن برای فیلتر
    /// </summary>
    public bool? IsActive { get; init; }

    /// <summary>
    /// حداقل اعتبار
    /// </summary>
    public decimal? MinCreditLimit { get; init; }

    /// <summary>
    /// حداکثر اعتبار
    /// </summary>
    public decimal? MaxCreditLimit { get; init; }

    /// <summary>
    /// شماره صفحه
    /// </summary>
    public int Page { get; init; } = 1;

    /// <summary>
    /// تعداد آیتم در هر صفحه
    /// </summary>
    public int PageSize { get; init; } = 25;
}
