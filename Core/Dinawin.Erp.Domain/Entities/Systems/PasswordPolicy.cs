using Dinawin.Erp.Domain.Common;
using Dinawin.Erp.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Systems;

/// <summary>
/// سیاست رمز عبور
/// Password Policy
/// </summary>
public class PasswordPolicy : BaseEntity, IAggregateRoot
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
    /// حداقل طول رمز عبور
    /// Minimum Password Length
    /// </summary>
    public int MinimumPasswordLength { get; set; } = 8;

    /// <summary>
    /// حداکثر طول رمز عبور
    /// Maximum Password Length
    /// </summary>
    public int MaximumPasswordLength { get; set; } = 128;

    /// <summary>
    /// آیا نیاز به حروف بزرگ است
    /// Requires Uppercase Letters
    /// </summary>
    public bool RequiresUppercase { get; set; } = true;

    /// <summary>
    /// آیا نیاز به حروف کوچک است
    /// Requires Lowercase Letters
    /// </summary>
    public bool RequiresLowercase { get; set; } = true;

    /// <summary>
    /// آیا نیاز به اعداد است
    /// Requires Numbers
    /// </summary>
    public bool RequiresNumbers { get; set; } = true;

    /// <summary>
    /// آیا نیاز به کاراکترهای خاص است
    /// Requires Special Characters
    /// </summary>
    public bool RequiresSpecialCharacters { get; set; } = true;

    /// <summary>
    /// کاراکترهای خاص مجاز
    /// Allowed Special Characters
    /// </summary>
    public string? AllowedSpecialCharacters { get; set; }

    /// <summary>
    /// حداقل تعداد کاراکترهای خاص
    /// Minimum Special Characters Count
    /// </summary>
    public int MinimumSpecialCharactersCount { get; set; } = 1;

    /// <summary>
    /// آیا رمز عبور نمی تواند شامل نام کاربری باشد
    /// Password Cannot Contain Username
    /// </summary>
    public bool CannotContainUsername { get; set; } = true;

    /// <summary>
    /// آیا رمز عبور نمی تواند شامل اطلاعات شخصی باشد
    /// Password Cannot Contain Personal Information
    /// </summary>
    public bool CannotContainPersonalInfo { get; set; } = true;

    /// <summary>
    /// حداکثر تعداد تلاش ناموفق
    /// Maximum Failed Attempts
    /// </summary>
    public int MaximumFailedAttempts { get; set; } = 5;

    /// <summary>
    /// مدت زمان قفل شدن (دقیقه)
    /// Lockout Duration (minutes)
    /// </summary>
    public int LockoutDurationMinutes { get; set; } = 30;

    /// <summary>
    /// مدت اعتبار رمز عبور (روز)
    /// Password Expiry Days
    /// </summary>
    public int PasswordExpiryDays { get; set; } = 90;

    /// <summary>
    /// تعداد رمزهای عبور قبلی که نمی توان استفاده کرد
    /// Password History Count
    /// </summary>
    public int PasswordHistoryCount { get; set; } = 5;

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
/// پیکربندی موجودیت سیاست رمز عبور
/// Password Policy entity configuration
/// </summary>
public class PasswordPolicyConfiguration : IEntityTypeConfiguration<PasswordPolicy>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<PasswordPolicy> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.PolicyName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(e => e.PolicyCode)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.AllowedSpecialCharacters)
            .HasMaxLength(200);

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
