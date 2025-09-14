using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Users;

/// <summary>
/// موجودیت مجوز
/// Permission entity
/// </summary>
public class Permission : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// نام مجوز
    /// Permission name
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// نام نمایشی مجوز
    /// Permission display name
    /// </summary>
    public required string DisplayName { get; set; }

    /// <summary>
    /// توضیحات مجوز
    /// Permission description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// گروه مجوز
    /// Permission group
    /// </summary>
    public required string Group { get; set; }

    /// <summary>
    /// کنترلر مرتبط
    /// Related controller
    /// </summary>
    public string Controller { get; set; }

    /// <summary>
    /// اکشن مرتبط
    /// Related action
    /// </summary>
    public string Action { get; set; }

    /// <summary>
    /// منابع مجاز
    /// Allowed resources
    /// </summary>
    public string Resource { get; set; }

    /// <summary>
    /// وضعیت فعال/غیرفعال
    /// Active status
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// آیا مجوز سیستمی است
    /// Is system permission
    /// </summary>
    public bool IsSystemPermission { get; set; }

    /// <summary>
    /// ترتیب نمایش
    /// Display order
    /// </summary>
    public int SortOrder { get; set; }

    /// <summary>
    /// نقش‌هایی که این مجوز را دارند
    /// Roles that have this permission
    /// </summary>
    public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

    /// <summary>
    /// کاربرانی که مستقیماً این مجوز را دارند
    /// Users that have this permission directly
    /// </summary>
    public ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();
}

/// <summary>
/// پیکربندی موجودیت مجوز
/// Permission entity configuration
/// </summary>
public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).IsRequired().HasMaxLength(200);
        builder.Property(e => e.DisplayName).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Description).HasMaxLength(1000);
        builder.Property(e => e.Group).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Controller).HasMaxLength(100);
        builder.Property(e => e.Action).HasMaxLength(100);
        builder.Property(e => e.Resource).HasMaxLength(200);

        builder.HasIndex(e => e.Name).IsUnique();
        builder.HasIndex(e => e.Group);
        builder.HasIndex(e => e.Controller);
        builder.HasIndex(e => e.Action);
    }
}
