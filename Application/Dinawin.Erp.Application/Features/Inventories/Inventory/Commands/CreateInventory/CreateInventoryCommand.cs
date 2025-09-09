using MediatR;

namespace Dinawin.Erp.Application.Features.Inventories.Inventories.Commands.CreateInventory;

/// <summary>
/// دستور ایجاد سطوح موجودی جدید
/// </summary>
public class CreateInventoryCommand : IRequest<Guid>
{
    /// <summary>
    /// شناسه محصول
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// شناسه انبار
    /// </summary>
    public Guid WarehouseId { get; set; }

    /// <summary>
    /// حداقل موجودی
    /// </summary>
    public decimal? MinQty { get; set; }

    /// <summary>
    /// حداکثر موجودی
    /// </summary>
    public decimal? MaxQty { get; set; }

    /// <summary>
    /// نقطه سفارش مجدد
    /// </summary>
    public decimal? ReorderPoint { get; set; }

    /// <summary>
    /// موجودی ایمن
    /// </summary>
    public decimal? SafetyStock { get; set; }

    /// <summary>
    /// شناسه کاربر ایجادکننده
    /// </summary>
    public Guid CreatedByUserId { get; set; }
}
