using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Vendors.Commands.CreateVendor;

/// <summary>
/// دستور ایجاد تامین‌کننده جدید
/// </summary>
public sealed class CreateVendorCommand : IRequest<Guid>
{
    /// <summary>
    /// نام تامین‌کننده
    /// </summary>
    [Required(ErrorMessage = "نام تامین‌کننده الزامی است")]
    [StringLength(200, ErrorMessage = "نام تامین‌کننده نمی‌تواند بیش از 200 کاراکتر باشد")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// کد تامین‌کننده
    /// </summary>
    [Required(ErrorMessage = "کد تامین‌کننده الزامی است")]
    [StringLength(50, ErrorMessage = "کد تامین‌کننده نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// نوع تامین‌کننده
    /// </summary>
    [Required(ErrorMessage = "نوع تامین‌کننده الزامی است")]
    [StringLength(50, ErrorMessage = "نوع تامین‌کننده نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string VendorType { get; set; } = string.Empty;

    /// <summary>
    /// نام شرکت
    /// </summary>
    [StringLength(200, ErrorMessage = "نام شرکت نمی‌تواند بیش از 200 کاراکتر باشد")]
    public string CompanyName { get; set; }

    /// <summary>
    /// نام تماس
    /// </summary>
    [StringLength(100, ErrorMessage = "نام تماس نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string ContactName { get; set; }

    /// <summary>
    /// شماره تلفن
    /// </summary>
    [StringLength(20, ErrorMessage = "شماره تلفن نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string Phone { get; set; }

    /// <summary>
    /// آدرس ایمیل
    /// </summary>
    [EmailAddress(ErrorMessage = "فرمت ایمیل صحیح نیست")]
    [StringLength(100, ErrorMessage = "آدرس ایمیل نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string Email { get; set; }

    /// <summary>
    /// آدرس
    /// </summary>
    [StringLength(500, ErrorMessage = "آدرس نمی‌تواند بیش از 500 کاراکتر باشد")]
    public string Address { get; set; }

    /// <summary>
    /// شهر
    /// </summary>
    [StringLength(100, ErrorMessage = "نام شهر نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string City { get; set; }

    /// <summary>
    /// استان
    /// </summary>
    [StringLength(100, ErrorMessage = "نام استان نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string Province { get; set; }

    /// <summary>
    /// کشور
    /// </summary>
    [StringLength(100, ErrorMessage = "نام کشور نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string Country { get; set; }

    /// <summary>
    /// کد پستی
    /// </summary>
    [StringLength(20, ErrorMessage = "کد پستی نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string PostalCode { get; set; }

    /// <summary>
    /// شماره ملی/شناسه ملی
    /// </summary>
    [StringLength(50, ErrorMessage = "شماره ملی نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string NationalId { get; set; }

    /// <summary>
    /// شماره اقتصادی
    /// </summary>
    [StringLength(50, ErrorMessage = "شماره اقتصادی نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string EconomicCode { get; set; }

    /// <summary>
    /// محدودیت اعتبار
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "محدودیت اعتبار نمی‌تواند منفی باشد")]
    public decimal CreditLimit { get; set; } = 0;

    /// <summary>
    /// ارز ترجیحی
    /// </summary>
    [StringLength(10, ErrorMessage = "کد ارز نمی‌تواند بیش از 10 کاراکتر باشد")]
    public string PreferredCurrency { get; set; }

    /// <summary>
    /// شرایط پرداخت
    /// </summary>
    [StringLength(100, ErrorMessage = "شرایط پرداخت نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string PaymentTerms { get; set; }

    /// <summary>
    /// نرخ تخفیف
    /// </summary>
    [Range(0, 100, ErrorMessage = "نرخ تخفیف باید بین 0 تا 100 باشد")]
    public decimal DiscountRate { get; set; } = 0;

    /// <summary>
    /// آیا تامین‌کننده فعال است
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// توضیحات
    /// </summary>
    [StringLength(1000, ErrorMessage = "توضیحات نمی‌تواند بیش از 1000 کاراکتر باشد")]
    public string Notes { get; set; }

    /// <summary>
    /// شناسه کاربر ایجاد کننده
    /// </summary>
    public Guid? CreatedBy { get; set; }
}
