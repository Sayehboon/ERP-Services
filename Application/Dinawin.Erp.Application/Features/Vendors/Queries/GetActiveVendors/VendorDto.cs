namespace Dinawin.Erp.Application.Features.Vendors.Queries.GetActiveVendors;

/// <summary>
/// DTO تامین‌کننده
/// </summary>
public class VendorDto
{
    /// <summary>
    /// شناسه تامین‌کننده
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// کد تامین‌کننده
    /// </summary>
    public string VendorCode { get; set; } = string.Empty;

    /// <summary>
    /// نام شرکت
    /// </summary>
    public string CompanyDisplayName { get; set; } = string.Empty;

    /// <summary>
    /// نام تجاری
    /// </summary>
    public string? TradeName { get; set; }

    /// <summary>
    /// شماره ثبت
    /// </summary>
    public string? RegistrationNumber { get; set; }

    /// <summary>
    /// کد ملی
    /// </summary>
    public string? NationalCode { get; set; }

    /// <summary>
    /// شناسه اقتصادی
    /// </summary>
    public string? EconomicCode { get; set; }

    /// <summary>
    /// شخص مسئول تماس
    /// </summary>
    public string? ContactPerson { get; set; }

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
    /// نام شرکت (اختیاری)
    /// </summary>
    public string? CompanyLegalName { get; set; }

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
    /// ارز
    /// </summary>
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// تاریخ ایجاد
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// تاریخ آخرین به‌روزرسانی
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}
