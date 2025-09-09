using MediatR;

namespace Dinawin.Erp.Application.Features.SystemManagement.UserProfiles.Queries.GetCurrentUserProfile;

/// <summary>
/// پرس‌وجو دریافت پروفایل کاربر فعلی
/// </summary>
public sealed class GetCurrentUserProfileQuery : IRequest<CurrentUserProfileDto?>
{
    /// <summary>
    /// شناسه کاربر فعلی
    /// </summary>
    public required Guid UserId { get; init; }
}
