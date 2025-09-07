using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Purchase.PurchaseOrders.Commands.UpdatePurchaseOrder;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی سفارش خرید
/// </summary>
public sealed class UpdatePurchaseOrderCommandHandler : IRequestHandler<UpdatePurchaseOrderCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی سفارش خرید
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdatePurchaseOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی سفارش خرید
    /// </summary>
    public async Task<Guid> Handle(UpdatePurchaseOrderCommand request, CancellationToken cancellationToken)
    {
        var purchaseOrder = await _context.PurchaseOrders.FirstOrDefaultAsync(po => po.Id == request.Id, cancellationToken);
        if (purchaseOrder == null)
        {
            throw new ArgumentException($"سفارش خرید با شناسه {request.Id} یافت نشد");
        }

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

        // بررسی یکتایی شماره سفارش (به جز خود سفارش)
        var orderNumberExists = await _context.PurchaseOrders
            .AnyAsync(po => po.OrderNumber == request.OrderNumber && po.Id != request.Id, cancellationToken);
        if (orderNumberExists)
        {
            throw new ArgumentException($"سفارش خرید با شماره {request.OrderNumber} قبلاً وجود دارد");
        }

        purchaseOrder.OrderNumber = request.OrderNumber;
        purchaseOrder.VendorId = request.VendorId;
        purchaseOrder.OrderDate = request.OrderDate;
        purchaseOrder.ExpectedDeliveryDate = request.ExpectedDeliveryDate;
        purchaseOrder.ActualDeliveryDate = request.ActualDeliveryDate;
        purchaseOrder.Status = request.Status;
        purchaseOrder.OrderType = request.OrderType;
        purchaseOrder.WarehouseId = request.WarehouseId;
        purchaseOrder.AssignedToId = request.AssignedToId;
        purchaseOrder.CreatedById = request.CreatedById;
        purchaseOrder.TotalAmount = request.TotalAmount;
        purchaseOrder.DiscountAmount = request.DiscountAmount;
        purchaseOrder.TaxAmount = request.TaxAmount;
        purchaseOrder.FinalAmount = request.FinalAmount;
        purchaseOrder.Currency = request.Currency;
        purchaseOrder.ExchangeRate = request.ExchangeRate;
        purchaseOrder.PaymentMethod = request.PaymentMethod;
        purchaseOrder.PaymentTerms = request.PaymentTerms;
        purchaseOrder.DeliveryAddress = request.DeliveryAddress;
        purchaseOrder.Notes = request.Notes;
        purchaseOrder.UpdatedBy = request.UpdatedBy;
        purchaseOrder.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return purchaseOrder.Id;
    }
}
