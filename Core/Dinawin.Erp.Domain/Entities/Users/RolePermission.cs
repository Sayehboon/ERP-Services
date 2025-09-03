using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Users;

/// <summary>
/// موجودیت رابطه نقش و مجوز
/// Role-Permission relationship entity
/// </summary>
public class RolePermission : BaseEntity
{
    /// <summary>
    /// شناسه نقش
    /// Role ID
    /// </summary>
    public required Guid RoleId { get; set; }

    /// <summary>
    /// نقش
    /// Role
    /// </summary>
    public Role Role { get; set; } = null!;

    /// <summary>
    /// شناسه مجوز
    /// Permission ID
    /// </summary>
    public required Guid PermissionId { get; set; }

    /// <summary>
    /// مجوز
    /// Permission
    /// </summary>
    public Permission Permission { get; set; } = null!;

    /// <summary>
    /// تاریخ اعطای مجوز
    /// Permission granted date
    /// </summary>
    public DateTime GrantedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// آیا مجوز فعال است
    /// Is permission active
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// شناسه کاربر اعطاکننده مجوز
    /// Granted by user ID
    /// </summary>
    public Guid? GrantedBy { get; set; }

    /// <summary>
    /// یادداشت
    /// Notes
    /// </summary>
    public string? Notes { get; set; }
}
