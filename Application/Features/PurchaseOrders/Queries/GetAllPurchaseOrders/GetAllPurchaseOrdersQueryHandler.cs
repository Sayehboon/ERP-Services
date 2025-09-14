using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.PurchaseOrders.DTOs;

namespace Dinawin.Erp.Application.Features.PurchaseOrders.Queries.GetAllPurchaseOrders;

/// <summary>
/// Handler for getting all purchase orders
/// </summary>
public class GetAllPurchaseOrdersQueryHandler : IRequestHandler<GetAllPurchaseOrdersQuery, List<PurchaseOrderDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAllPurchaseOrdersQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<PurchaseOrderDto>> Handle(GetAllPurchaseOrdersQuery request, CancellationToken cancellationToken)
    {
        var query = _context.PurchaseOrders
            .Include(po => po.Items)
            .AsQueryable();

        // Apply filters
        if (!string.IsNullOrEmpty(request.SearchTerm))
        {
            query = query.Where(po => 
                (po.Number != null && po.Number.Contains(request.SearchTerm)) ||
                (po.VendorName != null && po.VendorName.Contains(request.SearchTerm)) ||
                (po.VendorEmail != null && po.VendorEmail.Contains(request.SearchTerm)));
        }

        if (!string.IsNullOrEmpty(request.Status))
            query = query.Where(po => po.Status == request.Status);

        if (!string.IsNullOrEmpty(request.Priority))
            query = query.Where(po => po.Priority == request.Priority);

        if (!string.IsNullOrEmpty(request.VendorName))
            query = query.Where(po => po.VendorName != null && po.VendorName.Contains(request.VendorName));

        if (!string.IsNullOrEmpty(request.RequestedBy))
            query = query.Where(po => po.RequestedBy == request.RequestedBy);

        if (request.FromDate.HasValue)
            query = query.Where(po => po.OrderDate >= request.FromDate.Value);

        if (request.ToDate.HasValue)
            query = query.Where(po => po.OrderDate <= request.ToDate.Value);

        if (request.IsActive.HasValue)
            query = query.Where(po => po.IsActive == request.IsActive.Value);

        // Apply pagination
        query = query
            .OrderByDescending(po => po.CreatedAt)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize);

        var purchaseOrders = await query
            .Select(po => new PurchaseOrderDto
            {
                Id = po.Id,
                Number = po.Number,
                VendorName = po.VendorName ?? string.Empty,
                VendorEmail = po.VendorEmail,
                VendorPhone = po.VendorPhone,
                OrderDate = po.OrderDate,
                ExpectedDeliveryDate = po.ExpectedDeliveryDate,
                TotalAmount = po.TotalAmount,
                Status = po.Status,
                Priority = po.Priority ?? string.Empty,
                RequestedBy = po.RequestedBy ?? string.Empty,
                Description = po.Description,
                DeliveryAddress = po.DeliveryAddress,
                PaymentTerms = po.PaymentTerms,
                CreatedAt = po.CreatedAt,
                UpdatedAt = po.UpdatedAt,
                CreatedBy = po.CreatedBy,
                UpdatedBy = po.UpdatedBy,
                IsActive = po.IsActive,
                Items = po.Items.Select(item => new PurchaseOrderItemDto
                {
                    Id = item.Id,
                    PurchaseOrderId = item.PurchaseOrderId,
                    ProductName = item.ProductName,
                    ProductCode = item.ProductCode,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    TotalAmount = item.TotalAmount,
                    Description = item.Description,
                    CreatedAt = item.CreatedAt,
                    UpdatedAt = item.UpdatedAt,
                    CreatedBy = item.CreatedBy,
                    UpdatedBy = item.UpdatedBy
                }).ToList()
            })
            .ToListAsync(cancellationToken);

        return purchaseOrders;
    }
}
