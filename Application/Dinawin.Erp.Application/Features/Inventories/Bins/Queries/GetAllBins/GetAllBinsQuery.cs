using MediatR;

namespace Dinawin.Erp.Application.Features.Inventories.Bins.Queries.GetAllBins;

/// <summary>
/// پرس‌وجو لیست مکان‌ها
/// </summary>
public sealed class GetAllBinsQuery : IRequest<IEnumerable<BinDto>>
{
    /// <summary>
    /// عبارت جستجو
    /// </summary>
    public string? SearchTerm { get; init; }

    /// <summary>
    /// شناسه انبار برای فیلتر
    /// </summary>
    public Guid? WarehouseId { get; init; }

    /// <summary>
    /// نوع مکان برای فیلتر
    /// </summary>
    public string? BinType { get; init; }

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
