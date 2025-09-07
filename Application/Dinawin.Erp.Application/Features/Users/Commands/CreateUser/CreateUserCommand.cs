using MediatR;

namespace Dinawin.Erp.Application.Features.Users.Commands.CreateUser;

/// <summary>
/// دستور ایجاد کاربر جدید
/// Command for creating a new user
/// </summary>
public class CreateUserCommand : IRequest<Guid>
{
    /// <summary>
    /// نام کاربر
    /// User's first name
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// نام خانوادگی کاربر
    /// User's last name
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// ایمیل کاربر
    /// User's email address
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// رمز عبور کاربر
    /// User's password
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// شماره تماس کاربر
    /// User's phone number
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// شماره تماس داخلی
    /// Internal phone number
    /// </summary>
    public string? InternalPhone { get; set; }

    /// <summary>
    /// کد ملی
    /// National ID
    /// </summary>
    public string? NationalId { get; set; }

    /// <summary>
    /// تاریخ تولد
    /// Birth date
    /// </summary>
    public DateTime? BirthDate { get; set; }

    /// <summary>
    /// آدرس تصویر پروفایل
    /// Profile image URL
    /// </summary>
    public string? AvatarUrl { get; set; }

    /// <summary>
    /// وضعیت فعال بودن کاربر
    /// User active status
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// شناسه شرکت
    /// Company ID
    /// </summary>
    public Guid? CompanyId { get; set; }

    /// <summary>
    /// شناسه بخش
    /// Department ID
    /// </summary>
    public Guid? DepartmentId { get; set; }

    /// <summary>
    /// شناسه بیزینس
    /// Business ID
    /// </summary>
    public Guid? BusinessId { get; set; }

    /// <summary>
    /// لیست شناسه نقش‌ها
    /// List of role IDs
    /// </summary>
    public List<Guid> RoleIds { get; set; } = new();
}
