using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.HR.Departments.Commands.UpdateDepartment;

/// <summary>
/// دستور به‌روزرسانی بخش
/// </summary>
public sealed class UpdateDepartmentCommand : IRequest<Guid>
{
    /// <summary>
    /// شناسه بخش
    /// </summary>
    [Required(ErrorMessage = "شناسه بخش الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// نام بخش
    /// </summary>
    [Required(ErrorMessage = "نام بخش الزامی است")]
    [StringLength(200, ErrorMessage = "نام بخش نمی‌تواند بیش از 200 کاراکتر باشد")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// کد بخش
    /// </summary>
    [Required(ErrorMessage = "کد بخش الزامی است")]
    [StringLength(50, ErrorMessage = "کد بخش نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات بخش
    /// </summary>
    [StringLength(1000, ErrorMessage = "توضیحات نمی‌تواند بیش از 1000 کاراکتر باشد")]
    public string? Description { get; set; }

    /// <summary>
    /// شناسه بخش والد
    /// </summary>
    public Guid? ParentDepartmentId { get; set; }

    /// <summary>
    /// شناسه مدیر بخش
    /// </summary>
    public Guid? ManagerId { get; set; }

    /// <summary>
    /// شناسه شرکت
    /// </summary>
    public Guid? CompanyId { get; set; }

    /// <summary>
    /// نوع بخش
    /// </summary>
    [StringLength(50, ErrorMessage = "نوع بخش نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string? DepartmentType { get; set; }

    /// <summary>
    /// سطح بخش در سلسله مراتب
    /// </summary>
    [Range(1, 10, ErrorMessage = "سطح بخش باید بین 1 تا 10 باشد")]
    public int Level { get; set; } = 1;

    /// <summary>
    /// مسیر سلسله مراتبی
    /// </summary>
    [StringLength(500, ErrorMessage = "مسیر سلسله مراتبی نمی‌تواند بیش از 500 کاراکتر باشد")]
    public string? HierarchyPath { get; set; }

    /// <summary>
    /// بودجه بخش
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "بودجه بخش نمی‌تواند منفی باشد")]
    public decimal? Budget { get; set; }

    /// <summary>
    /// آدرس بخش
    /// </summary>
    [StringLength(500, ErrorMessage = "آدرس بخش نمی‌تواند بیش از 500 کاراکتر باشد")]
    public string? Address { get; set; }

    /// <summary>
    /// شماره تلفن بخش
    /// </summary>
    [StringLength(20, ErrorMessage = "شماره تلفن نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string? Phone { get; set; }

    /// <summary>
    /// آدرس ایمیل بخش
    /// </summary>
    [EmailAddress(ErrorMessage = "فرمت ایمیل صحیح نیست")]
    [StringLength(100, ErrorMessage = "آدرس ایمیل نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string? Email { get; set; }

    /// <summary>
    /// آیا بخش فعال است
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// شناسه کاربر به‌روزرسانی کننده
    /// </summary>
    public Guid? UpdatedBy { get; set; }
}
