namespace Dinawin.Erp.Application.Features.SystemManagement.Companies.Queries.GetAllCompanies;

/// <summary>
/// DTO شرکت
/// </summary>
public class CompanyDto
{
    /// <summary>
    /// شناسه شرکت
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// نام شرکت
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// نام تجاری شرکت
    /// </summary>
    public string? TradeName { get; set; }

    /// <summary>
    /// شماره ثبت شرکت
    /// </summary>
    public string? RegistrationNumber { get; set; }

    /// <summary>
    /// کد ملی شرکت
    /// </summary>
    public string? NationalId { get; set; }

    /// <summary>
    /// شماره اقتصادی
    /// </summary>
    public string? EconomicCode { get; set; }

    /// <summary>
    /// آدرس شرکت
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// شماره تلفن
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// شماره فکس
    /// </summary>
    public string? FaxNumber { get; set; }

    /// <summary>
    /// ایمیل شرکت
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// وب‌سایت شرکت
    /// </summary>
    public string? Website { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// آیا فعال است
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// تعداد کاربران
    /// </summary>
    public int UsersCount { get; set; }

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
