using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.SystemManagement.UserProfiles.Commands.UpdateUserProfile;

/// <summary>
/// دستور به‌روزرسانی پروفایل کاربر
/// </summary>
public sealed class UpdateUserProfileCommand : IRequest<Guid>
{
    /// <summary>
    /// شناسه کاربر
    /// </summary>
    [Required(ErrorMessage = "شناسه کاربر الزامی است")]
    public Guid UserId { get; set; }

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
    /// آدرس
    /// </summary>
    [StringLength(500, ErrorMessage = "آدرس نمی‌تواند بیش از 500 کاراکتر باشد")]
    public string? Address { get; set; }

    /// <summary>
    /// تاریخ تولد
    /// </summary>
    public DateTime? DateOfBirth { get; set; }

    /// <summary>
    /// جنسیت
    /// </summary>
    [StringLength(10, ErrorMessage = "جنسیت نمی‌تواند بیش از 10 کاراکتر باشد")]
    public string? Gender { get; set; }

    /// <summary>
    /// کد ملی
    /// </summary>
    [StringLength(20, ErrorMessage = "کد ملی نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string? NationalId { get; set; }

    /// <summary>
    /// تصویر پروفایل
    /// </summary>
    [StringLength(500, ErrorMessage = "مسیر تصویر پروفایل نمی‌تواند بیش از 500 کاراکتر باشد")]
    public string? ProfileImageUrl { get; set; }

    /// <summary>
    /// بیوگرافی
    /// </summary>
    [StringLength(1000, ErrorMessage = "بیوگرافی نمی‌تواند بیش از 1000 کاراکتر باشد")]
    public string? Bio { get; set; }

    /// <summary>
    /// زبان پیش‌فرض
    /// </summary>
    [StringLength(10, ErrorMessage = "زبان پیش‌فرض نمی‌تواند بیش از 10 کاراکتر باشد")]
    public string? PreferredLanguage { get; set; } = "fa";

    /// <summary>
    /// منطقه زمانی
    /// </summary>
    [StringLength(50, ErrorMessage = "منطقه زمانی نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string? TimeZone { get; set; } = "Asia/Tehran";

    /// <summary>
    /// شناسه کاربر به‌روزرسانی کننده
    /// </summary>
    public Guid? UpdatedBy { get; set; }
}
