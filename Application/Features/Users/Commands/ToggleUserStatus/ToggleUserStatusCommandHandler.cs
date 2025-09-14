using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Users.Commands.ToggleUserStatus;

/// <summary>
/// پردازش‌کننده فرمان تغییر وضعیت کاربر
/// Toggle user status command handler
/// </summary>
public class ToggleUserStatusCommandHandler : IRequestHandler<ToggleUserStatusCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازش‌کننده فرمان تغییر وضعیت کاربر
    /// Toggle user status command handler constructor
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public ToggleUserStatusCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش فرمان تغییر وضعیت کاربر
    /// Handle toggle user status command
    /// </summary>
    /// <param name="request">درخواست تغییر وضعیت کاربر</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>نتیجه تغییر وضعیت</returns>
    public async Task<bool> Handle(ToggleUserStatusCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (user == null)
        {
            return false;
        }

        // تغییر وضعیت کاربر
        // Toggle user status
        user.IsActive = !request.CurrentStatus;

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
