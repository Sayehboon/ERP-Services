using MediatR;

namespace Dinawin.Erp.Application.Features.Users.Commands.ToggleUserStatus;

/// <summary>
/// فرمان تغییر وضعیت کاربر
/// Command for toggling user status
/// </summary>
public record ToggleUserStatusCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه کاربر
    /// User ID
    /// </summary>
    public required Guid UserId { get; init; }

    /// <summary>
    /// وضعیت فعلی کاربر
    /// Current user status
    /// </summary>
    public required bool CurrentStatus { get; init; }
}
