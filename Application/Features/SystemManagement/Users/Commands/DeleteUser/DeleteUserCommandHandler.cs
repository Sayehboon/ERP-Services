using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.SystemManagement.Users.Commands.DeleteUser;

/// <summary>
/// مدیریت‌کننده دستور حذف کاربر
/// </summary>
public sealed class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور حذف کاربر
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public DeleteUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور حذف کاربر
    /// </summary>
    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
        if (user == null)
        {
            throw new ArgumentException($"کاربر با شناسه {request.Id} یافت نشد");
        }

        // بررسی وابستگی‌ها قبل از حذف
        var hasDependencies = await CheckUserDependencies(request.Id, cancellationToken);
        if (hasDependencies)
        {
            throw new InvalidOperationException("امکان حذف کاربر به دلیل وجود وابستگی‌ها وجود ندارد");
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    /// <summary>
    /// بررسی وابستگی‌های کاربر
    /// </summary>
    private async Task<bool> CheckUserDependencies(Guid userId, CancellationToken cancellationToken)
    {
        // بررسی وجود فعالیت‌های CRM
        var hasActivities = await _context.Activities
            .AnyAsync(a => a.AssignedToUserId == userId, cancellationToken);

        // بررسی وجود تیکت‌ها
        var hasTickets = await _context.Tickets
            .AnyAsync(t => t.AssignedToUserId == userId || t.CreatedByUserId == userId, cancellationToken);

        // بررسی وجود فرصت‌ها
        var hasOpportunities = await _context.Opportunities
            .AnyAsync(o => o.AssignedToUserId == userId || o.CreatedByUserId == userId, cancellationToken);

        // بررسی وجود سفارشات فروش
        var hasSalesOrders = await _context.SalesOrders
            .AnyAsync(so => so.CreatedByUserId == userId, cancellationToken);

        // بررسی وجود سفارشات خرید
        var hasPurchaseOrders = await _context.PurchaseOrders
            .AnyAsync(po => po.CreatedByUserId == userId, cancellationToken);

        return hasActivities || hasTickets || hasOpportunities || hasSalesOrders || hasPurchaseOrders;
    }
}
