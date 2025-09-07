namespace Dinawin.Erp.Application.Features.SystemManagement.UserProfiles.Queries.GetUserProfile;

/// <summary>
/// DTO پروفایل کاربر
/// </summary>
public class UserProfileDto
{
    /// <summary>
    /// شناسه پروفایل
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// شناسه کاربر
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// نام کاربری
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// ایمیل
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// نام
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// نام خانوادگی
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// نام کامل
    /// </summary>
    public string FullName => $"{FirstName} {LastName}";

    /// <summary>
    /// شماره تلفن
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// آدرس
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// تاریخ تولد
    /// </summary>
    public DateTime? DateOfBirth { get; set; }

    /// <summary>
    /// جنسیت
    /// </summary>
    public string? Gender { get; set; }

    /// <summary>
    /// کد ملی
    /// </summary>
    public string? NationalId { get; set; }

    /// <summary>
    /// تصویر پروفایل
    /// </summary>
    public string? ProfileImageUrl { get; set; }

    /// <summary>
    /// بیوگرافی
    /// </summary>
    public string? Bio { get; set; }

    /// <summary>
    /// زبان پیش‌فرض
    /// </summary>
    public string PreferredLanguage { get; set; } = "fa";

    /// <summary>
    /// منطقه زمانی
    /// </summary>
    public string TimeZone { get; set; } = "Asia/Tehran";

    /// <summary>
    /// نام نقش
    /// </summary>
    public string RoleName { get; set; } = string.Empty;

    /// <summary>
    /// نام شرکت
    /// </summary>
    public string? CompanyName { get; set; }

    /// <summary>
    /// آیا فعال است
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// تاریخ ایجاد
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// تاریخ به‌روزرسانی
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}
