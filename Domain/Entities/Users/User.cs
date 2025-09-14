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
    public string PhoneNumber { get; set; }

    /// <summary>
    /// شماره تلفن (نام مستعار)
    /// Phone number (alias)
    /// </summary>
    public string Phone => PhoneNumber;

    /// <summary>
    /// شماره تلفن داخلی
    /// Internal phone number
    /// </summary>
    public string InternalPhone { get; set; }

    /// <summary>
    /// کد ملی
    /// National ID
    /// </summary>
    public string NationalId { get; set; }

    /// <summary>
    /// تاریخ تولد
    /// Birth date
    /// </summary>
    public DateTime? BirthDate { get; set; }

    /// <summary>
    /// هش رمز عبور
    /// Password hash
    /// </summary>
    public required string PasswordHash { get; set; }

    /// <summary>
    /// آدرس آواتار
    /// Avatar URL
    /// </summary>
    public string AvatarUrl { get; set; }

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
    /// تاریخ آخرین ورود (alias for LastLoginAt)
    /// Last login date alias
    /// </summary>
    public DateTime? LastLoginDate => LastLoginAt;

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
    /// شناسه نقش
    /// Role ID
    /// </summary>
    public Guid? RoleId { get; set; }

    /// <summary>
    /// تاریخ انقضا
    /// Expiry date
    /// </summary>
    public DateTime? ExpiryDate { get; set; }

    /// <summary>
    /// شناسه کسب‌وکار
    /// Business ID
    /// </summary>
    public Guid? BusinessId { get; set; }

    /// <summary>
    /// کسب‌وکار
    /// Business
    /// </summary>
    public Business? Business { get; set; }

    /// <summary>
    /// نقش
    /// Role
    /// </summary>
    public Role? Role { get; set; }

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

    /// <summary>
    /// پروفایل کاربر
    /// User profile
    /// </summary>
    public UserProfile? UserProfile { get; set; }
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
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

        builder.HasOne(e => e.Department)
            .WithMany(d => d.Users)
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

        builder.HasOne(e => e.UserProfile)
            .WithOne(p => p.User)
            .HasForeignKey<UserProfile>(p => p.UserId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

        builder.HasOne(e => e.Settings)
            .WithOne(s => s.User)
            .HasForeignKey<UserSettings>(s => s.UserId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

        builder.HasIndex(e => e.Username).IsUnique();
        builder.HasIndex(e => e.Email).IsUnique();
    }
}
