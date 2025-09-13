namespace Dinawin.Erp.Domain.Entities.Users;

using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// موجودیت پروفایل کاربر
/// User profile entity
/// </summary>
public class UserProfile : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// نام
    /// First name
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// نام خانوادگی
    /// Last name
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// آدرس ایمیل
    /// Email address
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// شماره تلفن
    /// Phone number
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// آدرس آواتار
    /// Avatar URL
    /// </summary>
    public string? AvatarUrl { get; set; }

    /// <summary>
    /// کد ملی
    /// National ID
    /// </summary>
    public string? NationalId { get; set; }

    /// <summary>
    /// آدرس
    /// Address
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// تاریخ تولد
    /// Date of birth
    /// </summary>
    public DateTime? DateOfBirth { get; set; }

    /// <summary>
    /// جنسیت
    /// Gender
    /// </summary>
    public string? Gender { get; set; }

    /// <summary>
    /// آدرس تصویر پروفایل
    /// Profile image URL
    /// </summary>
    public string? ProfileImageUrl { get; set; }

    /// <summary>
    /// بیوگرافی
    /// Bio
    /// </summary>
    public string? Bio { get; set; }

    /// <summary>
    /// زبان ترجیحی
    /// Preferred language
    /// </summary>
    public string? PreferredLanguage { get; set; }

    /// <summary>
    /// منطقه زمانی
    /// Time zone
    /// </summary>
    public string? TimeZone { get; set; }

    /// <summary>
    /// فعال است؟
    /// Is active?
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// شناسه کاربر
    /// User ID
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// کاربر
    /// User
    /// </summary>
    public User User { get; set; } = null!;
}

/// <summary>
/// پیکربندی موجودیت پروفایل کاربر
/// User Profile entity configuration
/// </summary>
public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.FirstName).HasMaxLength(100);
        builder.Property(e => e.LastName).HasMaxLength(100);
        builder.Property(e => e.Email).HasMaxLength(200);
        builder.Property(e => e.Phone).HasMaxLength(20);
        builder.Property(e => e.AvatarUrl).HasMaxLength(500);
        builder.Property(e => e.NationalId).HasMaxLength(20);
        builder.Property(e => e.Address).HasMaxLength(500);
        builder.Property(e => e.Gender).HasMaxLength(10);
        builder.Property(e => e.ProfileImageUrl).HasMaxLength(500);
        builder.Property(e => e.Bio).HasMaxLength(1000);
        builder.Property(e => e.PreferredLanguage).HasMaxLength(10);
        builder.Property(e => e.TimeZone).HasMaxLength(50);

        builder.HasOne(e => e.User)
            .WithOne()
            .HasForeignKey<UserProfile>(e => e.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasIndex(e => e.UserId).IsUnique();
        builder.HasIndex(e => e.Email).IsUnique(false);
    }
}
