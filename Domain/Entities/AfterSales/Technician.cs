using Dinawin.Erp.Domain.Common;
using Dinawin.Erp.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.AfterSales;

/// <summary>
/// تکنسین
/// Technician
/// </summary>
public class Technician : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه کسب و کار
    /// Business ID
    /// </summary>
    public Guid BusinessId { get; set; }

    /// <summary>
    /// شناسه کاربر
    /// User ID
    /// </summary>
    public Guid? UserId { get; set; }

    /// <summary>
    /// نام
    /// First Name
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// نام خانوادگی
    /// Last Name
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// کد تکنسین
    /// Technician Code
    /// </summary>
    public string TechnicianCode { get; set; } = string.Empty;

    /// <summary>
    /// شماره تلفن
    /// Phone Number
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// ایمیل
    /// Email
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// تخصص
    /// Specialization
    /// </summary>
    public string Specialization { get; set; }

    /// <summary>
    /// سطح مهارت
    /// Skill Level
    /// </summary>
    public string SkillLevel { get; set; } = "intermediate";

    /// <summary>
    /// تجربه (سال)
    /// Experience (years)
    /// </summary>
    public int? ExperienceYears { get; set; }

    /// <summary>
    /// گواهینامه ها
    /// Certifications
    /// </summary>
    public string Certifications { get; set; }

    /// <summary>
    /// آیا فعال است
    /// Is Active
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// نرخ ساعتی
    /// Hourly Rate
    /// </summary>
    public decimal? HourlyRate { get; set; }

    /// <summary>
    /// آدرس
    /// Address
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// تاریخ استخدام
    /// Hire Date
    /// </summary>
    public DateTime? HireDate { get; set; }

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string Description { get; set; }

    // Navigation Properties
    /// <summary>
    /// کاربر
    /// User
    /// </summary>
    public virtual User? User { get; set; }
}

/// <summary>
/// پیکربندی موجودیت تکنسین
/// Technician entity configuration
/// </summary>
public class TechnicianConfiguration : IEntityTypeConfiguration<Technician>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<Technician> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.LastName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.TechnicianCode)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.PhoneNumber)
            .HasMaxLength(20);

        builder.Property(e => e.Email)
            .HasMaxLength(100);

        builder.Property(e => e.Specialization)
            .HasMaxLength(200);

        builder.Property(e => e.SkillLevel)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Certifications)
            .HasMaxLength(1000);

        builder.Property(e => e.Address)
            .HasMaxLength(500);

        builder.Property(e => e.Description)
            .HasMaxLength(1000);

        builder.Property(e => e.HourlyRate)
            .HasPrecision(18, 2);

        builder.HasOne(e => e.User)
            .WithMany()
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasIndex(e => e.TechnicianCode)
            .IsUnique();

        builder.HasIndex(e => e.UserId);
        builder.HasIndex(e => e.BusinessId);
    }
}
