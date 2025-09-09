namespace Dinawin.Erp.Application.Features.Customers.Queries.GetActiveCustomers;

/// <summary>
/// DTO مشتری
/// </summary>
public class CustomerDto
{
    /// <summary>
    /// شناسه مشتری
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// کد مشتری
    /// </summary>
    public string CustomerCode { get; set; } = string.Empty;

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
    /// نام تجاری
    /// </summary>
    public string? TradeName { get; set; }

    /// <summary>
    /// نوع مشتری
    /// </summary>
    public string CustomerType { get; set; } = string.Empty;

    /// <summary>
    /// شماره ملی
    /// </summary>
    public string? NationalCode { get; set; }

    /// <summary>
    /// شماره شناسنامه
    /// </summary>
    public string? IdentityNumber { get; set; }

    /// <summary>
    /// شماره تلفن
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// شماره موبایل
    /// </summary>
    public string? Mobile { get; set; }

    /// <summary>
    /// ایمیل
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// آدرس
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// شهر
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// استان
    /// </summary>
    public string? Province { get; set; }

    /// <summary>
    /// کد پستی
    /// </summary>
    public string? PostalCode { get; set; }

    /// <summary>
    /// شناسه شرکت
    /// </summary>
    public Guid? CompanyId { get; set; }

    /// <summary>
    /// نام شرکت
    /// </summary>
    public string? CompanyName { get; set; }

    /// <summary>
    /// آیا فعال است
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// امتیاز اعتبار
    /// </summary>
    public int? CreditRating { get; set; }

    /// <summary>
    /// حد اعتبار
    /// </summary>
    public decimal? CreditLimit { get; set; }

    /// <summary>
    /// موجودی حساب
    /// </summary>
    public decimal AccountBalance { get; set; }

    /// <summary>
    /// ارز
    /// </summary>
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// تاریخ تولد
    /// </summary>
    public DateTime? BirthDate { get; set; }

    /// <summary>
    /// جنسیت
    /// </summary>
    public string? Gender { get; set; }

    /// <summary>
    /// تاریخ ایجاد
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// تاریخ آخرین به‌روزرسانی
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}
