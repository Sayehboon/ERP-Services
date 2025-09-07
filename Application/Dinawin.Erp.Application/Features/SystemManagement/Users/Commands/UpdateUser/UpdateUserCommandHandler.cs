using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.SystemManagement.Users.Commands.UpdateUser;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی کاربر
/// </summary>
public sealed class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی کاربر
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی کاربر
    /// </summary>
    public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
        if (user == null)
        {
            throw new ArgumentException($"کاربر با شناسه {request.Id} یافت نشد");
        }

        // بررسی یکتایی نام کاربری
        var usernameExists = await _context.Users
            .AnyAsync(u => u.Username == request.Username && u.Id != request.Id, cancellationToken);
        if (usernameExists)
        {
            throw new ArgumentException($"نام کاربری {request.Username} قبلاً استفاده شده است");
        }

        // بررسی یکتایی ایمیل
        var emailExists = await _context.Users
            .AnyAsync(u => u.Email == request.Email && u.Id != request.Id, cancellationToken);
        if (emailExists)
        {
            throw new ArgumentException($"ایمیل {request.Email} قبلاً استفاده شده است");
        }

        // بررسی وجود نقش
        var roleExists = await _context.Roles
            .AnyAsync(r => r.Id == request.RoleId, cancellationToken);
        if (!roleExists)
        {
            throw new ArgumentException($"نقش با شناسه {request.RoleId} یافت نشد");
        }

        // بررسی وجود شرکت (اگر مشخص شده باشد)
        if (request.CompanyId.HasValue)
        {
            var companyExists = await _context.Companies
                .AnyAsync(c => c.Id == request.CompanyId.Value, cancellationToken);
            if (!companyExists)
            {
                throw new ArgumentException($"شرکت با شناسه {request.CompanyId} یافت نشد");
            }
        }

        user.Username = request.Username;
        user.Email = request.Email;
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.PhoneNumber = request.PhoneNumber;
        user.RoleId = request.RoleId;
        user.CompanyId = request.CompanyId;
        user.IsActive = request.IsActive;
        user.UpdatedBy = request.UpdatedBy;
        user.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return user.Id;
    }
}
