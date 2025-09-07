using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities;

namespace Dinawin.Erp.Application.Features.Sales.SalesOrders.Commands.CreateSalesOrder;

/// <summary>
/// مدیریت‌کننده دستور ایجاد سفارش فروش
/// </summary>
public sealed class CreateSalesOrderCommandHandler : IRequestHandler<CreateSalesOrderCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور ایجاد سفارش فروش
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public CreateSalesOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور ایجاد سفارش فروش
    /// </summary>
    public async Task<Guid> Handle(CreateSalesOrderCommand request, CancellationToken cancellationToken)
    {
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

        // بررسی یکتایی شماره سفارش
        var orderNumberExists = await _context.SalesOrders
            .AnyAsync(so => so.OrderNumber == request.OrderNumber, cancellationToken);
        if (orderNumberExists)
        {
            throw new ArgumentException($"سفارش با شماره {request.OrderNumber} قبلاً وجود دارد");
        }

        var salesOrder = new SalesOrder
        {
            Id = Guid.NewGuid(),
            OrderNumber = request.OrderNumber,
            CustomerId = request.CustomerId,
            OpportunityId = request.OpportunityId,
            OrderDate = request.OrderDate,
            ExpectedDeliveryDate = request.ExpectedDeliveryDate,
            ActualDeliveryDate = request.ActualDeliveryDate,
            Status = request.Status,
            OrderType = request.OrderType,
            WarehouseId = request.WarehouseId,
            AssignedToId = request.AssignedToId,
            CreatedById = request.CreatedById,
            TotalAmount = request.TotalAmount,
            DiscountAmount = request.DiscountAmount,
            TaxAmount = request.TaxAmount,
            FinalAmount = request.FinalAmount,
            Currency = request.Currency,
            ExchangeRate = request.ExchangeRate,
            PaymentMethod = request.PaymentMethod,
            PaymentTerms = request.PaymentTerms,
            DeliveryAddress = request.DeliveryAddress,
            Notes = request.Notes,
            CreatedBy = request.CreatedBy,
            CreatedAt = DateTime.UtcNow
        };

        _context.SalesOrders.Add(salesOrder);
        await _context.SaveChangesAsync(cancellationToken);
        return salesOrder.Id;
    }
}