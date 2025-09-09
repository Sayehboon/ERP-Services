using MediatR;

namespace Dinawin.Erp.Application.Features.SystemManagement.UserProfiles.Commands.ChangePassword;

/// <summary>
/// دستور تغییر رمز عبور
/// </summary>
public sealed class ChangePasswordCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه کاربر
    /// </summary>
    public required Guid UserId { get; init; }

    /// <summary>
    /// رمز عبور فعلی
    /// </summary>
    public required string CurrentPassword { get; init; }

    /// <summary>
    /// رمز عبور جدید
    /// </summary>
    public required string NewPassword { get; init; }

    /// <summary>
    /// تایید رمز عبور جدید
    /// </summary>
    public required string ConfirmNewPassword { get; init; }
}
