namespace Dinawin.Erp.Application.Features.Users.Queries.Dtos;

/// <summary>
/// DTO پروفایل کاربر
/// User profile Data Transfer Object
/// </summary>
public class UserProfileDto
{
    /// <summary>
    /// شناسه کاربر
    /// User ID
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// نام
    /// First name
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// نام خانوادگی
    /// Last name
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// نام کامل
    /// Full name
    /// </summary>
    public string FullName => $"{FirstName} {LastName}";

    /// <summary>
    /// نام کاربری
    /// Username
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// ایمیل
    /// Email address
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// شماره تلفن
    /// Phone number
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// آدرس آواتار
    /// Avatar URL
    /// </summary>
    public string? AvatarUrl { get; set; }

    /// <summary>
    /// وضعیت فعال/غیرفعال
    /// Active status
    /// </summary>
    public bool IsActive { get; set; }

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
    /// شناسه شرکت
    /// Company ID
    /// </summary>
    public Guid? CompanyId { get; set; }

    /// <summary>
    /// نام شرکت
    /// Company name
    /// </summary>
    public string? CompanyName { get; set; }

    /// <summary>
    /// شناسه بخش
    /// Department ID
    /// </summary>
    public Guid? DepartmentId { get; set; }

    /// <summary>
    /// نام بخش
    /// Department name
    /// </summary>
    public string? DepartmentName { get; set; }

    /// <summary>
    /// نقش اصلی کاربر
    /// Primary user role
    /// </summary>
    public string? RoleName { get; set; }

    /// <summary>
    /// تاریخ ایجاد
    /// Creation date
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// تاریخ بروزرسانی
    /// Last update date
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}
