using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Customers.Commands.ToggleCustomerStatus;

/// <summary>
/// مدیریت‌کننده دستور تغییر وضعیت فعال/غیرفعال مشتری
/// </summary>
public sealed class ToggleCustomerStatusCommandHandler : IRequestHandler<ToggleCustomerStatusCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور تغییر وضعیت فعال/غیرفعال مشتری
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public ToggleCustomerStatusCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور تغییر وضعیت فعال/غیرفعال مشتری
    /// </summary>
    public async Task<bool> Handle(ToggleCustomerStatusCommand request, CancellationToken cancellationToken)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
        if (customer == null)
        {
            throw new ArgumentException($"مشتری با شناسه {request.Id} یافت نشد");
        }

        // بررسی اینکه آیا مشتری سفارشات فعال دارد یا خیر
        if (!request.IsActive)
        {
            var hasActiveOrders = await _context.SalesOrders
                .AnyAsync(so => so.CustomerId == request.Id && so.Status == "در حال انجام", cancellationToken);
            
            if (hasActiveOrders)
            {
                throw new InvalidOperationException("امکان غیرفعال کردن مشتری با سفارشات فعال وجود ندارد");
            }
        }

        customer.IsActive = request.IsActive;
        customer.UpdatedBy = request.UpdatedBy;
        customer.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
