using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Systems;

/// <summary>
/// حسابرسی امنیتی
/// Security Audit
/// </summary>
public class SecurityAudit : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه کاربر
    /// User ID
    /// </summary>
    public Guid? UserId { get; set; }

    /// <summary>
    /// نوع رویداد
    /// Event type
    /// </summary>
    public string EventType { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات رویداد
    /// Event description
    /// </summary>
    public string EventDescription { get; set; } = string.Empty;

    /// <summary>
    /// آدرس IP
    /// IP address
    /// </summary>
    public string IpAddress { get; set; }

    /// <summary>
    /// User Agent
    /// User agent
    /// </summary>
    public string UserAgent { get; set; }

    /// <summary>
    /// نتیجه رویداد
    /// Event result
    /// </summary>
    public string EventResult { get; set; } = string.Empty;

    /// <summary>
    /// جزئیات اضافی
    /// Additional details
    /// </summary>
    public string AdditionalDetails { get; set; }

    /// <summary>
    /// تاریخ رویداد
    /// Event date
    /// </summary>
    public DateTime EventDate { get; set; } = DateTime.UtcNow;

    // Navigation Properties
    /// <summary>
    /// کاربر مرتبط
    /// Related user
    /// </summary>
    public Users.User? User { get; set; }
}

/// <summary>
/// پیکربندی موجودیت حسابرسی امنیتی
/// Security Audit entity configuration
/// </summary>
public class SecurityAuditConfiguration : IEntityTypeConfiguration<SecurityAudit>
{
    public void Configure(EntityTypeBuilder<SecurityAudit> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.EventType).IsRequired().HasMaxLength(100);
        builder.Property(e => e.EventDescription).IsRequired().HasMaxLength(1000);
        builder.Property(e => e.IpAddress).HasMaxLength(45);
        builder.Property(e => e.UserAgent).HasMaxLength(500);
        builder.Property(e => e.EventResult).IsRequired().HasMaxLength(100);
        builder.Property(e => e.AdditionalDetails).HasMaxLength(4000);

        builder.HasOne(e => e.User)
            .WithMany()
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasIndex(e => e.UserId);
        builder.HasIndex(e => e.EventType);
        builder.HasIndex(e => e.EventDate);
        builder.HasIndex(e => e.IpAddress);
    }
}
