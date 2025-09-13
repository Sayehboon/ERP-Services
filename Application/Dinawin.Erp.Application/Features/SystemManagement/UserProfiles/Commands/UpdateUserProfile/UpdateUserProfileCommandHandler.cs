using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Users;

namespace Dinawin.Erp.Application.Features.SystemManagement.UserProfiles.Commands.UpdateUserProfile;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی پروفایل کاربر
/// </summary>
public sealed class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی پروفایل کاربر
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateUserProfileCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی پروفایل کاربر
    /// </summary>
    public async Task<Guid> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
    {
        // بررسی وجود کاربر
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);
        if (user == null)
        {
            throw new ArgumentException($"کاربر با شناسه {request.UserId} یافت نشد");
        }

        // بررسی یکتایی کد ملی (اگر مشخص شده باشد)
        if (!string.IsNullOrWhiteSpace(request.NationalId))
        {
            var nationalIdExists = await _context.UserProfiles
                .AnyAsync(up => up.NationalId == request.NationalId && up.UserId != request.UserId, cancellationToken);
            if (nationalIdExists)
            {
                throw new ArgumentException($"کد ملی {request.NationalId} قبلاً استفاده شده است");
            }
        }

        // به‌روزرسانی اطلاعات کاربر
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.PhoneNumber = request.PhoneNumber;
        user.UpdatedBy = request.UpdatedBy;
        user.UpdatedAt = DateTime.UtcNow;

        // بررسی وجود پروفایل کاربر
        var userProfile = await _context.UserProfiles
            .FirstOrDefaultAsync(up => up.UserId == request.UserId, cancellationToken);

        if (userProfile == null)
        {
            // ایجاد پروفایل جدید
            userProfile = new UserProfile
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Address = request.Address,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                NationalId = request.NationalId,
                ProfileImageUrl = request.ProfileImageUrl,
                Bio = request.Bio,
                PreferredLanguage = request.PreferredLanguage,
                TimeZone = request.TimeZone,
                CreatedBy = request.UpdatedBy,
                CreatedAt = DateTime.UtcNow
            };
            _context.UserProfiles.Add(userProfile);
        }
        else
        {
            // به‌روزرسانی پروفایل موجود
            userProfile.Address = request.Address;
            userProfile.DateOfBirth = request.DateOfBirth;
            userProfile.Gender = request.Gender;
            userProfile.NationalId = request.NationalId;
            userProfile.ProfileImageUrl = request.ProfileImageUrl;
            userProfile.Bio = request.Bio;
            userProfile.PreferredLanguage = request.PreferredLanguage;
            userProfile.TimeZone = request.TimeZone;
            userProfile.UpdatedBy = request.UpdatedBy;
            userProfile.UpdatedAt = DateTime.UtcNow;
        }

        await _context.SaveChangesAsync(cancellationToken);
        return userProfile.Id;
    }
}
