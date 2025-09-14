using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.SystemManagement.Users.Commands.ToggleUserStatus;

/// <summary>
/// مدیریت‌کننده دستور تغییر وضعیت فعال/غیرفعال کاربر
/// </summary>
public sealed class ToggleUserStatusCommandHandler : IRequestHandler<ToggleUserStatusCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور تغییر وضعیت فعال/غیرفعال کاربر
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public ToggleUserStatusCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور تغییر وضعیت فعال/غیرفعال کاربر
    /// </summary>
    public async Task<bool> Handle(ToggleUserStatusCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
        if (user == null)
        {
            throw new ArgumentException($"کاربر با شناسه {request.Id} یافت نشد");
        }

        // بررسی اینکه آیا کاربر خودش را غیرفعال می‌کند یا خیر
        if (request.UpdatedBy == request.Id && !request.IsActive)
        {
            throw new InvalidOperationException("کاربر نمی‌تواند خودش را غیرفعال کند");
        }

        user.IsActive = request.IsActive;
        user.UpdatedBy = request.UpdatedBy;
        user.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
