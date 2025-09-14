namespace Dinawin.Erp.Application.Features.CRM.Contacts.DTOs;

/// <summary>
/// DTO برای نمایش اطلاعات مخاطب
/// Contact information DTO
/// </summary>
public class ContactDto
{
    /// <summary>
    /// شناسه مخاطب
    /// Contact ID
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// نام مخاطب
    /// Contact name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// نام خانوادگی مخاطب
    /// Contact last name
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// نام کامل مخاطب
    /// Contact full name
    /// </summary>
    public string FullName => $"{Name} {LastName}".Trim();

    /// <summary>
    /// ایمیل مخاطب
    /// Contact email
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// شماره تلفن مخاطب
    /// Contact phone number
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// موبایل مخاطب
    /// Contact mobile
    /// </summary>
    public string Mobile { get; set; }

    /// <summary>
    /// آدرس مخاطب
    /// Contact address
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// شهر مخاطب
    /// Contact city
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// استان مخاطب
    /// Contact province
    /// </summary>
    public string Province { get; set; }

    /// <summary>
    /// کد پستی مخاطب
    /// Contact postal code
    /// </summary>
    public string PostalCode { get; set; }

    /// <summary>
    /// کشور مخاطب
    /// Contact country
    /// </summary>
    public string Country { get; set; }

    /// <summary>
    /// نام شرکت مخاطب
    /// Contact company name
    /// </summary>
    public string CompanyName { get; set; }

    /// <summary>
    /// سمت مخاطب
    /// Contact position
    /// </summary>
    public string Position { get; set; }

    /// <summary>
    /// نوع مخاطب
    /// Contact type
    /// </summary>
    public string ContactType { get; set; }

    /// <summary>
    /// وضعیت فعال بودن مخاطب
    /// Contact active status
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// توضیحات مخاطب
    /// Contact description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// تاریخ ایجاد
    /// Created date
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// تاریخ آخرین بروزرسانی
    /// Last updated date
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}
