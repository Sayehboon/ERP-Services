using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Systems;

/// <summary>
/// سیاست ورود به سیستم
/// Login Policy
/// </summary>
public class LoginPolicy : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// نام سیاست
    /// Policy Name
    /// </summary>
    public string PolicyName { get; set; } = string.Empty;

    /// <summary>
    /// کد سیاست
    /// Policy Code
    /// </summary>
    public string PolicyCode { get; set; } = string.Empty;

    /// <summary>
    /// حداکثر تعداد جلسات همزمان
    /// Maximum Concurrent Sessions
    /// </summary>
    public int MaximumConcurrentSessions { get; set; } = 1;

    /// <summary>
    /// مدت زمان عدم فعالیت قبل از خروج خودکار (دقیقه)
    /// Inactivity Timeout Minutes
    /// </summary>
    public int InactivityTimeoutMinutes { get; set; } = 30;

    /// <summary>
    /// مدت زمان جلسه (دقیقه)
    /// Session Duration Minutes
    /// </summary>
    public int SessionDurationMinutes { get; set; } = 480;

    /// <summary>
    /// آیا ورود از IP های مختلف مجاز است
    /// Allow Login From Different IPs
    /// </summary>
    public bool AllowLoginFromDifferentIPs { get; set; } = true;

    /// <summary>
    /// لیست IP های مجاز
    /// Allowed IP Addresses
    /// </summary>
    public string? AllowedIpAddresses { get; set; }

    /// <summary>
    /// لیست IP های ممنوع
    /// Blocked IP Addresses
    /// </summary>
    public string? BlockedIpAddresses { get; set; }

    /// <summary>
    /// آیا ورود در ساعات خاص مجاز است
    /// Allow Login During Specific Hours
    /// </summary>
    public bool AllowLoginDuringSpecificHours { get; set; } = false;

    /// <summary>
    /// ساعات مجاز ورود
    /// Allowed Login Hours
    /// </summary>
    public string? AllowedLoginHours { get; set; }

    /// <summary>
    /// آیا ورود در روزهای خاص مجاز است
    /// Allow Login On Specific Days
    /// </summary>
    public bool AllowLoginOnSpecificDays { get; set; } = false;

    /// <summary>
    /// روزهای مجاز ورود
    /// Allowed Login Days
    /// </summary>
    public string? AllowedLoginDays { get; set; }

    /// <summary>
    /// آیا نیاز به تایید دو مرحله ای است
    /// Requires Two Factor Authentication
    /// </summary>
    public bool RequiresTwoFactorAuthentication { get; set; } = false;

    /// <summary>
    /// نوع تایید دو مرحله ای
    /// Two Factor Authentication Type
    /// </summary>
    public string? TwoFactorAuthenticationType { get; set; }

    /// <summary>
    /// آیا ورود از دستگاه های جدید نیاز به تایید دارد
    /// New Device Login Requires Approval
    /// </summary>
    public bool NewDeviceLoginRequiresApproval { get; set; } = false;

    /// <summary>
    /// آیا فعال است
    /// Is Active
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// تاریخ شروع اعتبار
    /// Effective Start Date
    /// </summary>
    public DateTime? EffectiveStartDate { get; set; }

    /// <summary>
    /// تاریخ پایان اعتبار
    /// Effective End Date
    /// </summary>
    public DateTime? EffectiveEndDate { get; set; }

    /// <summary>
    /// شناسه کاربر ایجاد کننده
    /// Created By User ID
    /// </summary>
    public Guid CreatedByUserId { get; set; }

    /// <summary>
    /// شناسه کاربر آخرین ویرایش
    /// Last Modified By User ID
    /// </summary>
    public Guid? LastModifiedByUserId { get; set; }

    // Navigation Properties
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
/// پیکربندی موجودیت سیاست ورود
/// Login Policy entity configuration
/// </summary>
public class LoginPolicyConfiguration : IEntityTypeConfiguration<LoginPolicy>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<LoginPolicy> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.PolicyName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(e => e.PolicyCode)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.AllowedIpAddresses)
            .HasMaxLength(1000);

        builder.Property(e => e.BlockedIpAddresses)
            .HasMaxLength(1000);

        builder.Property(e => e.AllowedLoginHours)
            .HasMaxLength(200);

        builder.Property(e => e.AllowedLoginDays)
            .HasMaxLength(200);

        builder.Property(e => e.TwoFactorAuthenticationType)
            .HasMaxLength(100);

        builder.Property(e => e.Description)
            .HasMaxLength(1000);

        builder.HasOne(e => e.CreatedByUser)
            .WithMany()
            .HasForeignKey(e => e.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.LastModifiedByUser)
            .WithMany()
            .HasForeignKey(e => e.LastModifiedByUserId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(e => e.PolicyCode)
            .IsUnique();
    }
}
