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

        builder.HasOne(e => e.User)
            .WithOne()
            .HasForeignKey<UserProfile>(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => e.UserId).IsUnique();
        builder.HasIndex(e => e.Email).IsUnique(false);
    }
}
