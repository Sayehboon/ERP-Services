using MediatR;

namespace Dinawin.Erp.Application.Features.Units.Queries.GetAllUnits;

/// <summary>
/// پرس‌وجو لیست واحدهای اندازه‌گیری
/// </summary>
public sealed class GetAllUnitsQuery : IRequest<IEnumerable<UnitDto>>
{
    /// <summary>
    /// عبارت جستجو
    /// </summary>
    public string? SearchTerm { get; init; }

    /// <summary>
    /// نوع واحد اندازه‌گیری برای فیلتر
    /// </summary>
    public string? UnitType { get; init; }

    /// <summary>
    /// فقط واحدهای فعال
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
