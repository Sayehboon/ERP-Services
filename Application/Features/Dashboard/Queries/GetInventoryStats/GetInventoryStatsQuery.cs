using MediatR;

namespace Dinawin.Erp.Application.Features.Dashboard.Queries.GetInventoryStats;

/// <summary>
/// پرس‌وجو دریافت آمار موجودی
/// </summary>
public sealed class GetInventoryStatsQuery : IRequest<InventoryStatsDto>
{
    /// <summary>
    /// شناسه انبار برای فیلتر
    /// </summary>
    public Guid? WarehouseId { get; init; }

    /// <summary>
    /// شناسه دسته‌بندی برای فیلتر
    /// </summary>
    public Guid? CategoryId { get; init; }

    /// <summary>
    /// شناسه محصول برای فیلتر
    /// </summary>
    public Guid? ProductId { get; init; }
}
