using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Sales.SalesOrders.Queries.GetSalesOrderById;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت سفارش فروش بر اساس شناسه
/// </summary>
public sealed class GetSalesOrderByIdQueryHandler : IRequestHandler<GetSalesOrderByIdQuery, SalesOrderDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت سفارش فروش بر اساس شناسه
    /// </summary>
    public GetSalesOrderByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// اجرای پرس‌وجو
    /// </summary>
    public async Task<SalesOrderDto?> Handle(GetSalesOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var salesOrder = await _context.SalesOrders
            .Include(so => so.Customer)
            .Include(so => so.Opportunity)
            .Include(so => so.Warehouse)
            .Include(so => so.AssignedTo)
            // CreatedByUser property does not exist in SalesOrder entity
            .FirstOrDefaultAsync(so => so.Id == request.Id, cancellationToken);

        if (salesOrder == null)
        {
            return null;
        }

        var dto = _mapper.Map<SalesOrderDto>(salesOrder);
        dto.CustomerName = salesOrder.Customer?.Name;
        dto.OpportunityName = salesOrder.Opportunity?.Name;
        dto.WarehouseName = salesOrder.Warehouse?.Name;
        dto.AssignedToName = "نامشخص"; // AssignedTo property does not exist in SalesOrder entity
        dto.CreatedByName = "نامشخص"; // CreatedByUser property does not exist in SalesOrder entity
        return dto;
    }
}
