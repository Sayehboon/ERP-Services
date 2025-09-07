using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities;

namespace Dinawin.Erp.Application.Features.Purchase.PurchaseOrders.Commands.CreatePurchaseOrder;

/// <summary>
/// مدیریت‌کننده دستور ایجاد سفارش خرید
/// </summary>
public sealed class CreatePurchaseOrderCommandHandler : IRequestHandler<CreatePurchaseOrderCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور ایجاد سفارش خرید
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public CreatePurchaseOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور ایجاد سفارش خرید
    /// </summary>
    public async Task<Guid> Handle(CreatePurchaseOrderCommand request, CancellationToken cancellationToken)
    {
        // بررسی وجود تامین‌کننده
        var vendorExists = await _context.Vendors
            .AnyAsync(v => v.Id == request.VendorId, cancellationToken);
        if (!vendorExists)
        {
            throw new ArgumentException($"تامین‌کننده با شناسه {request.VendorId} یافت نشد");
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
        var orderNumberExists = await _context.PurchaseOrders
            .AnyAsync(po => po.OrderNumber == request.OrderNumber, cancellationToken);
        if (orderNumberExists)
        {
            throw new ArgumentException($"سفارش خرید با شماره {request.OrderNumber} قبلاً وجود دارد");
        }

        var purchaseOrder = new PurchaseOrder
        {
            Id = Guid.NewGuid(),
            OrderNumber = request.OrderNumber,
            VendorId = request.VendorId,
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

        _context.PurchaseOrders.Add(purchaseOrder);
        await _context.SaveChangesAsync(cancellationToken);
        return purchaseOrder.Id;
    }
}