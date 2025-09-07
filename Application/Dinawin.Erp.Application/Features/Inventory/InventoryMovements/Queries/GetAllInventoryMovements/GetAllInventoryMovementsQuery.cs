using MediatR;

namespace Dinawin.Erp.Application.Features.Inventory.InventoryMovements.Queries.GetAllInventoryMovements;

/// <summary>
/// پرس‌وجو لیست حرکات موجودی
/// </summary>
public sealed class GetAllInventoryMovementsQuery : IRequest<IEnumerable<InventoryMovementDto>>
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
    /// نوع حرکت برای فیلتر
    /// </summary>
    public string? MovementType { get; init; }

    /// <summary>
    /// تاریخ شروع برای فیلتر
    /// </summary>
    public DateTime? FromDate { get; init; }

    /// <summary>
    /// تاریخ پایان برای فیلتر
    /// </summary>
    public DateTime? ToDate { get; init; }

    /// <summary>
    /// نوع سند مرجع برای فیلتر
    /// </summary>
    public string? ReferenceType { get; init; }

    /// <summary>
    /// شماره صفحه
    /// </summary>
    public int Page { get; init; } = 1;

    /// <summary>
    /// تعداد آیتم در هر صفحه
    /// </summary>
    public int PageSize { get; init; } = 25;
}
