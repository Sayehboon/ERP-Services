using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Purchase.PurchaseOrders.Queries.GetAllPurchaseOrders;

/// <summary>
/// پردازش‌کننده پرس‌وجو لیست سفارش‌های خرید
/// </summary>
public sealed class GetAllPurchaseOrdersQueryHandler : IRequestHandler<GetAllPurchaseOrdersQuery, IEnumerable<PurchaseOrderDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو لیست سفارش‌های خرید
    /// </summary>
    public GetAllPurchaseOrdersQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو لیست سفارش‌های خرید
    /// </summary>
    public async Task<IEnumerable<PurchaseOrderDto>> Handle(GetAllPurchaseOrdersQuery request, CancellationToken cancellationToken)
    {
        var query = _context.PurchaseOrders
            .Include(po => po.Vendor)
            .Include(po => po.Warehouse)
            .Include(po => po.AssignedTo)
            .Include(po => po.CreatedByUser)
            .AsQueryable();

        // فیلتر بر اساس عبارت جستجو
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchLower = request.SearchTerm.ToLower();
            query = query.Where(po => 
                po.OrderNumber.ToLower().Contains(searchLower) ||
                (po.Vendor != null && po.Vendor.Name.ToLower().Contains(searchLower)));
        }

        // فیلتر بر اساس وضعیت
        if (!string.IsNullOrWhiteSpace(request.Status))
        {
            query = query.Where(po => po.Status == request.Status);
        }

        // فیلتر بر اساس نوع سفارش
        if (!string.IsNullOrWhiteSpace(request.OrderType))
        {
            query = query.Where(po => po.OrderType == request.OrderType);
        }

        // فیلتر بر اساس تامین‌کننده
        if (request.VendorId.HasValue)
        {
            query = query.Where(po => po.VendorId == request.VendorId.Value);
        }

        // فیلتر بر اساس انبار
        if (request.WarehouseId.HasValue)
        {
            query = query.Where(po => po.WarehouseId == request.WarehouseId.Value);
        }

        // فیلتر بر اساس کاربر مسئول
        if (request.AssignedToId.HasValue)
        {
            query = query.Where(po => po.AssignedToId == request.AssignedToId.Value);
        }

        // فیلتر بر اساس کاربر ایجاد کننده
        if (request.CreatedById.HasValue)
        {
            query = query.Where(po => po.CreatedById == request.CreatedById.Value);
        }

        // فیلتر بر اساس روش پرداخت
        if (!string.IsNullOrWhiteSpace(request.PaymentMethod))
        {
            query = query.Where(po => po.PaymentMethod == request.PaymentMethod);
        }

        // فیلتر بر اساس ارز
        if (!string.IsNullOrWhiteSpace(request.Currency))
        {
            query = query.Where(po => po.Currency == request.Currency);
        }

        // فیلتر بر اساس مبلغ
        if (request.MinAmount.HasValue)
        {
            query = query.Where(po => po.FinalAmount >= request.MinAmount.Value);
        }

        if (request.MaxAmount.HasValue)
        {
            query = query.Where(po => po.FinalAmount <= request.MaxAmount.Value);
        }

        // فیلتر بر اساس تاریخ سفارش
        if (request.OrderDateFrom.HasValue)
        {
            query = query.Where(po => po.OrderDate >= request.OrderDateFrom.Value);
        }

        if (request.OrderDateTo.HasValue)
        {
            query = query.Where(po => po.OrderDate <= request.OrderDateTo.Value);
        }

        // فیلتر بر اساس تاریخ تحویل مورد انتظار
        if (request.ExpectedDeliveryFrom.HasValue)
        {
            query = query.Where(po => po.ExpectedDeliveryDate >= request.ExpectedDeliveryFrom.Value);
        }

        if (request.ExpectedDeliveryTo.HasValue)
        {
            query = query.Where(po => po.ExpectedDeliveryDate <= request.ExpectedDeliveryTo.Value);
        }

        // فیلتر بر اساس تاریخ تحویل واقعی
        if (request.ActualDeliveryFrom.HasValue)
        {
            query = query.Where(po => po.ActualDeliveryDate >= request.ActualDeliveryFrom.Value);
        }

        if (request.ActualDeliveryTo.HasValue)
        {
            query = query.Where(po => po.ActualDeliveryDate <= request.ActualDeliveryTo.Value);
        }

        // مرتب‌سازی
        query = query.OrderByDescending(po => po.CreatedAt);

        // صفحه‌بندی
        if (request.Page > 1)
        {
            query = query.Skip((request.Page - 1) * request.PageSize);
        }
        
        query = query.Take(request.PageSize);

        var purchaseOrders = await query.ToListAsync(cancellationToken);
        
        return purchaseOrders.Select(po => new PurchaseOrderDto
        {
            Id = po.Id,
            OrderNumber = po.OrderNumber,
            VendorId = po.VendorId,
            VendorName = po.Vendor?.Name,
            OrderDate = po.OrderDate,
            ExpectedDeliveryDate = po.ExpectedDeliveryDate,
            ActualDeliveryDate = po.ActualDeliveryDate,
            Status = po.Status,
            OrderType = po.OrderType,
            WarehouseId = po.WarehouseId,
            WarehouseName = po.Warehouse?.Name,
            AssignedToId = po.AssignedToId,
            AssignedToName = po.AssignedTo != null ? $"{po.AssignedTo.FirstName} {po.AssignedTo.LastName}" : null,
            CreatedById = po.CreatedById,
            CreatedByName = po.CreatedByUser != null ? $"{po.CreatedByUser.FirstName} {po.CreatedByUser.LastName}" : null,
            TotalAmount = po.TotalAmount,
            DiscountAmount = po.DiscountAmount,
            TaxAmount = po.TaxAmount,
            FinalAmount = po.FinalAmount,
            Currency = po.Currency,
            ExchangeRate = po.ExchangeRate,
            PaymentMethod = po.PaymentMethod,
            PaymentTerms = po.PaymentTerms,
            DeliveryAddress = po.DeliveryAddress,
            Notes = po.Notes,
            CreatedAt = po.CreatedAt,
            UpdatedAt = po.UpdatedAt,
            CreatedBy = po.CreatedBy,
            UpdatedBy = po.UpdatedBy
        });
    }
}