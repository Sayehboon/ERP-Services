using MediatR;

namespace Dinawin.Erp.Application.Features.SystemManagement.Roles.Commands.AssignPermission;

/// <summary>
/// دستور تخصیص مجوز به نقش
/// </summary>
public sealed class AssignPermissionCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه نقش
    /// </summary>
    public required Guid RoleId { get; init; }

    /// <summary>
    /// شناسه مجوز
    /// </summary>
    public required Guid PermissionId { get; init; }
}
