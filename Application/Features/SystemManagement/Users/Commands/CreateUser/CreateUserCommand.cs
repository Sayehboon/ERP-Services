using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.SystemManagement.Users.Commands.CreateUser;

/// <summary>
/// دستور ایجاد کاربر جدید
/// </summary>
public sealed class CreateUserCommand : IRequest<Guid>
{
    /// <summary>
    /// نام کاربری
    /// </summary>
    [Required(ErrorMessage = "نام کاربری الزامی است")]
    [StringLength(50, ErrorMessage = "نام کاربری نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// رمز عبور
    /// </summary>
    [Required(ErrorMessage = "رمز عبور الزامی است")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "رمز عبور باید بین 6 تا 100 کاراکتر باشد")]
    public string Password { get; set; } = string.Empty;

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
    /// آدرس ایمیل
    /// </summary>
    [Required(ErrorMessage = "آدرس ایمیل الزامی است")]
    [EmailAddress(ErrorMessage = "فرمت ایمیل صحیح نیست")]
    [StringLength(100, ErrorMessage = "آدرس ایمیل نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// شماره تلفن
    /// </summary>
    [StringLength(20, ErrorMessage = "شماره تلفن نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string Phone { get; set; }

    /// <summary>
    /// شناسه نقش
    /// </summary>
    public Guid? RoleId { get; set; }

    /// <summary>
    /// شناسه بخش
    /// </summary>
    public Guid? DepartmentId { get; set; }

    /// <summary>
    /// شناسه شرکت
    /// </summary>
    public Guid? CompanyId { get; set; }

    /// <summary>
    /// آیا کاربر فعال است
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// آیا کاربر قفل شده است
    /// </summary>
    public bool IsLocked { get; set; } = false;

    /// <summary>
    /// تاریخ انقضای حساب
    /// </summary>
    public DateTime? ExpiryDate { get; set; }

    /// <summary>
    /// شناسه کاربر ایجاد کننده
    /// </summary>
    public Guid? CreatedBy { get; set; }
}