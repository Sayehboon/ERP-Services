using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
    /// شناسه تامین‌کننده
    /// Vendor ID
    /// </summary>
    public Guid? VendorId { get; set; }

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

/// <summary>
/// پیکربندی موجودیت مخاطب CRM
/// CRM Contact entity configuration
/// </summary>
public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).IsRequired().HasMaxLength(200);
        builder.Property(e => e.LastName).HasMaxLength(200);
        builder.Property(e => e.Email).HasMaxLength(200);
        builder.Property(e => e.Phone).HasMaxLength(20);
        builder.Property(e => e.Mobile).HasMaxLength(20);
        builder.Property(e => e.Address).HasMaxLength(500);
        builder.Property(e => e.City).HasMaxLength(100);
        builder.Property(e => e.Province).HasMaxLength(100);
        builder.Property(e => e.PostalCode).HasMaxLength(20);
        builder.Property(e => e.Country).HasMaxLength(100);
        builder.Property(e => e.CompanyName).HasMaxLength(200);
        builder.Property(e => e.Position).HasMaxLength(100);
        builder.Property(e => e.ContactType).HasMaxLength(50);
        builder.Property(e => e.Description).HasMaxLength(2000);
        builder.Property(e => e.Company).HasMaxLength(200);
        builder.Property(e => e.FirstName).HasMaxLength(200);
        builder.Property(e => e.Notes).HasMaxLength(4000);
        builder.Property(e => e.Source).HasMaxLength(100);
        builder.Property(e => e.Status).HasMaxLength(50);

        builder.HasIndex(e => e.Email).IsUnique(false);
        builder.HasIndex(e => e.Phone).IsUnique(false);
        builder.HasIndex(e => e.Mobile).IsUnique(false);
        builder.HasIndex(e => e.CompanyName);
    }
}
