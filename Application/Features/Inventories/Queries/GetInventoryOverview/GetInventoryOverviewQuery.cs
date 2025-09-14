using MediatR;
using Dinawin.Erp.Application.Features.Inventories.Queries.Dtos;

namespace Dinawin.Erp.Application.Features.Inventories.Queries.GetInventoryOverview;

/// <summary>
/// پرس‌وجو نمای کلی موجودی
/// Query for getting inventory overview
/// </summary>
public record GetInventoryOverviewQuery : IRequest<IEnumerable<InventoryDto>>
{
    /// <summary>
    /// شناسه انبار
    /// Warehouse ID filter
    /// </summary>
    public Guid? WarehouseId { get; init; }

    /// <summary>
    /// شناسه کالا
    /// Product ID filter
    /// </summary>
    public Guid? ProductId { get; init; }

    /// <summary>
    /// فقط موجودی‌های کم
    /// Only low stock items
    /// </summary>
    public bool? LowStockOnly { get; init; }

    /// <summary>
    /// فقط موجودی‌های نیازمند سفارش مجدد
    /// Only items needing reorder
    /// </summary>
    public bool? ReorderOnly { get; init; }

    /// <summary>
    /// شماره صفحه
    /// Page number
    /// </summary>
    public int Page { get; init; } = 1;

    /// <summary>
    /// تعداد آیتم در هر صفحه
    /// Items per page
    /// </summary>
    public int PageSize { get; init; } = 25;
}
