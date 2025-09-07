using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Sales.SalesOrders.Commands.DeleteSalesOrder;

/// <summary>
/// مدیریت‌کننده دستور حذف سفارش فروش
/// </summary>
public sealed class DeleteSalesOrderCommandHandler : IRequestHandler<DeleteSalesOrderCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور حذف سفارش فروش
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public DeleteSalesOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور حذف سفارش فروش
    /// </summary>
    public async Task<bool> Handle(DeleteSalesOrderCommand request, CancellationToken cancellationToken)
    {
        var salesOrder = await _context.SalesOrders.FirstOrDefaultAsync(so => so.Id == request.Id, cancellationToken);
        if (salesOrder == null)
        {
            throw new ArgumentException($"سفارش فروش با شناسه {request.Id} یافت نشد");
        }

        // بررسی وجود آیتم‌های سفارش
        var hasOrderItems = await _context.SalesOrderItems.AnyAsync(soi => soi.SalesOrderId == request.Id, cancellationToken);
        if (hasOrderItems)
        {
            throw new InvalidOperationException("امکان حذف سفارش فروش وجود ندارد زیرا دارای آیتم است");
        }

        // بررسی تبدیل شدن به فاکتور فروش
        var hasInvoices = await _context.SalesInvoices.AnyAsync(si => si.SalesOrderId == request.Id, cancellationToken);
        if (hasInvoices)
        {
            throw new InvalidOperationException("امکان حذف سفارش فروش وجود ندارد زیرا به فاکتور فروش تبدیل شده است");
        }

        // بررسی وجود تیکت‌های مرتبط
        var hasTickets = await _context.Tickets.AnyAsync(t => t.SalesOrderId == request.Id, cancellationToken);
        if (hasTickets)
        {
            throw new InvalidOperationException("امکان حذف سفارش فروش وجود ندارد زیرا دارای تیکت مرتبط است");
        }

        _context.SalesOrders.Remove(salesOrder);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
