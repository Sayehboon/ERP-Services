using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.SystemManagement.UserProfiles.Queries.GetUserProfile;

/// <summary>
/// پرس‌وجو دریافت پروفایل کاربر
/// </summary>
public sealed class GetUserProfileQuery : IRequest<UserProfileDto>
{
    /// <summary>
    /// شناسه کاربر
    /// </summary>
    [Required(ErrorMessage = "شناسه کاربر الزامی است")]
    public Guid UserId { get; set; }
}
