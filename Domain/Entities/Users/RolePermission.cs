using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
    public string Notes { get; set; }
}

/// <summary>
/// پیکربندی موجودیت رابطه نقش و مجوز
/// Role-Permission relationship entity configuration
/// </summary>
public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Notes).HasMaxLength(1000);

        builder.HasOne(e => e.Role)
            .WithMany(r => r.RolePermissions)
            .HasForeignKey(e => e.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Permission)
            .WithMany(p => p.RolePermissions)
            .HasForeignKey(e => e.PermissionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => new { e.RoleId, e.PermissionId }).IsUnique();
    }
}
