using MediatR;

namespace Dinawin.Erp.Application.Features.Vendors.Queries.GetActiveVendors;

/// <summary>
/// پرس‌وجو دریافت تامین‌کنندگان فعال
/// </summary>
public sealed class GetActiveVendorsQuery : IRequest<IEnumerable<VendorDto>>
{
    /// <summary>
    /// شناسه شرکت (اختیاری)
    /// </summary>
    public Guid? CompanyId { get; init; }

    /// <summary>
    /// عبارت جستجو (اختیاری)
    /// </summary>
    public string SearchTerm { get; init; }

    /// <summary>
    /// شماره صفحه
    /// </summary>
    public int Page { get; init; } = 1;

    /// <summary>
    /// تعداد آیتم در هر صفحه
    /// </summary>
    public int PageSize { get; init; } = 25;
}
