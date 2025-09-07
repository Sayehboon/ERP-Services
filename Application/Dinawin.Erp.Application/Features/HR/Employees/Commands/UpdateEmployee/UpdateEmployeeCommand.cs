using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.HR.Employees.Commands.UpdateEmployee;

/// <summary>
/// دستور به‌روزرسانی کارمند
/// </summary>
public class UpdateEmployeeCommand : IRequest
{
    /// <summary>
    /// شناسه کارمند
    /// </summary>
    [Required(ErrorMessage = "شناسه کارمند الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// کد کارمند
    /// </summary>
    [Required(ErrorMessage = "کد کارمند الزامی است")]
    [StringLength(50, ErrorMessage = "کد کارمند نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string EmployeeCode { get; set; } = string.Empty;

    /// <summary>
    /// نام
    /// </summary>
    [Required(ErrorMessage = "نام الزامی است")]
    [StringLength(100, ErrorMessage = "نام نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// نام خانوادگی
    /// </summary>
    [Required(ErrorMessage = "نام خانوادگی الزامی است")]
    [StringLength(100, ErrorMessage = "نام خانوادگی نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// ایمیل
    /// </summary>
    [EmailAddress(ErrorMessage = "فرمت ایمیل صحیح نیست")]
    [StringLength(255, ErrorMessage = "ایمیل نمی‌تواند بیش از 255 کاراکتر باشد")]
    public string? Email { get; set; }

    /// <summary>
    /// تلفن
    /// </summary>
    [StringLength(20, ErrorMessage = "تلفن نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string? Phone { get; set; }

    /// <summary>
    /// شناسه بخش
    /// </summary>
    public Guid? DepartmentId { get; set; }

    /// <summary>
    /// شناسه شرکت
    /// </summary>
    public Guid? CompanyId { get; set; }

    /// <summary>
    /// موقعیت شغلی
    /// </summary>
    [StringLength(100, ErrorMessage = "موقعیت شغلی نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string? Position { get; set; }

    /// <summary>
    /// تاریخ استخدام
    /// </summary>
    public DateTime? HireDate { get; set; }

    /// <summary>
    /// حقوق
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "حقوق باید مثبت باشد")]
    public decimal? Salary { get; set; }

    /// <summary>
    /// آیا فعال است
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// آدرس
    /// </summary>
    [StringLength(500, ErrorMessage = "آدرس نمی‌تواند بیش از 500 کاراکتر باشد")]
    public string? Address { get; set; }

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
    /// شماره ملی
    /// </summary>
    [StringLength(20, ErrorMessage = "شماره ملی نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string? NationalId { get; set; }
}