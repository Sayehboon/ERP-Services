namespace Dinawin.Erp.Application.Features.Vendors.Queries.GetAllVendors;

/// <summary>
/// مدل انتقال داده تامین‌کننده
/// </summary>
public sealed class VendorDto
{
    /// <summary>
    /// شناسه تامین‌کننده
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// نام تامین‌کننده
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// نام خانوادگی تامین‌کننده
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// نام کامل تامین‌کننده
    /// </summary>
    public string FullName => $"{Name} {LastName}".Trim();

    /// <summary>
    /// نام شرکت
    /// </summary>
    public string? CompanyName { get; set; }

    /// <summary>
    /// نوع تامین‌کننده
    /// </summary>
    public string VendorType { get; set; } = string.Empty;

    /// <summary>
    /// شماره ملی/شناسه ملی
    /// </summary>
    public string? NationalId { get; set; }

    /// <summary>
    /// شماره اقتصادی
    /// </summary>
    public string? EconomicCode { get; set; }

    /// <summary>
    /// شماره ثبت
    /// </summary>
    public string? RegistrationNumber { get; set; }

    /// <summary>
    /// شماره تلفن
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// شماره موبایل
    /// </summary>
    public string? Mobile { get; set; }

    /// <summary>
    /// آدرس ایمیل
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
    /// کشور
    /// </summary>
    public string? Country { get; set; }

    /// <summary>
    /// آدرس کامل
    /// </summary>
    public string? FullAddress => $"{Address}, {City}, {Province}, {Country}".Trim(',', ' ');

    /// <summary>
    /// وب‌سایت
    /// </summary>
    public string? Website { get; set; }

    /// <summary>
    /// تاریخ تولد
    /// </summary>
    public DateTime? BirthDate { get; set; }

    /// <summary>
    /// جنسیت
    /// </summary>
    public string? Gender { get; set; }

    /// <summary>
    /// شغل
    /// </summary>
    public string? JobTitle { get; set; }

    /// <summary>
    /// اعتبار (مبلغ)
    /// </summary>
    public decimal CreditLimit { get; set; }

    /// <summary>
    /// مانده حساب
    /// </summary>
    public decimal AccountBalance { get; set; }

    /// <summary>
    /// شرایط پرداخت
    /// </summary>
    public string? PaymentTerms { get; set; }

    /// <summary>
    /// ارز ترجیحی
    /// </summary>
    public string? PreferredCurrency { get; set; }

    /// <summary>
    /// وضعیت فعال بودن
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }

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
