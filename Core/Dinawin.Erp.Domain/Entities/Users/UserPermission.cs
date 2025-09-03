using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Users;

/// <summary>
/// موجودیت رابطه کاربر و مجوز مستقیم
/// User-Permission direct relationship entity
/// </summary>
public class UserPermission : BaseEntity
{
    /// <summary>
    /// شناسه کاربر
    /// User ID
    /// </summary>
    public required Guid UserId { get; set; }

    /// <summary>
    /// کاربر
    /// User
    /// </summary>
    public User User { get; set; } = null!;

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
    /// تاریخ انقضای مجوز
    /// Permission expiry date
    /// </summary>
    public DateTime? ExpiresAt { get; set; }

    /// <summary>
    /// آیا مجوز فعال است
    /// Is permission active
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// آیا مجوز منقضی شده است
    /// Is permission expired
    /// </summary>
    public bool IsExpired => ExpiresAt.HasValue && ExpiresAt.Value < DateTime.UtcNow;

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
