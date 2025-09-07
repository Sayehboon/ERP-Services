using MediatR;

namespace Dinawin.Erp.Application.Features.Years.Queries.GetAllYears;

/// <summary>
/// پرس‌وجو لیست سال‌ها
/// </summary>
public sealed class GetAllYearsQuery : IRequest<IEnumerable<YearDto>>
{
    /// <summary>
    /// عبارت جستجو
    /// </summary>
    public string? SearchTerm { get; init; }

    /// <summary>
    /// فقط سال‌های فعال
    /// </summary>
    public bool? IsActive { get; init; }

    /// <summary>
    /// سال شروع
    /// </summary>
    public int? YearFrom { get; init; }

    /// <summary>
    /// سال پایان
    /// </summary>
    public int? YearTo { get; init; }

    /// <summary>
    /// شماره صفحه
    /// </summary>
    public int Page { get; init; } = 1;

    /// <summary>
    /// تعداد آیتم در هر صفحه
    /// </summary>
    public int PageSize { get; init; } = 25;
}
