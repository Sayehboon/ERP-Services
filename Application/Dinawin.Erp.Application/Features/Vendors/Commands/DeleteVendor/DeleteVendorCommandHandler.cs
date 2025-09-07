using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Vendors.Commands.DeleteVendor;

/// <summary>
/// مدیریت‌کننده دستور حذف تامین‌کننده
/// </summary>
public sealed class DeleteVendorCommandHandler : IRequestHandler<DeleteVendorCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور حذف تامین‌کننده
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public DeleteVendorCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور حذف تامین‌کننده
    /// </summary>
    public async Task<bool> Handle(DeleteVendorCommand request, CancellationToken cancellationToken)
    {
        var vendor = await _context.Vendors.FirstOrDefaultAsync(v => v.Id == request.Id, cancellationToken);
        if (vendor == null)
        {
            throw new ArgumentException($"تامین‌کننده با شناسه {request.Id} یافت نشد");
        }

        // بررسی وابستگی‌ها قبل از حذف
        var hasPurchaseOrders = await _context.PurchaseOrders
            .AnyAsync(po => po.VendorId == request.Id, cancellationToken);
        
        if (hasPurchaseOrders)
        {
            throw new InvalidOperationException("امکان حذف تامین‌کننده به دلیل وجود سفارشات خرید وابسته وجود ندارد");
        }

        var hasContacts = await _context.Contacts
            .AnyAsync(ct => ct.VendorId == request.Id, cancellationToken);
        
        if (hasContacts)
        {
            throw new InvalidOperationException("امکان حذف تامین‌کننده به دلیل وجود مخاطبین وابسته وجود ندارد");
        }

        _context.Vendors.Remove(vendor);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
