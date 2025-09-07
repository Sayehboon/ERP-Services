using MediatR;

namespace Dinawin.Erp.Application.Features.Uoms.Queries.GetAllUoms;

/// <summary>
/// پرس‌وجو لیست واحدهای اندازه‌گیری
/// </summary>
public sealed class GetAllUomsQuery : IRequest<IEnumerable<UomDto>>
{
    /// <summary>
    /// عبارت جستجو
    /// </summary>
    public string? SearchTerm { get; init; }

    /// <summary>
    /// نوع واحد اندازه‌گیری برای فیلتر
    /// </summary>
    public string? UomType { get; init; }

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
