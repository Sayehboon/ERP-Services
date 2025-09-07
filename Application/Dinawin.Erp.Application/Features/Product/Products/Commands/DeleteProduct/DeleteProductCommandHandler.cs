using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Product.Products.Commands.DeleteProduct;

/// <summary>
/// مدیریت‌کننده دستور حذف محصول
/// </summary>
public sealed class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور حذف محصول
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public DeleteProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور حذف محصول
    /// </summary>
    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (product == null)
        {
            throw new ArgumentException($"محصول با شناسه {request.Id} یافت نشد");
        }

        // بررسی وجود آیتم‌های سفارش فروش
        var hasSalesOrderItems = await _context.SalesOrderItems.AnyAsync(soi => soi.ProductId == request.Id, cancellationToken);
        if (hasSalesOrderItems)
        {
            throw new InvalidOperationException("امکان حذف محصول وجود ندارد زیرا در سفارش‌های فروش استفاده شده است");
        }

        // بررسی وجود آیتم‌های سفارش خرید
        var hasPurchaseOrderItems = await _context.PurchaseOrderItems.AnyAsync(poi => poi.ProductId == request.Id, cancellationToken);
        if (hasPurchaseOrderItems)
        {
            throw new InvalidOperationException("امکان حذف محصول وجود ندارد زیرا در سفارش‌های خرید استفاده شده است");
        }

        // بررسی وجود تیکت‌های مرتبط
        var hasTickets = await _context.Tickets.AnyAsync(t => t.ProductId == request.Id, cancellationToken);
        if (hasTickets)
        {
            throw new InvalidOperationException("امکان حذف محصول وجود ندارد زیرا دارای تیکت مرتبط است");
        }

        // بررسی وجود حرکات موجودی
        var hasInventoryMovements = await _context.InventoryMovements.AnyAsync(im => im.ProductId == request.Id, cancellationToken);
        if (hasInventoryMovements)
        {
            throw new InvalidOperationException("امکان حذف محصول وجود ندارد زیرا دارای حرکت موجودی است");
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}