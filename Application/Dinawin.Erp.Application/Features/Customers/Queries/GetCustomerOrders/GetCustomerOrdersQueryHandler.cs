using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Customers.Queries.GetCustomerOrders;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت سفارشات مشتری
/// </summary>
public sealed class GetCustomerOrdersQueryHandler : IRequestHandler<GetCustomerOrdersQuery, IEnumerable<CustomerOrderDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت سفارشات مشتری
    /// </summary>
    public GetCustomerOrdersQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو دریافت سفارشات مشتری
    /// </summary>
    public async Task<IEnumerable<CustomerOrderDto>> Handle(GetCustomerOrdersQuery request, CancellationToken cancellationToken)
    {
        var query = _context.SalesOrders
            .Include(s => s.Items)
                .ThenInclude(item => item.Product)
            .Where(s => s.CustomerId == request.CustomerId);

        // فیلتر بر اساس وضعیت
        if (!string.IsNullOrEmpty(request.Status))
        {
            query = query.Where(s => s.Status == request.Status);
        }

        // فیلتر بر اساس تاریخ
        if (request.FromDate.HasValue)
        {
            query = query.Where(s => s.OrderDate >= request.FromDate.Value);
        }

        if (request.ToDate.HasValue)
        {
            query = query.Where(s => s.OrderDate <= request.ToDate.Value);
        }

        // فیلتر بر اساس شماره سفارش
        if (!string.IsNullOrEmpty(request.OrderNumber))
        {
            query = query.Where(s => s.OrderNumber.Contains(request.OrderNumber));
        }

        var sales = await query
            .OrderByDescending(s => s.OrderDate)
            .Take(request.MaxResults)
            .ToListAsync(cancellationToken);

        var result = new List<CustomerOrderDto>();

        foreach (var sale in sales)
        {
            var orderDto = new CustomerOrderDto
            {
                Id = sale.Id,
                OrderNumber = sale.OrderNumber,
                CustomerId = sale.CustomerId,
                CustomerName = string.Empty,
                OrderDate = sale.OrderDate,
                ExpectedDeliveryDate = sale.ExpectedDeliveryDate,
                ActualDeliveryDate = sale.ActualDeliveryDate,
                Status = sale.Status,
                StatusPersian = GetStatusPersian(sale.Status),
                OrderType = sale.Type ?? string.Empty,
                TotalAmount = sale.TotalAmount,
                PaidAmount = 0,
                Currency = sale.Currency,
                ExchangeRate = null,
                TotalAmountInBaseCurrency = null,
                ItemCount = sale.Items.Count,
                TotalQuantity = sale.Items.Sum(item => item.Quantity),
                ProgressPercentage = 0,
                WarehouseId = null,
                WarehouseName = null,
                DeliveryAddress = null,
                Description = sale.Description,
                InternalNotes = sale.Notes,
                CreatedBy = sale.CreatedBy,
                CreatedByName = null,
                ApprovedBy = null,
                ApprovedByName = null,
                ApprovedAt = null,
                CreatedAt = sale.CreatedAt,
                UpdatedAt = sale.UpdatedAt,
                Items = sale.Items.Select(item => new CustomerOrderItemDto
                {
                    Id = item.Id,
                    ProductId = item.ProductId,
                    ProductName = item.Product?.Name ?? string.Empty,
                    ProductCode = item.Product?.Code ?? string.Empty,
                    Quantity = item.Quantity,
                    DeliveredQuantity = 0,
                    UnitPrice = item.UnitPrice,
                    DiscountPercentage = item.DiscountPercentage,
                    DiscountAmount = item.DiscountAmount,
                    UomId = null,
                    UomName = null,
                    Description = item.Description
                }).ToList()
            };

            result.Add(orderDto);
        }

        return result;
    }

    /// <summary>
    /// تبدیل وضعیت انگلیسی به فارسی
    /// </summary>
    private static string GetStatusPersian(string status)
    {
        return status.ToLower() switch
        {
            "draft" => "پیش‌نویس",
            "pending" => "در انتظار تایید",
            "approved" => "تایید شده",
            "confirmed" => "تایید شده",
            "processing" => "در حال پردازش",
            "shipped" => "ارسال شده",
            "delivered" => "تحویل داده شده",
            "cancelled" => "لغو شده",
            "completed" => "تکمیل شده",
            "returned" => "مرجوع شده",
            _ => status
        };
    }
}
