using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using BCrypt.Net;

namespace Dinawin.Erp.Application.Features.SystemManagement.UserProfiles.Commands.ChangePassword;

/// <summary>
/// پردازش‌کننده دستور تغییر رمز عبور
/// </summary>
public sealed class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازش‌کننده دستور تغییر رمز عبور
    /// </summary>
    public ChangePasswordCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش دستور تغییر رمز عبور
    /// </summary>
    public async Task<bool> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        // بررسی تطابق رمز عبور جدید و تایید آن
        if (request.NewPassword != request.ConfirmNewPassword)
        {
            throw new ArgumentException("رمز عبور جدید و تایید آن مطابقت ندارند");
        }

        // بررسی حداقل طول رمز عبور
        if (request.NewPassword.Length < 6)
        {
            throw new ArgumentException("رمز عبور باید حداقل 6 کاراکتر باشد");
        }

        // دریافت کاربر
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (user == null)
        {
            throw new ArgumentException("کاربر یافت نشد");
        }

        // بررسی رمز عبور فعلی
        if (!BCrypt.Net.BCrypt.Verify(request.CurrentPassword, user.PasswordHash))
        {
            throw new ArgumentException("رمز عبور فعلی اشتباه است");
        }

        // بررسی اینکه رمز عبور جدید با رمز عبور فعلی متفاوت باشد
        if (BCrypt.Net.BCrypt.Verify(request.NewPassword, user.PasswordHash))
        {
            throw new ArgumentException("رمز عبور جدید باید با رمز عبور فعلی متفاوت باشد");
        }

        // هش کردن رمز عبور جدید
        var newPasswordHash = BCrypt.Net.BCrypt.HashPassword(request.NewPassword, BCrypt.Net.BCrypt.GenerateSalt(12));

        // به‌روزرسانی رمز عبور
        user.PasswordHash = newPasswordHash;
        user.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
