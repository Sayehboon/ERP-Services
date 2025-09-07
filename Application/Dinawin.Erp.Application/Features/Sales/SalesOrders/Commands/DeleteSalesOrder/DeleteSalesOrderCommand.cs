using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Sales.SalesOrders.Commands.DeleteSalesOrder;

/// <summary>
/// دستور حذف سفارش فروش
/// </summary>
public sealed class DeleteSalesOrderCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه سفارش فروش
    /// </summary>
    [Required(ErrorMessage = "شناسه سفارش فروش الزامی است")]
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