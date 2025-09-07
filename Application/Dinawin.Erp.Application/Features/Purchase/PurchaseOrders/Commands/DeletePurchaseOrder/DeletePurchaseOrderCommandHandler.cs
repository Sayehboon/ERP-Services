using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Purchase.PurchaseOrders.Commands.DeletePurchaseOrder;

/// <summary>
/// مدیریت‌کننده دستور حذف سفارش خرید
/// </summary>
public sealed class DeletePurchaseOrderCommandHandler : IRequestHandler<DeletePurchaseOrderCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور حذف سفارش خرید
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public DeletePurchaseOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور حذف سفارش خرید
    /// </summary>
    public async Task<bool> Handle(DeletePurchaseOrderCommand request, CancellationToken cancellationToken)
    {
        var purchaseOrder = await _context.PurchaseOrders.FirstOrDefaultAsync(po => po.Id == request.Id, cancellationToken);
        if (purchaseOrder == null)
        {
            throw new ArgumentException($"سفارش خرید با شناسه {request.Id} یافت نشد");
        }

        // بررسی وجود آیتم‌های سفارش
        var hasOrderItems = await _context.PurchaseOrderItems.AnyAsync(poi => poi.PurchaseOrderId == request.Id, cancellationToken);
        if (hasOrderItems)
        {
            throw new InvalidOperationException("امکان حذف سفارش خرید وجود ندارد زیرا دارای آیتم است");
        }

        // بررسی تبدیل شدن به فاکتور خرید
        var hasBills = await _context.PurchaseBills.AnyAsync(pb => pb.PurchaseOrderId == request.Id, cancellationToken);
        if (hasBills)
        {
            throw new InvalidOperationException("امکان حذف سفارش خرید وجود ندارد زیرا به فاکتور خرید تبدیل شده است");
        }

        _context.PurchaseOrders.Remove(purchaseOrder);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}