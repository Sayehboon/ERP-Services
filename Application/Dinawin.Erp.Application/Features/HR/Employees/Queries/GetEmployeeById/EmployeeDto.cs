namespace Dinawin.Erp.Application.Features.HR.Employees.Queries.GetEmployeeById;

/// <summary>
/// مدل انتقال داده کارمند
/// </summary>
public sealed class EmployeeDto
{
    /// <summary>
    /// شناسه کارمند
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// نام کاربری
    /// </summary>
    public string Username { get; set; } = string.Empty;

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
    /// آدرس ایمیل
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// شماره تلفن
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// شناسه نقش
    /// </summary>
    public Guid? RoleId { get; set; }

    /// <summary>
    /// نام نقش
    /// </summary>
    public string? RoleName { get; set; }

    /// <summary>
    /// شناسه بخش
    /// </summary>
    public Guid? DepartmentId { get; set; }

    /// <summary>
    /// نام بخش
    /// </summary>
    public string? DepartmentName { get; set; }

    /// <summary>
    /// شناسه شرکت
    /// </summary>
    public Guid? CompanyId { get; set; }

    /// <summary>
    /// نام شرکت
    /// </summary>
    public string? CompanyName { get; set; }

    /// <summary>
    /// آیا کاربر فعال است
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// آیا کاربر قفل شده است
    /// </summary>
    public bool IsLocked { get; set; }

    /// <summary>
    /// تاریخ انقضای حساب
    /// </summary>
    public DateTime? ExpiryDate { get; set; }

    /// <summary>
    /// تاریخ آخرین ورود
    /// </summary>
    public DateTime? LastLoginDate { get; set; }

    /// <summary>
    /// تاریخ ایجاد
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// تاریخ به‌روزرسانی
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// شناسه کاربر ایجاد کننده
    /// </summary>
    public Guid? CreatedBy { get; set; }

    /// <summary>
    /// شناسه کاربر به‌روزرسانی کننده
    /// </summary>
    public Guid? UpdatedBy { get; set; }
}