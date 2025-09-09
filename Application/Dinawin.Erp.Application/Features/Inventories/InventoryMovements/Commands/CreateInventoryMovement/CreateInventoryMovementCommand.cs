using MediatR;

namespace Dinawin.Erp.Application.Features.Inventories.InventoryMovements.Commands.CreateInventoryMovement;

/// <summary>
/// دستور ایجاد حرکت انبار
/// </summary>
public sealed class CreateInventoryMovementCommand : IRequest<Guid>
{
    /// <summary>
    /// شناسه محصول
    /// </summary>
    public required Guid ProductId { get; init; }

    /// <summary>
    /// شناسه انبار
    /// </summary>
    public required Guid WarehouseId { get; init; }

    /// <summary>
    /// شناسه مکان (اختیاری)
    /// </summary>
    public Guid? BinId { get; init; }

    /// <summary>
    /// نوع حرکت
    /// </summary>
    public required string MovementType { get; init; }

    /// <summary>
    /// مقدار
    /// </summary>
    public required decimal Quantity { get; init; }

    /// <summary>
    /// قیمت واحد
    /// </summary>
    public decimal? UnitPrice { get; init; }

    /// <summary>
    /// تاریخ حرکت
    /// </summary>
    public DateTime MovementDate { get; init; } = DateTime.UtcNow;

    /// <summary>
    /// شماره مرجع
    /// </summary>
    public string? ReferenceNumber { get; init; }

    /// <summary>
    /// نوع مرجع
    /// </summary>
    public string? ReferenceType { get; init; }

    /// <summary>
    /// شناسه مرجع
    /// </summary>
    public Guid? ReferenceId { get; init; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; init; }

    /// <summary>
    /// شناسه کاربر ایجادکننده
    /// </summary>
    public Guid? CreatedBy { get; init; }
}
