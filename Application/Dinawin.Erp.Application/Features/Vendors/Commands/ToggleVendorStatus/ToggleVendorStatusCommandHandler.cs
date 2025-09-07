using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Vendors.Commands.ToggleVendorStatus;

/// <summary>
/// مدیریت‌کننده دستور تغییر وضعیت فعال/غیرفعال تامین‌کننده
/// </summary>
public sealed class ToggleVendorStatusCommandHandler : IRequestHandler<ToggleVendorStatusCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور تغییر وضعیت فعال/غیرفعال تامین‌کننده
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public ToggleVendorStatusCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور تغییر وضعیت فعال/غیرفعال تامین‌کننده
    /// </summary>
    public async Task<bool> Handle(ToggleVendorStatusCommand request, CancellationToken cancellationToken)
    {
        var vendor = await _context.Vendors.FirstOrDefaultAsync(v => v.Id == request.Id, cancellationToken);
        if (vendor == null)
        {
            throw new ArgumentException($"تامین‌کننده با شناسه {request.Id} یافت نشد");
        }

        // بررسی اینکه آیا تامین‌کننده سفارشات فعال دارد یا خیر
        if (!request.IsActive)
        {
            var hasActiveOrders = await _context.PurchaseOrders
                .AnyAsync(po => po.VendorId == request.Id && po.Status == "در حال انجام", cancellationToken);
            
            if (hasActiveOrders)
            {
                throw new InvalidOperationException("امکان غیرفعال کردن تامین‌کننده با سفارشات فعال وجود ندارد");
            }
        }

        vendor.IsActive = request.IsActive;
        vendor.UpdatedBy = request.UpdatedBy;
        vendor.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
