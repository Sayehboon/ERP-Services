namespace Dinawin.Erp.Application.Features.SystemManagement.UserProfiles.Queries.GetCurrentUserProfile;

/// <summary>
/// DTO پروفایل کاربر فعلی
/// </summary>
public class CurrentUserProfileDto
{
    /// <summary>
    /// شناسه کاربر
    /// </summary>
    public Guid Id { get; set; }

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
    /// نام کاربری
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// ایمیل
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// شماره تلفن
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// آدرس آواتار
    /// </summary>
    public string? AvatarUrl { get; set; }

    /// <summary>
    /// آیا فعال است
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// آیا ایمیل تایید شده است
    /// </summary>
    public bool IsEmailVerified { get; set; }

    /// <summary>
    /// آیا شماره تلفن تایید شده است
    /// </summary>
    public bool IsPhoneVerified { get; set; }

    /// <summary>
    /// تاریخ آخرین ورود
    /// </summary>
    public DateTime? LastLoginAt { get; set; }

    /// <summary>
    /// شناسه شرکت
    /// </summary>
    public Guid? CompanyId { get; set; }

    /// <summary>
    /// نام شرکت
    /// </summary>
    public string? CompanyName { get; set; }

    /// <summary>
    /// شناسه بخش
    /// </summary>
    public Guid? DepartmentId { get; set; }

    /// <summary>
    /// نام بخش
    /// </summary>
    public string? DepartmentName { get; set; }

    /// <summary>
    /// نقش‌های کاربر
    /// </summary>
    public List<UserRoleDto> Roles { get; set; } = new();

    /// <summary>
    /// مجوزهای کاربر
    /// </summary>
    public List<string> Permissions { get; set; } = new();

    /// <summary>
    /// تاریخ ایجاد
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// تاریخ آخرین به‌روزرسانی
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}

/// <summary>
/// DTO نقش کاربر
/// </summary>
public class UserRoleDto
{
    /// <summary>
    /// شناسه نقش
    /// </summary>
    public Guid RoleId { get; set; }

    /// <summary>
    /// نام نقش
    /// </summary>
    public string RoleName { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات نقش
    /// </summary>
    public string? RoleDescription { get; set; }
}
