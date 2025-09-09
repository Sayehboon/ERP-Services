using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Crm;

/// <summary>
/// موجودیت سرنخ CRM
/// CRM Lead entity
/// </summary>
public class Lead : BaseEntity
{
    /// <summary>
    /// نام سرنخ
    /// Lead name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// نام خانوادگی سرنخ
    /// Lead last name
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// ایمیل سرنخ
    /// Lead email
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// شماره تلفن سرنخ
    /// Lead phone number
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// موبایل سرنخ
    /// Lead mobile
    /// </summary>
    public string? Mobile { get; set; }

    /// <summary>
    /// نام شرکت سرنخ
    /// Lead company name
    /// </summary>
    public string? CompanyName { get; set; }

    /// <summary>
    /// سمت سرنخ
    /// Lead position
    /// </summary>
    public string? Position { get; set; }

    /// <summary>
    /// منبع سرنخ
    /// Lead source
    /// </summary>
    public string? Source { get; set; }

    /// <summary>
    /// وضعیت سرنخ
    /// Lead status
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// اولویت سرنخ
    /// Lead priority
    /// </summary>
    public string Priority { get; set; } = string.Empty;

    /// <summary>
    /// ارزش احتمالی سرنخ
    /// Lead estimated value
    /// </summary>
    public decimal? EstimatedValue { get; set; }

    /// <summary>
    /// ارز ارزش احتمالی
    /// Estimated value currency
    /// </summary>
    public string? Currency { get; set; }

    /// <summary>
    /// تاریخ تبدیل احتمالی
    /// Expected conversion date
    /// </summary>
    public DateTime? ExpectedConversionDate { get; set; }

    /// <summary>
    /// توضیحات سرنخ
    /// Lead description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// یادداشت‌های سرنخ
    /// Lead notes
    /// </summary>
    public string? Notes { get; set; }

    

    /// <summary>
    /// شناسه کاربر مسئول
    /// Assigned to user ID
    /// </summary>
    public Guid? AssignedTo { get; set; }

    /// <summary>
    /// وضعیت فعال بودن سرنخ
    /// Lead active status
    /// </summary>
    public bool IsActive { get; set; } = true;
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Province { get; set; }
    public string? PostalCode { get; set; }
    public string? LeadSource { get; set; }
    public DateTime? ExpectedCloseDate { get; set; }
    public Guid? AssignedToId { get; set; }

    /// <summary>
    /// کاربر مسئول سرنخ (ناوبری)
    /// Assigned user navigation
    /// </summary>
    public Dinawin.Erp.Domain.Entities.Users.User? AssignedToUser { get; set; }

    /// <summary>
    /// فعالیت‌های مرتبط با سرنخ
    /// Related CRM activities
    /// </summary>
    public ICollection<Activity> Activities { get; set; } = new List<Activity>();
    public int Score { get; set; }
}

/// <summary>
/// پیکربندی موجودیت سرنخ CRM
/// CRM Lead entity configuration
/// </summary>
public class LeadConfiguration : IEntityTypeConfiguration<Lead>
{
    public void Configure(EntityTypeBuilder<Lead> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).IsRequired().HasMaxLength(200);
        builder.Property(e => e.LastName).HasMaxLength(200);
        builder.Property(e => e.Email).HasMaxLength(200);
        builder.Property(e => e.Phone).HasMaxLength(20);
        builder.Property(e => e.Mobile).HasMaxLength(20);
        builder.Property(e => e.CompanyName).HasMaxLength(200);
        builder.Property(e => e.Position).HasMaxLength(100);
        builder.Property(e => e.Source).HasMaxLength(100);
        builder.Property(e => e.Status).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Priority).HasMaxLength(50);
        builder.Property(e => e.Currency).HasMaxLength(10);
        builder.Property(e => e.Description).HasMaxLength(2000);
        builder.Property(e => e.Notes).HasMaxLength(4000);
        builder.Property(e => e.Address).HasMaxLength(500);
        builder.Property(e => e.City).HasMaxLength(100);
        builder.Property(e => e.Province).HasMaxLength(100);
        builder.Property(e => e.PostalCode).HasMaxLength(20);
        builder.Property(e => e.LeadSource).HasMaxLength(100);

        builder.Property(e => e.EstimatedValue).HasColumnType("decimal(18,2)");

        builder.HasOne(e => e.AssignedToUser)
            .WithMany()
            .HasForeignKey(e => e.AssignedTo)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(e => e.Email).IsUnique(false);
        builder.HasIndex(e => e.Phone).IsUnique(false);
        builder.HasIndex(e => e.Status);
        builder.HasIndex(e => e.AssignedTo);
    }
}
