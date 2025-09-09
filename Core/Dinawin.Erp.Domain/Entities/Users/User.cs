using Dinawin.Erp.Domain.Common;
using Dinawin.Erp.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Users;

/// <summary>
/// موجودیت کاربر
/// User entity
/// </summary>
public class User : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// نام
    /// First name
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// نام خانوادگی
    /// Last name
    /// </summary>
    public required string LastName { get; set; }

    /// <summary>
    /// نام کامل
    /// Full name
    /// </summary>
    public string FullName => $"{FirstName} {LastName}";

    /// <summary>
    /// نام کاربری
    /// Username
    /// </summary>
    public required string Username { get; set; }

    /// <summary>
    /// ایمیل
    /// Email address
    /// </summary>
    public required string Email { get; set; }

    /// <summary>
    /// شماره تلفن
    /// Phone number
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// هش رمز عبور
    /// Password hash
    /// </summary>
    public required string PasswordHash { get; set; }

    /// <summary>
    /// آدرس آواتار
    /// Avatar URL
    /// </summary>
    public string? AvatarUrl { get; set; }

    /// <summary>
    /// وضعیت فعال/غیرفعال
    /// Active status
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// آیا ایمیل تایید شده است
    /// Is email verified
    /// </summary>
    public bool IsEmailVerified { get; set; }

    /// <summary>
    /// آیا شماره تلفن تایید شده است
    /// Is phone verified
    /// </summary>
    public bool IsPhoneVerified { get; set; }

    /// <summary>
    /// تاریخ آخرین ورود
    /// Last login date
    /// </summary>
    public DateTime? LastLoginAt { get; set; }

    /// <summary>
    /// تعداد تلاش‌های ناموفق ورود
    /// Failed login attempts
    /// </summary>
    public int FailedLoginAttempts { get; set; }

    /// <summary>
    /// تاریخ قفل شدن حساب
    /// Account lockout end date
    /// </summary>
    public DateTime? LockoutEnd { get; set; }

    /// <summary>
    /// آیا حساب قفل شده است
    /// Is account locked
    /// </summary>
    public bool IsLocked => LockoutEnd.HasValue && LockoutEnd.Value > DateTime.UtcNow;

    /// <summary>
    /// شناسه شرکت
    /// Company ID
    /// </summary>
    public Guid? CompanyId { get; set; }

    /// <summary>
    /// شرکت
    /// Company
    /// </summary>
    public Company? Company { get; set; }

    /// <summary>
    /// شناسه بخش
    /// Department ID
    /// </summary>
    public Guid? DepartmentId { get; set; }

    /// <summary>
    /// بخش
    /// Department
    /// </summary>
    public Department? Department { get; set; }

    /// <summary>
    /// نقش‌های کاربر
    /// User roles
    /// </summary>
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    /// <summary>
    /// مجوزهای مستقیم کاربر
    /// Direct user permissions
    /// </summary>
    public ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();

    /// <summary>
    /// تنظیمات کاربر
    /// User settings
    /// </summary>
    public UserSettings? Settings { get; set; }
}

/// <summary>
/// پیکربندی موجودیت کاربر
/// User entity configuration
/// </summary>
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(e => e.LastName).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Username).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Email).IsRequired().HasMaxLength(100);
        builder.Property(e => e.PhoneNumber).HasMaxLength(20);
        builder.Property(e => e.PasswordHash).IsRequired().HasMaxLength(500);
        builder.Property(e => e.AvatarUrl).HasMaxLength(500);

        builder.HasOne(e => e.Company)
            .WithMany()
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.Department)
            .WithMany()
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(e => e.Username).IsUnique();
        builder.HasIndex(e => e.Email).IsUnique();
    }
}
