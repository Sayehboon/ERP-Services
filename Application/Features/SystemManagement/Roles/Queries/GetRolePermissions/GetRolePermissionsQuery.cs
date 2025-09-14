using MediatR;

namespace Dinawin.Erp.Application.Features.SystemManagement.Roles.Queries.GetRolePermissions;

/// <summary>
/// پرس‌وجو دریافت مجوزهای نقش
/// </summary>
public sealed class GetRolePermissionsQuery : IRequest<IEnumerable<PermissionDto>>
{
    /// <summary>
    /// شناسه نقش
    /// </summary>
    public required Guid RoleId { get; init; }
}
