using MediatR;

namespace Dinawin.Erp.Application.Features.Inventories.Warehouses.Queries.GetAllWarehouses;

/// <summary>
/// پرس‌وجو لیست انبارها
/// </summary>
public sealed class GetAllWarehousesQuery : IRequest<IEnumerable<WarehouseDto>>
{
    /// <summary>
    /// عبارت جستجو
    /// </summary>
    public string SearchTerm { get; init; }

    /// <summary>
    /// نوع انبار برای فیلتر
    /// </summary>
    public string WarehouseType { get; init; }

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