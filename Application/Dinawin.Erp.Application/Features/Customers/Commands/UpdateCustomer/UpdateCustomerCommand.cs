using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Customers.Commands.UpdateCustomer;

/// <summary>
/// دستور به‌روزرسانی مشتری
/// </summary>
public sealed class UpdateCustomerCommand : IRequest<Guid>
{
    /// <summary>
    /// شناسه مشتری
    /// </summary>
    [Required(ErrorMessage = "شناسه مشتری الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// نام مشتری
    /// </summary>
    [Required(ErrorMessage = "نام مشتری الزامی است")]
    [StringLength(200, ErrorMessage = "نام مشتری نمی‌تواند بیش از 200 کاراکتر باشد")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// نام خانوادگی مشتری
    /// </summary>
    [StringLength(200, ErrorMessage = "نام خانوادگی نمی‌تواند بیش از 200 کاراکتر باشد")]
    public string? LastName { get; set; }

    /// <summary>
    /// نام شرکت
    /// </summary>
    [StringLength(300, ErrorMessage = "نام شرکت نمی‌تواند بیش از 300 کاراکتر باشد")]
    public string? CompanyName { get; set; }

    /// <summary>
    /// نوع مشتری
    /// </summary>
    [Required(ErrorMessage = "نوع مشتری الزامی است")]
    [StringLength(50, ErrorMessage = "نوع مشتری نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string CustomerType { get; set; } = string.Empty;

    /// <summary>
    /// شماره ملی/شناسه ملی
    /// </summary>
    [StringLength(20, ErrorMessage = "شماره ملی نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string? NationalId { get; set; }

    /// <summary>
    /// شماره اقتصادی
    /// </summary>
    [StringLength(20, ErrorMessage = "شماره اقتصادی نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string? EconomicCode { get; set; }

    /// <summary>
    /// شماره ثبت
    /// </summary>
    [StringLength(20, ErrorMessage = "شماره ثبت نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string? RegistrationNumber { get; set; }

    /// <summary>
    /// شماره تلفن
    /// </summary>
    [StringLength(20, ErrorMessage = "شماره تلفن نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string? Phone { get; set; }

    /// <summary>
    /// شماره موبایل
    /// </summary>
    [StringLength(20, ErrorMessage = "شماره موبایل نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string? Mobile { get; set; }

    /// <summary>
    /// آدرس ایمیل
    /// </summary>
    [EmailAddress(ErrorMessage = "فرمت ایمیل صحیح نیست")]
    [StringLength(100, ErrorMessage = "آدرس ایمیل نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string? Email { get; set; }

    /// <summary>
    /// آدرس
    /// </summary>
    [StringLength(500, ErrorMessage = "آدرس نمی‌تواند بیش از 500 کاراکتر باشد")]
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
    /// کد پستی
    /// </summary>
    [StringLength(10, ErrorMessage = "کد پستی نمی‌تواند بیش از 10 کاراکتر باشد")]
    public string? PostalCode { get; set; }

    /// <summary>
    /// کشور
    /// </summary>
    [StringLength(100, ErrorMessage = "نام کشور نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string? Country { get; set; }

    /// <summary>
    /// وب‌سایت
    /// </summary>
    [StringLength(200, ErrorMessage = "آدرس وب‌سایت نمی‌تواند بیش از 200 کاراکتر باشد")]
    public string? Website { get; set; }

    /// <summary>
    /// تاریخ تولد
    /// </summary>
    public DateTime? BirthDate { get; set; }

    /// <summary>
    /// جنسیت
    /// </summary>
    [StringLength(10, ErrorMessage = "جنسیت نمی‌تواند بیش از 10 کاراکتر باشد")]
    public string? Gender { get; set; }

    /// <summary>
    /// شغل
    /// </summary>
    [StringLength(100, ErrorMessage = "شغل نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string? JobTitle { get; set; }

    /// <summary>
    /// اعتبار (مبلغ)
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "اعتبار نمی‌تواند منفی باشد")]
    public decimal CreditLimit { get; set; } = 0;

    /// <summary>
    /// مانده حساب
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "مانده حساب نمی‌تواند منفی باشد")]
    public decimal AccountBalance { get; set; } = 0;

    /// <summary>
    /// وضعیت فعال بودن
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// توضیحات
    /// </summary>
    [StringLength(1000, ErrorMessage = "توضیحات نمی‌تواند بیش از 1000 کاراکتر باشد")]
    public string? Description { get; set; }

    /// <summary>
    /// شناسه کاربر به‌روزرسانی کننده
    /// </summary>
    public Guid? UpdatedBy { get; set; }
}
