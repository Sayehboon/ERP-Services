using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.SalesOrders.DTOs;

namespace Dinawin.Erp.Application.Features.SalesOrders.Queries.GetAllSalesOrders;

/// <summary>
/// Handler for getting all sales orders
/// </summary>
public class GetAllSalesOrdersQueryHandler : IRequestHandler<GetAllSalesOrdersQuery, List<SalesOrderDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAllSalesOrdersQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<SalesOrderDto>> Handle(GetAllSalesOrdersQuery request, CancellationToken cancellationToken)
    {
        var query = _context.SalesOrders
            .Include(so => so.Items)
            .AsQueryable();

        // Apply filters
        if (!string.IsNullOrEmpty(request.SearchTerm))
        {
            query = query.Where(so => 
                (so.Number != null && so.Number.Contains(request.SearchTerm)) ||
                (so.CustomerName != null && so.CustomerName.Contains(request.SearchTerm)) ||
                (so.CustomerEmail != null && so.CustomerEmail.Contains(request.SearchTerm)));
        }

        if (!string.IsNullOrEmpty(request.Status))
            query = query.Where(so => so.Status == request.Status);

        if (!string.IsNullOrEmpty(request.Priority))
            query = query.Where(so => so.Priority == request.Priority);

        if (!string.IsNullOrEmpty(request.SalesPerson))
            query = query.Where(so => so.SalesPerson == request.SalesPerson);

        if (request.FromDate.HasValue)
            query = query.Where(so => so.OrderDate >= request.FromDate.Value);

        if (request.ToDate.HasValue)
            query = query.Where(so => so.OrderDate <= request.ToDate.Value);

        if (request.IsActive.HasValue)
            query = query.Where(so => so.IsActive == request.IsActive.Value);

        // Apply pagination
        query = query
            .OrderByDescending(so => so.CreatedAt)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize);

        var salesOrders = await query
            .Select(so => new SalesOrderDto
            {
                Id = so.Id,
                Number = so.Number,
                CustomerName = so.CustomerName,
                CustomerEmail = so.CustomerEmail,
                CustomerPhone = so.CustomerPhone,
                OrderDate = so.OrderDate,
                DeliveryDate = so.DeliveryDate,
                TotalAmount = so.TotalAmount,
                Status = so.Status,
                Priority = so.Priority,
                SalesPerson = so.SalesPerson,
                Description = so.Description,
                DeliveryAddress = so.DeliveryAddress,
                PaymentTerms = so.PaymentTerms,
                CreatedAt = so.CreatedAt,
                UpdatedAt = so.UpdatedAt,
                CreatedBy = so.CreatedBy,
                UpdatedBy = so.UpdatedBy,
                IsActive = so.IsActive,
                Items = so.Items.Select(item => new SalesOrderItemDto
                {
                    Id = item.Id,
                    SalesOrderId = item.SalesOrderId,
                    ProductName = item.ProductName ?? string.Empty,
                    ProductCode = item.ProductCode ?? string.Empty,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    TotalAmount = item.TotalAmount,
                    Description = item.Description ?? string.Empty,
                    CreatedAt = item.CreatedAt,
                    UpdatedAt = item.UpdatedAt,
                    CreatedBy = item.CreatedBy,
                    UpdatedBy = item.UpdatedBy
                }).ToList()
            })
            .ToListAsync(cancellationToken);

        return salesOrders;
    }
}
