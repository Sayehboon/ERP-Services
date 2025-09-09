using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Customers.Commands.DeleteCustomer;

/// <summary>
/// مدیریت‌کننده دستور حذف مشتری
/// </summary>
public sealed class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور حذف مشتری
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public DeleteCustomerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور حذف مشتری
    /// </summary>
    public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
        if (customer == null)
        {
            throw new ArgumentException($"مشتری با شناسه {request.Id} یافت نشد");
        }

        // بررسی وابستگی‌ها قبل از حذف
        var hasSalesOrders = await _context.SalesOrders
            .AnyAsync(so => so.CustomerId == request.Id, cancellationToken);
        
        if (hasSalesOrders)
        {
            throw new InvalidOperationException("امکان حذف مشتری به دلیل وجود سفارشات فروش وابسته وجود ندارد");
        }

        // موجودیت Contact ارتباط مستقیم با Customer ندارد
        var hasContacts = false;
        
        if (hasContacts)
        {
            throw new InvalidOperationException("امکان حذف مشتری به دلیل وجود مخاطبین وابسته وجود ندارد");
        }

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
