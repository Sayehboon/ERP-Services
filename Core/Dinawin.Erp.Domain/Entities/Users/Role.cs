using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
    /// کد نقش
    /// Role code
    /// </summary>
    public string? Code { get; set; }

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
    /// آیا نقش سیستمی است (نام مستعار)
    /// Is system role (alias)
    /// </summary>
    public bool IsSystem => IsSystemRole;

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
    /// نقش والد (مطابق Supabase: parent_role_id)
    /// Parent role
    /// </summary>
    public Guid? ParentRoleId { get; set; }

    /// <summary>
    /// ناوبری نقش والد
    /// Parent role navigation
    /// </summary>
    public Role? ParentRole { get; set; }

    /// <summary>
    /// نقش‌های زیرمجموعه
    /// Child roles
    /// </summary>
    public ICollection<Role> Children { get; set; } = new List<Role>();

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

    /// <summary>
    /// مجوزهای این نقش (نام مستعار)
    /// Role permissions (alias)
    /// </summary>
    public ICollection<RolePermission> Permissions => RolePermissions;
}

/// <summary>
/// پیکربندی موجودیت نقش
/// Role entity configuration
/// </summary>
public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Code).HasMaxLength(50);
        builder.Property(e => e.DisplayName).IsRequired().HasMaxLength(150);
        builder.Property(e => e.Description).HasMaxLength(500);
        builder.Property(e => e.Color).HasMaxLength(20);

        builder.HasOne(e => e.ParentRole)
            .WithMany(e => e.Children)
            .HasForeignKey(e => e.ParentRoleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.Name).IsUnique();
        builder.HasIndex(e => e.DisplayName);
    }
}
