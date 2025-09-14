using MediatR;
using Dinawin.Erp.Application.Features.SalesOrders.DTOs;

namespace Dinawin.Erp.Application.Features.SalesOrders.Queries.GetAllSalesOrders;

/// <summary>
/// Query for getting all sales orders with optional filtering
/// </summary>
public class GetAllSalesOrdersQuery : IRequest<List<SalesOrderDto>>
{
    public string SearchTerm { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public string SalesPerson { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public bool? IsActive { get; set; } = true;
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 50;
}
