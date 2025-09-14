using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.CRM.Contacts.Commands.UpdateContact;

/// <summary>
/// دستور به‌روزرسانی مخاطب
/// </summary>
public class UpdateContactCommand : IRequest<Guid>
{
    /// <summary>
    /// شناسه مخاطب
    /// </summary>
    [Required(ErrorMessage = "شناسه مخاطب الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// نام
    /// </summary>
    [Required(ErrorMessage = "نام الزامی است")]
    [StringLength(100, ErrorMessage = "نام نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// نام خانوادگی
    /// </summary>
    [Required(ErrorMessage = "نام خانوادگی الزامی است")]
    [StringLength(100, ErrorMessage = "نام خانوادگی نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// نام شرکت
    /// </summary>
    [StringLength(200, ErrorMessage = "نام شرکت نمی‌تواند بیش از 200 کاراکتر باشد")]
    public string CompanyName { get; set; }

    /// <summary>
    /// عنوان شغلی
    /// </summary>
    [StringLength(100, ErrorMessage = "عنوان شغلی نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string Position { get; set; }

    /// <summary>
    /// شماره تلفن
    /// </summary>
    [StringLength(20, ErrorMessage = "شماره تلفن نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string Phone { get; set; }

    /// <summary>
    /// شماره موبایل
    /// </summary>
    [StringLength(20, ErrorMessage = "شماره موبایل نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string Mobile { get; set; }

    /// <summary>
    /// آدرس ایمیل
    /// </summary>
    [EmailAddress(ErrorMessage = "فرمت ایمیل نامعتبر است")]
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
    [StringLength(100, ErrorMessage = "شهر نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string City { get; set; }

    /// <summary>
    /// استان
    /// </summary>
    [StringLength(100, ErrorMessage = "استان نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string Province { get; set; }

    /// <summary>
    /// کد پستی
    /// </summary>
    [StringLength(20, ErrorMessage = "کد پستی نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string PostalCode { get; set; }

    /// <summary>
    /// کشور
    /// </summary>
    [StringLength(100, ErrorMessage = "کشور نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string Country { get; set; }

    /// <summary>
    /// تاریخ تولد
    /// </summary>
    public DateTime? BirthDate { get; set; }

    /// <summary>
    /// یادداشت‌ها
    /// </summary>
    [StringLength(1000, ErrorMessage = "یادداشت‌ها نمی‌تواند بیش از 1000 کاراکتر باشد")]
    public string Description { get; set; }

    /// <summary>
    /// شناسه کاربر به‌روزرسانی‌کننده
    /// </summary>
    public Guid? UpdatedBy { get; set; }

    /// <summary>
    /// نوع مخاطب
    /// </summary>
    [StringLength(50, ErrorMessage = "نوع مخاطب نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string ContactType { get; set; }

    /// <summary>
    /// وضعیت فعال بودن
    /// </summary>
    public bool IsActive { get; set; } = true;
}
