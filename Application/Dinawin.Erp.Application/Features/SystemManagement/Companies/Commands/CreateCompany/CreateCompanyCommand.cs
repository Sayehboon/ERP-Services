using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.SystemManagement.Companies.Commands.CreateCompany;

/// <summary>
/// دستور ایجاد شرکت جدید
/// </summary>
public sealed class CreateCompanyCommand : IRequest<Guid>
{
    /// <summary>
    /// نام شرکت
    /// </summary>
    [Required(ErrorMessage = "نام شرکت الزامی است")]
    [StringLength(200, ErrorMessage = "نام شرکت نمی‌تواند بیش از 200 کاراکتر باشد")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// کد شرکت
    /// </summary>
    [Required(ErrorMessage = "کد شرکت الزامی است")]
    [StringLength(50, ErrorMessage = "کد شرکت نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// نام تجاری
    /// </summary>
    [StringLength(200, ErrorMessage = "نام تجاری نمی‌تواند بیش از 200 کاراکتر باشد")]
    public string? TradeName { get; set; }

    /// <summary>
    /// نوع شرکت
    /// </summary>
    [StringLength(50, ErrorMessage = "نوع شرکت نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string? CompanyType { get; set; }

    /// <summary>
    /// آدرس شرکت
    /// </summary>
    [StringLength(500, ErrorMessage = "آدرس شرکت نمی‌تواند بیش از 500 کاراکتر باشد")]
    public string? Address { get; set; }

    /// <summary>
    /// شهر
    /// </summary>
    [StringLength(100, ErrorMessage = "نام شهر نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string? City { get; set; }

    /// <summary>
    /// استان
    /// </summary>
    [StringLength(100, ErrorMessage = "نام استان نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string? Province { get; set; }

    /// <summary>
    /// کشور
    /// </summary>
    [StringLength(100, ErrorMessage = "نام کشور نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string? Country { get; set; }

    /// <summary>
    /// کد پستی
    /// </summary>
    [StringLength(20, ErrorMessage = "کد پستی نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string? PostalCode { get; set; }

    /// <summary>
    /// شماره تلفن
    /// </summary>
    [StringLength(20, ErrorMessage = "شماره تلفن نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string? Phone { get; set; }

    /// <summary>
    /// آدرس ایمیل
    /// </summary>
    [EmailAddress(ErrorMessage = "فرمت ایمیل صحیح نیست")]
    [StringLength(100, ErrorMessage = "آدرس ایمیل نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string? Email { get; set; }

    /// <summary>
    /// شماره ملی/شناسه ملی
    /// </summary>
    [StringLength(50, ErrorMessage = "شماره ملی نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string? NationalId { get; set; }

    /// <summary>
    /// شماره اقتصادی
    /// </summary>
    [StringLength(50, ErrorMessage = "شماره اقتصادی نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string? EconomicCode { get; set; }

    /// <summary>
    /// شماره ثبت
    /// </summary>
    [StringLength(50, ErrorMessage = "شماره ثبت نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string? RegistrationNumber { get; set; }

    /// <summary>
    /// وب‌سایت
    /// </summary>
    [StringLength(200, ErrorMessage = "آدرس وب‌سایت نمی‌تواند بیش از 200 کاراکتر باشد")]
    public string? Website { get; set; }

    /// <summary>
    /// آیا شرکت فعال است
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// توضیحات
    /// </summary>
    [StringLength(1000, ErrorMessage = "توضیحات نمی‌تواند بیش از 1000 کاراکتر باشد")]
    public string? Notes { get; set; }

    /// <summary>
    /// شناسه کاربر ایجاد کننده
    /// </summary>
    public Guid? CreatedBy { get; set; }
}
