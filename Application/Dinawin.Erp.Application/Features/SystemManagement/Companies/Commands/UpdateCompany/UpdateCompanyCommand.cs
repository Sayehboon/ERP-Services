using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.SystemManagement.Companies.Commands.UpdateCompany;

/// <summary>
/// دستور به‌روزرسانی شرکت
/// </summary>
public sealed class UpdateCompanyCommand : IRequest<Guid>
{
    /// <summary>
    /// شناسه شرکت
    /// </summary>
    [Required(ErrorMessage = "شناسه شرکت الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// نام شرکت
    /// </summary>
    [Required(ErrorMessage = "نام شرکت الزامی است")]
    [StringLength(200, ErrorMessage = "نام شرکت نمی‌تواند بیش از 200 کاراکتر باشد")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// نام تجاری شرکت
    /// </summary>
    [StringLength(200, ErrorMessage = "نام تجاری شرکت نمی‌تواند بیش از 200 کاراکتر باشد")]
    public string? TradeName { get; set; }

    /// <summary>
    /// شماره ثبت شرکت
    /// </summary>
    [StringLength(50, ErrorMessage = "شماره ثبت شرکت نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string? RegistrationNumber { get; set; }

    /// <summary>
    /// کد ملی شرکت
    /// </summary>
    [StringLength(20, ErrorMessage = "کد ملی شرکت نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string? NationalId { get; set; }

    /// <summary>
    /// شماره اقتصادی
    /// </summary>
    [StringLength(20, ErrorMessage = "شماره اقتصادی نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string? EconomicCode { get; set; }

    /// <summary>
    /// آدرس شرکت
    /// </summary>
    [StringLength(500, ErrorMessage = "آدرس شرکت نمی‌تواند بیش از 500 کاراکتر باشد")]
    public string? Address { get; set; }

    /// <summary>
    /// شماره تلفن
    /// </summary>
    [StringLength(20, ErrorMessage = "شماره تلفن نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// شماره فکس
    /// </summary>
    [StringLength(20, ErrorMessage = "شماره فکس نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string? FaxNumber { get; set; }

    /// <summary>
    /// ایمیل شرکت
    /// </summary>
    [EmailAddress(ErrorMessage = "فرمت ایمیل معتبر نیست")]
    [StringLength(100, ErrorMessage = "ایمیل شرکت نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string? Email { get; set; }

    /// <summary>
    /// وب‌سایت شرکت
    /// </summary>
    [StringLength(200, ErrorMessage = "وب‌سایت شرکت نمی‌تواند بیش از 200 کاراکتر باشد")]
    public string? Website { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    [StringLength(1000, ErrorMessage = "توضیحات نمی‌تواند بیش از 1000 کاراکتر باشد")]
    public string? Description { get; set; }

    /// <summary>
    /// آیا فعال است
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// شناسه کاربر به‌روزرسانی کننده
    /// </summary>
    public Guid? UpdatedBy { get; set; }
}
