using MediatR;

namespace Dinawin.Erp.Application.Features.Inventories.Inventories.Commands.ReleaseInventory;

/// <summary>
/// دستور آزادسازی موجودی رزرو شده
/// </summary>
public sealed class ReleaseInventoryCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه رزرو
    /// </summary>
    public Guid? ReservationId { get; init; }

    /// <summary>
    /// شناسه محصول (اگر ReservationId مشخص نشده باشد)
    /// </summary>
    public Guid? ProductId { get; init; }

    /// <summary>
    /// شناسه انبار (اگر ReservationId مشخص نشده باشد)
    /// </summary>
    public Guid? WarehouseId { get; init; }

    /// <summary>
    /// شناسه مکان (اگر ReservationId مشخص نشده باشد)
    /// </summary>
    public Guid? BinId { get; init; }

    /// <summary>
    /// شماره مرجع (اگر ReservationId مشخص نشده باشد)
    /// </summary>
    public string? ReferenceNumber { get; init; }

    /// <summary>
    /// نوع مرجع (اگر ReservationId مشخص نشده باشد)
    /// </summary>
    public string? ReferenceType { get; init; }

    /// <summary>
    /// شناسه مرجع (اگر ReservationId مشخص نشده باشد)
    /// </summary>
    public Guid? ReferenceId { get; init; }

    /// <summary>
    /// مقدار آزادسازی (اختیاری - اگر مشخص نشود، کل رزرو آزاد می‌شود)
    /// </summary>
    public decimal? Quantity { get; init; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; init; }

    /// <summary>
    /// شناسه کاربر آزادکننده
    /// </summary>
    public Guid? ReleasedBy { get; init; }
}
