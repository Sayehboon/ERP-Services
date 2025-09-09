using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Systems;

/// <summary>
/// حسابرسی جلسات
/// Session Audit
/// </summary>
public class SessionAudit : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه کاربر
    /// User ID
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// شناسه جلسه
    /// Session ID
    /// </summary>
    public string SessionId { get; set; } = string.Empty;

    /// <summary>
    /// تاریخ شروع جلسه
    /// Session Start Date
    /// </summary>
    public DateTime SessionStartDate { get; set; }

    /// <summary>
    /// تاریخ پایان جلسه
    /// Session End Date
    /// </summary>
    public DateTime? SessionEndDate { get; set; }

    /// <summary>
    /// آدرس IP
    /// IP Address
    /// </summary>
    public string? IpAddress { get; set; }

    /// <summary>
    /// User Agent
    /// User Agent
    /// </summary>
    public string? UserAgent { get; set; }

    /// <summary>
    /// نوع دستگاه
    /// Device Type
    /// </summary>
    public string? DeviceType { get; set; }

    /// <summary>
    /// سیستم عامل
    /// Operating System
    /// </summary>
    public string? OperatingSystem { get; set; }

    /// <summary>
    /// مرورگر
    /// Browser
    /// </summary>
    public string? Browser { get; set; }

    /// <summary>
    /// موقعیت جغرافیایی
    /// Geographic Location
    /// </summary>
    public string? GeographicLocation { get; set; }

    /// <summary>
    /// وضعیت جلسه
    /// Session Status
    /// </summary>
    public string SessionStatus { get; set; } = "active";

    /// <summary>
    /// دلیل پایان جلسه
    /// Session End Reason
    /// </summary>
    public string? SessionEndReason { get; set; }

    /// <summary>
    /// مدت زمان جلسه (دقیقه)
    /// Session Duration (minutes)
    /// </summary>
    public int? SessionDurationMinutes { get; set; }

    /// <summary>
    /// تعداد درخواست ها
    /// Request Count
    /// </summary>
    public int RequestCount { get; set; } = 0;

    /// <summary>
    /// آخرین فعالیت
    /// Last Activity
    /// </summary>
    public DateTime? LastActivity { get; set; }

    /// <summary>
    /// آیا جلسه امن است
    /// Is Secure Session
    /// </summary>
    public bool IsSecureSession { get; set; } = false;

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string? Description { get; set; }

    // Navigation Properties
    /// <summary>
    /// کاربر
    /// User
    /// </summary>
    public virtual User? User { get; set; }
}

/// <summary>
/// پیکربندی موجودیت حسابرسی جلسات
/// Session Audit entity configuration
/// </summary>
public class SessionAuditConfiguration : IEntityTypeConfiguration<SessionAudit>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<SessionAudit> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.SessionId)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.IpAddress)
            .HasMaxLength(45);

        builder.Property(e => e.UserAgent)
            .HasMaxLength(400);

        builder.Property(e => e.DeviceType)
            .HasMaxLength(100);

        builder.Property(e => e.OperatingSystem)
            .HasMaxLength(100);

        builder.Property(e => e.Browser)
            .HasMaxLength(100);

        builder.Property(e => e.GeographicLocation)
            .HasMaxLength(200);

        builder.Property(e => e.SessionStatus)
            .HasMaxLength(50);

        builder.Property(e => e.SessionEndReason)
            .HasMaxLength(200);

        builder.Property(e => e.Description)
            .HasMaxLength(1000);

        builder.HasOne(e => e.User)
            .WithMany()
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => e.SessionId).IsUnique();
        builder.HasIndex(e => e.UserId);
        builder.HasIndex(e => e.SessionStartDate);
    }
}
