using MediatR;

namespace Dinawin.Erp.Application.Features.Inventories.Inventories.Queries.GetAllInventory;

/// <summary>
/// پرس‌وجو لیست موجودی‌ها
/// </summary>
public sealed class GetAllInventoryQuery : IRequest<IEnumerable<InventoryDto>>
{
    /// <summary>
    /// عبارت جستجو
    /// </summary>
    public string? SearchTerm { get; init; }

    /// <summary>
    /// شناسه محصول برای فیلتر
    /// </summary>
    public Guid? ProductId { get; init; }

    /// <summary>
    /// شناسه انبار برای فیلتر
    /// </summary>
    public Guid? WarehouseId { get; init; }

    /// <summary>
    /// شناسه مکان برای فیلتر
    /// </summary>
    public Guid? BinId { get; init; }

    /// <summary>
    /// فیلتر موجودی کم
    /// </summary>
    public bool? LowStock { get; init; }

    /// <summary>
    /// فیلتر موجودی منقضی
    /// </summary>
    public bool? Expired { get; init; }

    /// <summary>
    /// شماره صفحه
    /// </summary>
    public int Page { get; init; } = 1;

    /// <summary>
    /// تعداد آیتم در هر صفحه
    /// </summary>
    public int PageSize { get; init; } = 25;
}
