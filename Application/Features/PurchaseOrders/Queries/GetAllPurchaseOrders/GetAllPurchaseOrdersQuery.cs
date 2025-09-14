using MediatR;
using Dinawin.Erp.Application.Features.PurchaseOrders.DTOs;

namespace Dinawin.Erp.Application.Features.PurchaseOrders.Queries.GetAllPurchaseOrders;

/// <summary>
/// Query for getting all purchase orders with optional filtering
/// </summary>
public class GetAllPurchaseOrdersQuery : IRequest<List<PurchaseOrderDto>>
{
    public string SearchTerm { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public string VendorName { get; set; }
    public string RequestedBy { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public bool? IsActive { get; set; } = true;
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 50;
}
