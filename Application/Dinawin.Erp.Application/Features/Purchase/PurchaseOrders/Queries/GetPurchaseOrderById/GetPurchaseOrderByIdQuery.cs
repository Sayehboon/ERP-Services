using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Purchase.PurchaseOrders.Queries.GetPurchaseOrderById;

/// <summary>
/// پرس‌وجو دریافت سفارش خرید بر اساس شناسه
/// </summary>
public sealed class GetPurchaseOrderByIdQuery : IRequest<PurchaseOrderDto?>
{
    /// <summary>
    /// شناسه سفارش خرید
    /// </summary>
    [Required(ErrorMessage = "شناسه سفارش خرید الزامی است")]
    public Guid Id { get; set; }
}