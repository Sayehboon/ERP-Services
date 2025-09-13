using Dinawin.Erp.Domain.Common;
using Dinawin.Erp.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Systems;

/// <summary>
/// کاربران واحد سازمانی
/// User Organizational Units
/// </summary>
public class UserOrgUnit : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه کاربر
    /// User ID
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// شناسه واحد سازمانی
    /// Organizational Unit ID
    /// </summary>
    public Guid OrgUnitId { get; set; }

    /// <summary>
    /// نقش در واحد
    /// Role in Unit
    /// </summary>
    public string RoleInUnit { get; set; } = string.Empty;

    /// <summary>
    /// تاریخ شروع
    /// Start Date
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// تاریخ پایان
    /// End Date
    /// </summary>
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// آیا فعال است
    /// Is Active
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// آیا مدیر واحد است
    /// Is Unit Manager
    /// </summary>
    public bool IsUnitManager { get; set; } = false;

    /// <summary>
    /// سطح دسترسی
    /// Access Level
    /// </summary>
    public string? AccessLevel { get; set; }

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// شناسه کاربر ایجاد کننده
    /// Created By User ID
    /// </summary>
    public Guid CreatedByUserId { get; set; }

    /// <summary>
    /// تاریخ ایجاد
    /// Creation Date
    /// </summary>
    public DateTime CreationDate { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// شناسه کاربر آخرین ویرایش
    /// Last Modified By User ID
    /// </summary>
    public Guid? LastModifiedByUserId { get; set; }

    /// <summary>
    /// تاریخ آخرین ویرایش
    /// Last Modified Date
    /// </summary>
    public DateTime? LastModifiedDate { get; set; }

    // Navigation Properties
    /// <summary>
    /// کاربر
    /// User
    /// </summary>
    public virtual User? User { get; set; }

    /// <summary>
    /// واحد سازمانی
    /// Organizational Unit
    /// </summary>
    public virtual OrgUnit? OrgUnit { get; set; }

    /// <summary>
    /// کاربر ایجاد کننده
    /// Created By User
    /// </summary>
    public virtual User? CreatedByUser { get; set; }

    /// <summary>
    /// کاربر آخرین ویرایش
    /// Last Modified By User
    /// </summary>
    public virtual User? LastModifiedByUser { get; set; }
}

/// <summary>
/// پیکربندی موجودیت ارتباط کاربر و واحد سازمانی
/// User-OrgUnit link entity configuration
/// </summary>
public class UserOrgUnitConfiguration : IEntityTypeConfiguration<UserOrgUnit>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<UserOrgUnit> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.RoleInUnit)
            .HasMaxLength(100);

        builder.Property(e => e.AccessLevel)
            .HasMaxLength(100);

        builder.Property(e => e.Description)
            .HasMaxLength(1000);

        builder.HasOne(e => e.User)
            .WithMany()
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.OrgUnit)
            .WithMany(e => e.UnitUsers)
            .HasForeignKey(e => e.OrgUnitId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.CreatedByUser)
            .WithMany()
            .HasForeignKey(e => e.CreatedByUserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.LastModifiedByUser)
            .WithMany()
            .HasForeignKey(e => e.LastModifiedByUserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasIndex(e => new { e.UserId, e.OrgUnitId })
            .IsUnique();
    }
}
