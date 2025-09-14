using MediatR;

namespace Dinawin.Erp.Application.Features.Inventories.Inventories.Commands.ReserveInventory;

/// <summary>
/// دستور رزرو موجودی
/// </summary>
public sealed class ReserveInventoryCommand : IRequest<bool>
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
    /// مقدار رزرو
    /// </summary>
    public required decimal Quantity { get; init; }

    /// <summary>
    /// شماره مرجع رزرو
    /// </summary>
    public string ReferenceNumber { get; init; }

    /// <summary>
    /// نوع مرجع
    /// </summary>
    public string ReferenceType { get; init; }

    /// <summary>
    /// شناسه مرجع
    /// </summary>
    public Guid? ReferenceId { get; init; }

    /// <summary>
    /// تاریخ انقضای رزرو
    /// </summary>
    public DateTime? ExpiryDate { get; init; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string Description { get; init; }

    /// <summary>
    /// شناسه کاربر رزروکننده
    /// </summary>
    public Guid? ReservedBy { get; init; }
}
