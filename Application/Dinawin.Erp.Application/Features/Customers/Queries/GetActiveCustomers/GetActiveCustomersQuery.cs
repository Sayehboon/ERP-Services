using MediatR;

namespace Dinawin.Erp.Application.Features.Customers.Queries.GetActiveCustomers;

/// <summary>
/// پرس‌وجو دریافت مشتریان فعال
/// </summary>
public sealed class GetActiveCustomersQuery : IRequest<IEnumerable<CustomerDto>>
{
    /// <summary>
    /// شناسه شرکت (اختیاری)
    /// </summary>
    public Guid? CompanyId { get; init; }

    /// <summary>
    /// عبارت جستجو (اختیاری)
    /// </summary>
    public string? SearchTerm { get; init; }

    /// <summary>
    /// نوع مشتری (اختیاری)
    /// </summary>
    public string? CustomerType { get; init; }

    /// <summary>
    /// شهر (اختیاری)
    /// </summary>
    public string? City { get; init; }

    /// <summary>
    /// شماره صفحه
    /// </summary>
    public int Page { get; init; } = 1;

    /// <summary>
    /// تعداد آیتم در هر صفحه
    /// </summary>
    public int PageSize { get; init; } = 25;
}
