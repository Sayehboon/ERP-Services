using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Users;

/// <summary>
/// موجودیت نقش
/// Role entity
/// </summary>
public class Role : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// نام نقش
    /// Role name
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// نام نمایشی نقش
    /// Role display name
    /// </summary>
    public required string DisplayName { get; set; }

    /// <summary>
    /// توضیحات نقش
    /// Role description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// وضعیت فعال/غیرفعال
    /// Active status
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// آیا نقش سیستمی است
    /// Is system role
    /// </summary>
    public bool IsSystemRole { get; set; }

    /// <summary>
    /// اولویت نقش
    /// Role priority
    /// </summary>
    public int Priority { get; set; }

    /// <summary>
    /// رنگ نقش برای نمایش
    /// Role color for display
    /// </summary>
    public string? Color { get; set; }

    /// <summary>
    /// کاربران دارای این نقش
    /// Users with this role
    /// </summary>
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    /// <summary>
    /// مجوزهای این نقش
    /// Role permissions
    /// </summary>
    public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}
