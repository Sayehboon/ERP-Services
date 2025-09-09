using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Crm;

/// <summary>
/// موجودیت کمپین ایمیل
/// Email Campaign entity
/// </summary>
public class EmailCampaign : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// نام کمپین
    /// Campaign name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// موضوع ایمیل
    /// Email subject
    /// </summary>
    public string Subject { get; set; } = string.Empty;

    /// <summary>
    /// محتوای ایمیل
    /// Email content
    /// </summary>
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// وضعیت کمپین
    /// Campaign status
    /// </summary>
    public string Status { get; set; } = "draft"; // draft, scheduled, sent, cancelled

    /// <summary>
    /// تاریخ ارسال
    /// Send date
    /// </summary>
    public DateTime? SentDate { get; set; }

    /// <summary>
    /// تعداد گیرندگان
    /// Number of recipients
    /// </summary>
    public int Recipients { get; set; }

    /// <summary>
    /// تعداد باز شده
    /// Number of opened emails
    /// </summary>
    public int Opened { get; set; }

    /// <summary>
    /// تعداد کلیک شده
    /// Number of clicked emails
    /// </summary>
    public int Clicked { get; set; }

    /// <summary>
    /// نرخ باز شدن
    /// Open rate
    /// </summary>
    public decimal OpenRate { get; set; }

    /// <summary>
    /// نرخ کلیک
    /// Click rate
    /// </summary>
    public decimal ClickRate { get; set; }

    /// <summary>
    /// قالب ایمیل
    /// Email template
    /// </summary>
    public string? Template { get; set; }

    /// <summary>
    /// شناسه کاربر ایجادکننده
    /// Created by user ID
    /// </summary>
    public Guid? CreatedBy { get; set; }

    /// <summary>
    /// کاربر ایجادکننده
    /// Created by user
    /// </summary>
    public User? CreatedByUser { get; set; }

    /// <summary>
    /// پاسخ‌های ایمیل
    /// Email responses
    /// </summary>
    public ICollection<EmailResponse> Responses { get; set; } = new List<EmailResponse>();
}

/// <summary>
/// موجودیت پاسخ ایمیل
/// Email Response entity
/// </summary>
public class EmailResponse : BaseEntity
{
    /// <summary>
    /// شناسه کمپین ایمیل
    /// Email campaign ID
    /// </summary>
    public Guid EmailCampaignId { get; set; }

    /// <summary>
    /// شناسه مخاطب
    /// Contact ID
    /// </summary>
    public Guid ContactId { get; set; }

    /// <summary>
    /// آیا ایمیل باز شده است
    /// Is email opened
    /// </summary>
    public bool IsOpened { get; set; }

    /// <summary>
    /// تاریخ باز شدن
    /// Open date
    /// </summary>
    public DateTime? OpenedDate { get; set; }

    /// <summary>
    /// آیا کلیک شده است
    /// Is clicked
    /// </summary>
    public bool IsClicked { get; set; }

    /// <summary>
    /// تاریخ کلیک
    /// Click date
    /// </summary>
    public DateTime? ClickedDate { get; set; }

    /// <summary>
    /// آیا پاسخ داده شده است
    /// Is replied
    /// </summary>
    public bool IsReplied { get; set; }

    /// <summary>
    /// تاریخ پاسخ
    /// Reply date
    /// </summary>
    public DateTime? RepliedDate { get; set; }

    /// <summary>
    /// کمپین ایمیل
    /// Email campaign
    /// </summary>
    public EmailCampaign? EmailCampaign { get; set; }

    /// <summary>
    /// مخاطب
    /// Contact
    /// </summary>
    public Contact? Contact { get; set; }
}

/// <summary>
/// پیکربندی موجودیت کمپین ایمیل
/// Email Campaign entity configuration
/// </summary>
public class EmailCampaignConfiguration : IEntityTypeConfiguration<EmailCampaign>
{
    public void Configure(EntityTypeBuilder<EmailCampaign> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Subject).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Content).IsRequired().HasMaxLength(10000);
        builder.Property(e => e.Status).HasMaxLength(50);
        builder.Property(e => e.Template).HasMaxLength(100);

        builder.Property(e => e.OpenRate).HasPrecision(5, 2);
        builder.Property(e => e.ClickRate).HasPrecision(5, 2);

        builder.HasOne(e => e.CreatedByUser)
            .WithMany()
            .HasForeignKey(e => e.CreatedBy)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(e => e.Status);
        builder.HasIndex(e => e.SentDate);
        builder.HasIndex(e => e.CreatedBy);
    }
}

/// <summary>
/// پیکربندی موجودیت پاسخ ایمیل
/// Email Response entity configuration
/// </summary>
public class EmailResponseConfiguration : IEntityTypeConfiguration<EmailResponse>
{
    public void Configure(EntityTypeBuilder<EmailResponse> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasOne(e => e.EmailCampaign)
            .WithMany(ec => ec.Responses)
            .HasForeignKey(e => e.EmailCampaignId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Contact)
            .WithMany()
            .HasForeignKey(e => e.ContactId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.EmailCampaignId);
        builder.HasIndex(e => e.ContactId);
        builder.HasIndex(e => e.OpenedDate);
        builder.HasIndex(e => e.ClickedDate);
    }
}
