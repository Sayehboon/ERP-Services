using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Sales.SalesOrders.Queries.GetAllSalesOrders;

/// <summary>
/// پردازش‌کننده پرس‌وجو لیست سفارش‌های فروش
/// </summary>
public sealed class GetAllSalesOrdersQueryHandler : IRequestHandler<GetAllSalesOrdersQuery, IEnumerable<SalesOrderDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو لیست سفارش‌های فروش
    /// </summary>
    public GetAllSalesOrdersQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو لیست سفارش‌های فروش
    /// </summary>
    public async Task<IEnumerable<SalesOrderDto>> Handle(GetAllSalesOrdersQuery request, CancellationToken cancellationToken)
    {
        var query = _context.SalesOrders
            .Include(so => so.Customer)
            .Include(so => so.Opportunity)
            .Include(so => so.Warehouse)
            .Include(so => so.AssignedTo)
            .Include(so => so.CreatedByUser)
            .AsQueryable();

        // فیلتر بر اساس عبارت جستجو
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchLower = request.SearchTerm.ToLower();
            query = query.Where(so => 
                so.OrderNumber.ToLower().Contains(searchLower) ||
                (so.Customer != null && so.Customer.Name.ToLower().Contains(searchLower)) ||
                (so.Opportunity != null && so.Opportunity.Name.ToLower().Contains(searchLower)));
        }

        // فیلتر بر اساس وضعیت
        if (!string.IsNullOrWhiteSpace(request.Status))
        {
            query = query.Where(so => so.Status == request.Status);
        }

        // فیلتر بر اساس نوع سفارش
        if (!string.IsNullOrWhiteSpace(request.OrderType))
        {
            query = query.Where(so => so.OrderType == request.OrderType);
        }

        // فیلتر بر اساس مشتری
        if (request.CustomerId.HasValue)
        {
            query = query.Where(so => so.CustomerId == request.CustomerId.Value);
        }

        // فیلتر بر اساس فرصت
        if (request.OpportunityId.HasValue)
        {
            query = query.Where(so => so.OpportunityId == request.OpportunityId.Value);
        }

        // فیلتر بر اساس انبار
        if (request.WarehouseId.HasValue)
        {
            query = query.Where(so => so.WarehouseId == request.WarehouseId.Value);
        }

        // فیلتر بر اساس کاربر مسئول
        if (request.AssignedToId.HasValue)
        {
            query = query.Where(so => so.AssignedToId == request.AssignedToId.Value);
        }

        // فیلتر بر اساس کاربر ایجاد کننده
        if (request.CreatedById.HasValue)
        {
            query = query.Where(so => so.CreatedById == request.CreatedById.Value);
        }

        // فیلتر بر اساس روش پرداخت
        if (!string.IsNullOrWhiteSpace(request.PaymentMethod))
        {
            query = query.Where(so => so.PaymentMethod == request.PaymentMethod);
        }

        // فیلتر بر اساس ارز
        if (!string.IsNullOrWhiteSpace(request.Currency))
        {
            query = query.Where(so => so.Currency == request.Currency);
        }

        // فیلتر بر اساس مبلغ
        if (request.MinAmount.HasValue)
        {
            query = query.Where(so => so.FinalAmount >= request.MinAmount.Value);
        }

        if (request.MaxAmount.HasValue)
        {
            query = query.Where(so => so.FinalAmount <= request.MaxAmount.Value);
        }

        // فیلتر بر اساس تاریخ سفارش
        if (request.OrderDateFrom.HasValue)
        {
            query = query.Where(so => so.OrderDate >= request.OrderDateFrom.Value);
        }

        if (request.OrderDateTo.HasValue)
        {
            query = query.Where(so => so.OrderDate <= request.OrderDateTo.Value);
        }

        // فیلتر بر اساس تاریخ تحویل مورد انتظار
        if (request.ExpectedDeliveryFrom.HasValue)
        {
            query = query.Where(so => so.ExpectedDeliveryDate >= request.ExpectedDeliveryFrom.Value);
        }

        if (request.ExpectedDeliveryTo.HasValue)
        {
            query = query.Where(so => so.ExpectedDeliveryDate <= request.ExpectedDeliveryTo.Value);
        }

        // فیلتر بر اساس تاریخ تحویل واقعی
        if (request.ActualDeliveryFrom.HasValue)
        {
            query = query.Where(so => so.ActualDeliveryDate >= request.ActualDeliveryFrom.Value);
        }

        if (request.ActualDeliveryTo.HasValue)
        {
            query = query.Where(so => so.ActualDeliveryDate <= request.ActualDeliveryTo.Value);
        }

        // مرتب‌سازی
        query = query.OrderByDescending(so => so.CreatedAt);

        // صفحه‌بندی
        if (request.Page > 1)
        {
            query = query.Skip((request.Page - 1) * request.PageSize);
        }
        
        query = query.Take(request.PageSize);

        var salesOrders = await query.ToListAsync(cancellationToken);
        
        return salesOrders.Select(so => new SalesOrderDto
        {
            Id = so.Id,
            OrderNumber = so.OrderNumber,
            CustomerId = so.CustomerId,
            CustomerName = so.Customer?.Name,
            OpportunityId = so.OpportunityId,
            OpportunityName = so.Opportunity?.Name,
            OrderDate = so.OrderDate,
            ExpectedDeliveryDate = so.ExpectedDeliveryDate,
            ActualDeliveryDate = so.ActualDeliveryDate,
            Status = so.Status,
            OrderType = so.OrderType,
            WarehouseId = so.WarehouseId,
            WarehouseName = so.Warehouse?.Name,
            AssignedToId = so.AssignedToId,
            AssignedToName = so.AssignedTo != null ? $"{so.AssignedTo.FirstName} {so.AssignedTo.LastName}" : null,
            CreatedById = so.CreatedById,
            CreatedByName = so.CreatedByUser != null ? $"{so.CreatedByUser.FirstName} {so.CreatedByUser.LastName}" : null,
            TotalAmount = so.TotalAmount,
            DiscountAmount = so.DiscountAmount,
            TaxAmount = so.TaxAmount,
            FinalAmount = so.FinalAmount,
            Currency = so.Currency,
            ExchangeRate = so.ExchangeRate,
            PaymentMethod = so.PaymentMethod,
            PaymentTerms = so.PaymentTerms,
            DeliveryAddress = so.DeliveryAddress,
            Notes = so.Notes,
            CreatedAt = so.CreatedAt,
            UpdatedAt = so.UpdatedAt,
            CreatedBy = so.CreatedBy,
            UpdatedBy = so.UpdatedBy
        });
    }
}