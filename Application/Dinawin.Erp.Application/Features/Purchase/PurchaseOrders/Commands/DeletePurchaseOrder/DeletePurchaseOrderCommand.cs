using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Purchase.PurchaseOrders.Commands.DeletePurchaseOrder;

/// <summary>
/// دستور حذف سفارش خرید
/// </summary>
public sealed class DeletePurchaseOrderCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه سفارش خرید
    /// </summary>
    [Required(ErrorMessage = "شناسه سفارش خرید الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// شناسه کاربر حذف‌کننده
    /// </summary>
    public Guid? DeletedBy { get; set; }

    /// <summary>
    /// دلیل حذف
    /// </summary>
    [StringLength(500)]
    public string? DeleteReason { get; set; }
}