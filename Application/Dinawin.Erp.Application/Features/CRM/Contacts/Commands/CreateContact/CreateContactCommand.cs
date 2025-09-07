using MediatR;

namespace Dinawin.Erp.Application.Features.CRM.Contacts.Commands.CreateContact;

/// <summary>
/// دستور ایجاد مخاطب جدید
/// </summary>
public class CreateContactCommand : IRequest<Guid>
{
    /// <summary>
    /// نام
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// نام خانوادگی
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// نام شرکت
    /// </summary>
    public string? CompanyName { get; set; }

    /// <summary>
    /// عنوان شغلی
    /// </summary>
    public string? JobTitle { get; set; }

    /// <summary>
    /// شماره تلفن
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// شماره موبایل
    /// </summary>
    public string? MobileNumber { get; set; }

    /// <summary>
    /// آدرس ایمیل
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// آدرس
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// شهر
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// استان
    /// </summary>
    public string? State { get; set; }

    /// <summary>
    /// کد پستی
    /// </summary>
    public string? PostalCode { get; set; }

    /// <summary>
    /// کشور
    /// </summary>
    public string? Country { get; set; }

    /// <summary>
    /// تاریخ تولد
    /// </summary>
    public DateTime? BirthDate { get; set; }

    /// <summary>
    /// یادداشت‌ها
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// شناسه کاربر ایجادکننده
    /// </summary>
    public Guid CreatedByUserId { get; set; }
}
