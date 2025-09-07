using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.SystemManagement.UserProfiles.Queries.GetUserProfile;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت پروفایل کاربر
/// </summary>
public sealed class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, UserProfileDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت پروفایل کاربر
    /// </summary>
    public GetUserProfileQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// اجرای پرس‌وجو
    /// </summary>
    public async Task<UserProfileDto?> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .Include(u => u.Role)
            .Include(u => u.Company)
            .Include(u => u.UserProfile)
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (user == null)
        {
            return null;
        }

        return new UserProfileDto
        {
            Id = user.UserProfile?.Id ?? Guid.Empty,
            UserId = user.Id,
            Username = user.Username,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            Address = user.UserProfile?.Address,
            DateOfBirth = user.UserProfile?.DateOfBirth,
            Gender = user.UserProfile?.Gender,
            NationalId = user.UserProfile?.NationalId,
            ProfileImageUrl = user.UserProfile?.ProfileImageUrl,
            Bio = user.UserProfile?.Bio,
            PreferredLanguage = user.UserProfile?.PreferredLanguage ?? "fa",
            TimeZone = user.UserProfile?.TimeZone ?? "Asia/Tehran",
            RoleName = user.Role?.Name ?? string.Empty,
            CompanyName = user.Company?.Name,
            IsActive = user.IsActive,
            CreatedAt = user.UserProfile?.CreatedAt ?? user.CreatedAt,
            UpdatedAt = user.UserProfile?.UpdatedAt ?? user.UpdatedAt
        };
    }
}
