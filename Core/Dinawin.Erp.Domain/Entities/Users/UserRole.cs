using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Users;

/// <summary>
/// موجودیت رابطه کاربر و نقش
/// User-Role relationship entity
/// </summary>
public class UserRole : BaseEntity
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
    /// تاریخ اعطای نقش
    /// Role granted date
    /// </summary>
    public DateTime GrantedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// تاریخ انقضای نقش
    /// Role expiry date
    /// </summary>
    public DateTime? ExpiresAt { get; set; }

    /// <summary>
    /// آیا نقش فعال است
    /// Is role active
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// آیا نقش منقضی شده است
    /// Is role expired
    /// </summary>
    public bool IsExpired => ExpiresAt.HasValue && ExpiresAt.Value < DateTime.UtcNow;

    /// <summary>
    /// شناسه کاربر اعطاکننده نقش
    /// Granted by user ID
    /// </summary>
    public Guid? GrantedBy { get; set; }

    /// <summary>
    /// یادداشت
    /// Notes
    /// </summary>
    public string? Notes { get; set; }
}
