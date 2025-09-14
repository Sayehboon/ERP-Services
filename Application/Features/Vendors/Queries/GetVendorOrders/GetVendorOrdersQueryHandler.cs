using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Vendors.Queries.GetVendorOrders;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت سفارشات تامین‌کننده
/// </summary>
public sealed class GetVendorOrdersQueryHandler : IRequestHandler<GetVendorOrdersQuery, IEnumerable<VendorOrderDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت سفارشات تامین‌کننده
    /// </summary>
    public GetVendorOrdersQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو دریافت سفارشات تامین‌کننده
    /// </summary>
    public async Task<IEnumerable<VendorOrderDto>> Handle(GetVendorOrdersQuery request, CancellationToken cancellationToken)
    {
        var query = _context.PurchaseOrders
            .Include(po => po.Vendor)
            .Include(po => po.Items)
                .ThenInclude(item => item.Product)
            .Include(po => po.Items)
                .ThenInclude(item => item.Uom)
            .Where(po => po.VendorId == request.VendorId);

        // فیلتر بر اساس وضعیت
        if (!string.IsNullOrEmpty(request.Status))
        {
            query = query.Where(po => po.Status == request.Status);
        }

        // فیلتر بر اساس تاریخ
        if (request.FromDate.HasValue)
        {
            query = query.Where(po => po.OrderDate >= request.FromDate.Value);
        }

        if (request.ToDate.HasValue)
        {
            query = query.Where(po => po.OrderDate <= request.ToDate.Value);
        }

        // فیلتر بر اساس شماره سفارش
        if (!string.IsNullOrEmpty(request.OrderNumber))
        {
            query = query.Where(po => po.OrderNumber.Contains(request.OrderNumber));
        }

        var orders = await query
            .OrderByDescending(po => po.OrderDate)
            .Take(request.MaxResults)
            .ToListAsync(cancellationToken);

        var result = new List<VendorOrderDto>();

        foreach (var order in orders)
        {
            // محاسبه مبلغ پرداخت شده
            var paidAmount = await _context.PurchasePayments
                .Where(pp => pp.PurchaseOrderId == order.Id)
                .SumAsync(pp => pp.Amount, cancellationToken);

            // محاسبه مقدار تحویل شده برای هر آیتم
            var deliveredQuantities = await _context.PurchaseReceiptLines
                .Where(pri => pri.PurchaseOrderItemId != null && 
                             order.Items.Select(oi => oi.Id).Contains(pri.PurchaseOrderItemId.Value))
                .GroupBy(pri => pri.PurchaseOrderItemId)
                .ToDictionaryAsync(g => g.Key!.Value, g => g.Sum(pri => pri.ReceivedQuantity), cancellationToken);

            var orderDto = new VendorOrderDto
            {
                Id = order.Id,
                OrderNumber = order.OrderNumber,
                VendorId = order.VendorId,
                VendorName = order.Vendor?.Name ?? "نامشخص",
                OrderDate = order.OrderDate,
                ExpectedDeliveryDate = order.ExpectedDeliveryDate,
                ActualDeliveryDate = order.ActualDeliveryDate,
                Status = order.Status,
                StatusPersian = GetStatusPersian(order.Status),
                OrderType = order.OrderType ?? string.Empty,
                TotalAmount = order.TotalAmount,
                PaidAmount = paidAmount,
                Currency = order.Currency,
                ExchangeRate = order.ExchangeRate,
                TotalAmountInBaseCurrency = order.TotalAmountInBaseCurrency,
                ItemCount = order.Items.Count,
                TotalQuantity = order.Items.Sum(item => item.Quantity),
                ProgressPercentage = order.Items.Count > 0 ? 
                    (decimal)order.Items.Count(item => deliveredQuantities.ContainsKey(item.Id) && 
                                                      deliveredQuantities[item.Id] >= item.Quantity) / order.Items.Count * 100 : 0,
                WarehouseId = order.WarehouseId,
                WarehouseName = order.Warehouse?.Name,
                Description = order.Description,
                InternalNotes = order.InternalNotes,
                CreatedBy = order.CreatedBy,
                CreatedByName = order.CreatedByUser?.FirstName + " " + order.CreatedByUser?.LastName,
                ApprovedBy = order.ApprovedBy,
                ApprovedByName = order.ApprovedByUser?.FirstName + " " + order.ApprovedByUser?.LastName,
                ApprovedAt = order.ApprovedAt,
                CreatedAt = order.CreatedAt,
                UpdatedAt = order.UpdatedAt,
                Items = order.Items.Select(item => new VendorOrderItemDto
                {
                    Id = item.Id,
                    ProductId = item.ProductId,
                    ProductName = item.Product?.Name ?? "نامشخص",
                    ProductCode = item.Product?.Code ?? "نامشخص",
                    Quantity = item.Quantity,
                    DeliveredQuantity = deliveredQuantities.ContainsKey(item.Id) ? deliveredQuantities[item.Id] : 0,
                    UnitPrice = item.UnitPrice,
                    DiscountPercentage = item.DiscountPercentage,
                    DiscountAmount = item.DiscountAmount,
                    UomId = item.UomId,
                    UomName = item.Uom?.Name,
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
            "ordered" => "سفارش داده شده",
            "partially_received" => "جزئی دریافت شده",
            "received" => "دریافت شده",
            "cancelled" => "لغو شده",
            "completed" => "تکمیل شده",
            _ => status
        };
    }
}
