using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Sales.SalesOrders.Queries.GetSalesOrderById;

/// <summary>
/// پرس‌وجو دریافت سفارش فروش بر اساس شناسه
/// </summary>
public sealed class GetSalesOrderByIdQuery : IRequest<SalesOrderDto?>
{
    /// <summary>
    /// شناسه سفارش فروش
    /// </summary>
    [Required(ErrorMessage = "شناسه سفارش فروش الزامی است")]
    public Guid Id { get; set; }
}
