using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Purchase.PurchaseOrders.Queries.GetPurchaseOrderById;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت سفارش خرید بر اساس شناسه
/// </summary>
public sealed class GetPurchaseOrderByIdQueryHandler : IRequestHandler<GetPurchaseOrderByIdQuery, PurchaseOrderDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت سفارش خرید بر اساس شناسه
    /// </summary>
    public GetPurchaseOrderByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// اجرای پرس‌وجو
    /// </summary>
    public async Task<PurchaseOrderDto?> Handle(GetPurchaseOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var purchaseOrder = await _context.PurchaseOrders
            .Include(po => po.Vendor)
            .Include(po => po.Warehouse)
            .Include(po => po.AssignedTo)
            .Include(po => po.CreatedByUser)
            .FirstOrDefaultAsync(po => po.Id == request.Id, cancellationToken);

        if (purchaseOrder == null)
        {
            return null;
        }

        var dto = _mapper.Map<PurchaseOrderDto>(purchaseOrder);
        dto.VendorName = purchaseOrder.Vendor?.Name;
        dto.WarehouseName = purchaseOrder.Warehouse?.Name;
        // AssignedTo is a Guid?, not a User object
        // CreatedByUser property does not exist in PurchaseOrder entity
        return dto;
    }
}