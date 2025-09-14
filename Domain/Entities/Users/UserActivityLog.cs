using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Users;

/// <summary>
/// لاگ فعالیت کاربر (مطابق Supabase: user_activity_logs)
/// User activity log entity
/// </summary>
public class UserActivityLog : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه کاربر (auth)
    /// User id
    /// </summary>
    public Guid? UserId { get; set; }

    /// <summary>
    /// نوع فعالیت
    /// Activity type
    /// </summary>
    public required string ActivityType { get; set; }

    /// <summary>
    /// داده‌های فعالیت (JSON)
    /// Activity data (JSON)
    /// </summary>
    public string ActivityDataJson { get; set; }

    /// <summary>
    /// آدرس IP
    /// IP address
    /// </summary>
    public string IpAddress { get; set; }

    /// <summary>
    /// مرورگر/عامل کاربر
    /// User agent
    /// </summary>
    public string UserAgent { get; set; }
}

/// <summary>
/// پیکربندی موجودیت لاگ فعالیت کاربر
/// User Activity Log entity configuration
/// </summary>
public class UserActivityLogConfiguration : IEntityTypeConfiguration<UserActivityLog>
{
    public void Configure(EntityTypeBuilder<UserActivityLog> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.ActivityType).IsRequired().HasMaxLength(100);
        builder.Property(e => e.ActivityDataJson).HasMaxLength(4000);
        builder.Property(e => e.IpAddress).HasMaxLength(45);
        builder.Property(e => e.UserAgent).HasMaxLength(500);

        builder.HasIndex(e => e.UserId);
        builder.HasIndex(e => e.ActivityType);
        builder.HasIndex(e => e.CreatedAt);
    }
}

