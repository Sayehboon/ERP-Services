namespace Dinawin.Erp.Domain.Entities.Accounting;

using Dinawin.Erp.Domain.Common;

/// <summary>
/// موجودیت مشتری
/// Customer entity
/// </summary>
public class Customer : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// کد مشتری
    /// Customer code
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// نام مشتری
    /// Customer name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// نام خانوادگی
    /// Last name
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// نام شرکت
    /// Company name
    /// </summary>
    public string? CompanyName { get; set; }

    /// <summary>
    /// نوع مشتری
    /// Customer type
    /// </summary>
    public string CustomerType { get; set; } = string.Empty;

    /// <summary>
    /// شماره/شناسه ملی
    /// National ID
    /// </summary>
    public string? NationalId { get; set; }

    /// <summary>
    /// شماره اقتصادی
    /// Economic code
    /// </summary>
    public string? EconomicCode { get; set; }

    /// <summary>
    /// شماره ثبت
    /// Registration number
    /// </summary>
    public string? RegistrationNumber { get; set; }

    /// <summary>
    /// تلفن
    /// Phone
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// موبایل
    /// Mobile
    /// </summary>
    public string? Mobile { get; set; }

    /// <summary>
    /// ایمیل
    /// Email
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// آدرس
    /// Address
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// شهر
    /// City
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// استان
    /// Province
    /// </summary>
    public string? Province { get; set; }

    /// <summary>
    /// کد پستی
    /// Postal code
    /// </summary>
    public string? PostalCode { get; set; }

    /// <summary>
    /// کشور
    /// Country
    /// </summary>
    public string? Country { get; set; }

    /// <summary>
    /// وب‌سایت
    /// Website
    /// </summary>
    public string? Website { get; set; }

    /// <summary>
    /// تاریخ تولد
    /// Birth date
    /// </summary>
    public DateTime? BirthDate { get; set; }

    /// <summary>
    /// جنسیت
    /// Gender
    /// </summary>
    public string? Gender { get; set; }

    /// <summary>
    /// عنوان شغلی
    /// Job title
    /// </summary>
    public string? JobTitle { get; set; }

    /// <summary>
    /// سقف اعتبار
    /// Credit limit
    /// </summary>
    public decimal? CreditLimit { get; set; }

    /// <summary>
    /// مانده حساب
    /// Account balance
    /// </summary>
    public decimal? AccountBalance { get; set; }

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// فعال است؟
    /// Is active?
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// سفارش‌های فروش مشتری
    /// Customer sales orders
    /// </summary>
    public ICollection<Dinawin.Erp.Domain.Entities.Sales.SalesOrder> SalesOrders { get; set; } = new List<Dinawin.Erp.Domain.Entities.Sales.SalesOrder>();
    public string? ContactName { get; set; }
    public string? PreferredCurrency { get; set; }
    public string? PaymentTerms { get; set; }
    public decimal DiscountRate { get; set; }
    public string? Notes { get; set; }
}


