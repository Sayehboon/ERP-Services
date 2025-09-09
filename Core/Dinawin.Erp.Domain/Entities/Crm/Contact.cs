using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Crm;

/// <summary>
/// موجودیت مخاطب CRM
/// CRM Contact entity
/// </summary>
public class Contact : BaseEntity
{
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
    /// ایمیل مخاطب
    /// Contact email
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// شماره تلفن مخاطب
    /// Contact phone number
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// موبایل مخاطب
    /// Contact mobile
    /// </summary>
    public string? Mobile { get; set; }

    /// <summary>
    /// آدرس مخاطب
    /// Contact address
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// شهر مخاطب
    /// Contact city
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// استان مخاطب
    /// Contact province
    /// </summary>
    public string? Province { get; set; }

    /// <summary>
    /// کد پستی مخاطب
    /// Contact postal code
    /// </summary>
    public string? PostalCode { get; set; }

    /// <summary>
    /// کشور مخاطب
    /// Contact country
    /// </summary>
    public string? Country { get; set; }

    /// <summary>
    /// نام شرکت مخاطب
    /// Contact company name
    /// </summary>
    public string? CompanyName { get; set; }

    /// <summary>
    /// سمت مخاطب
    /// Contact position
    /// </summary>
    public string? Position { get; set; }

    /// <summary>
    /// نوع مخاطب
    /// Contact type
    /// </summary>
    public string? ContactType { get; set; }

    /// <summary>
    /// وضعیت فعال بودن مخاطب
    /// Contact active status
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// توضیحات مخاطب
    /// Contact description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// تاریخ تولد
    /// Birth date
    /// </summary>
    public DateTime? BirthDate { get; set; }
    public string Company { get; set; }
    public string FirstName { get; set; }
    public string Notes { get; set; }
    public string Source { get; set; }
    public string Status { get; set; }

    /// <summary>
    /// فعالیت‌های مرتبط با مخاطب
    /// Related activities
    /// </summary>
    public ICollection<Activity> Activities { get; set; } = new List<Activity>();
}
