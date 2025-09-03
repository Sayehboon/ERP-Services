namespace Dinawin.Erp.Domain.Entities.Users;

using Dinawin.Erp.Domain.Common;

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
