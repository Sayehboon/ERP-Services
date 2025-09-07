using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.SystemManagement.Users.Commands.UpdateUser;

/// <summary>
/// دستور به‌روزرسانی کاربر
/// </summary>
public sealed class UpdateUserCommand : IRequest<Guid>
{
    /// <summary>
    /// شناسه کاربر
    /// </summary>
    [Required(ErrorMessage = "شناسه کاربر الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// نام کاربری
    /// </summary>
    [Required(ErrorMessage = "نام کاربری الزامی است")]
    [StringLength(50, ErrorMessage = "نام کاربری نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// ایمیل
    /// </summary>
    [Required(ErrorMessage = "ایمیل الزامی است")]
    [EmailAddress(ErrorMessage = "فرمت ایمیل معتبر نیست")]
    [StringLength(100, ErrorMessage = "ایمیل نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// نام
    /// </summary>
    [Required(ErrorMessage = "نام الزامی است")]
    [StringLength(50, ErrorMessage = "نام نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// نام خانوادگی
    /// </summary>
    [Required(ErrorMessage = "نام خانوادگی الزامی است")]
    [StringLength(50, ErrorMessage = "نام خانوادگی نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// شماره تلفن
    /// </summary>
    [StringLength(20, ErrorMessage = "شماره تلفن نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// شناسه نقش
    /// </summary>
    [Required(ErrorMessage = "شناسه نقش الزامی است")]
    public Guid RoleId { get; set; }

    /// <summary>
    /// شناسه شرکت
    /// </summary>
    public Guid? CompanyId { get; set; }

    /// <summary>
    /// آیا فعال است
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// شناسه کاربر به‌روزرسانی کننده
    /// </summary>
    public Guid? UpdatedBy { get; set; }
}
