using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Sales.SalesOrders.Commands.UpdateSalesOrder;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی سفارش فروش
/// </summary>
public sealed class UpdateSalesOrderCommandHandler : IRequestHandler<UpdateSalesOrderCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی سفارش فروش
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateSalesOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی سفارش فروش
    /// </summary>
    public async Task<Guid> Handle(UpdateSalesOrderCommand request, CancellationToken cancellationToken)
    {
        var salesOrder = await _context.SalesOrders.FirstOrDefaultAsync(so => so.Id == request.Id, cancellationToken);
        if (salesOrder == null)
        {
            throw new ArgumentException($"سفارش فروش با شناسه {request.Id} یافت نشد");
        }

        // بررسی وجود مشتری
        var customerExists = await _context.Customers
            .AnyAsync(c => c.Id == request.CustomerId, cancellationToken);
        if (!customerExists)
        {
            throw new ArgumentException($"مشتری با شناسه {request.CustomerId} یافت نشد");
        }

        // بررسی وجود فرصت
        if (request.OpportunityId.HasValue)
        {
            var opportunityExists = await _context.Opportunities
                .AnyAsync(o => o.Id == request.OpportunityId.Value, cancellationToken);
            if (!opportunityExists)
            {
                throw new ArgumentException($"فرصت با شناسه {request.OpportunityId} یافت نشد");
            }
        }

        // بررسی وجود انبار
        if (request.WarehouseId.HasValue)
        {
            var warehouseExists = await _context.Warehouses
                .AnyAsync(w => w.Id == request.WarehouseId.Value, cancellationToken);
            if (!warehouseExists)
            {
                throw new ArgumentException($"انبار با شناسه {request.WarehouseId} یافت نشد");
            }
        }

        // بررسی وجود کاربر مسئول
        if (request.AssignedToId.HasValue)
        {
            var userExists = await _context.Users
                .AnyAsync(u => u.Id == request.AssignedToId.Value, cancellationToken);
            if (!userExists)
            {
                throw new ArgumentException($"کاربر با شناسه {request.AssignedToId} یافت نشد");
            }
        }

        // بررسی وجود کاربر ایجاد کننده
        if (request.CreatedById.HasValue)
        {
            var userExists = await _context.Users
                .AnyAsync(u => u.Id == request.CreatedById.Value, cancellationToken);
            if (!userExists)
            {
                throw new ArgumentException($"کاربر با شناسه {request.CreatedById} یافت نشد");
            }
        }

        // بررسی یکتایی شماره سفارش (به جز خود سفارش)
        var orderNumberExists = await _context.SalesOrders
            .AnyAsync(so => so.OrderNumber == request.OrderNumber && so.Id != request.Id, cancellationToken);
        if (orderNumberExists)
        {
            throw new ArgumentException($"سفارش با شماره {request.OrderNumber} قبلاً وجود دارد");
        }

        salesOrder.OrderNumber = request.OrderNumber;
        salesOrder.CustomerId = request.CustomerId;
        salesOrder.OpportunityId = request.OpportunityId ?? Guid.Empty;
        salesOrder.OrderDate = request.OrderDate;
        salesOrder.ExpectedDeliveryDate = request.ExpectedDeliveryDate;
        salesOrder.ActualDeliveryDate = request.ActualDeliveryDate;
        salesOrder.Status = request.Status;
        salesOrder.Type = request.OrderType;
        salesOrder.WarehouseId = request.WarehouseId;
        salesOrder.AssignedTo = request.AssignedToId;
        salesOrder.CreatedByUserId = request.CreatedById;
        salesOrder.TotalAmount = request.TotalAmount;
        salesOrder.DiscountAmount = request.DiscountAmount;
        salesOrder.TaxAmount = request.TaxAmount;
        salesOrder.FinalAmount = request.FinalAmount;
        salesOrder.Currency = request.Currency;
        salesOrder.ExchangeRate = request.ExchangeRate;
        salesOrder.PaymentMethod = request.PaymentMethod;
        salesOrder.PaymentTerms = request.PaymentTerms;
        salesOrder.DeliveryAddress = request.DeliveryAddress;
        salesOrder.Notes = request.Notes;
        salesOrder.UpdatedBy = request.UpdatedBy;
        salesOrder.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return salesOrder.Id;
    }
}