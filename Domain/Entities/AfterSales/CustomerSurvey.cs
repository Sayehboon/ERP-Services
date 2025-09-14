using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.AfterSales;

/// <summary>
/// نظرسنجی رضایت مشتری مطابق Supabase: public.customer_surveys
/// Customer satisfaction survey entity aligned with Supabase schema
/// </summary>
public class CustomerSurvey : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه کسب‌وکار
    /// Business ID
    /// </summary>
    public Guid BusinessId { get; set; }

    /// <summary>
    /// شماره نظرسنجی (یکتا)
    /// Survey number (unique)
    /// </summary>
    public required string SurveyNumber { get; set; }

    /// <summary>
    /// نام مشتری
    /// Customer name
    /// </summary>
    public required string CustomerName { get; set; }

    /// <summary>
    /// تلفن مشتری
    /// Customer phone
    /// </summary>
    public required string CustomerPhone { get; set; }

    /// <summary>
    /// ایمیل مشتری
    /// Customer email
    /// </summary>
    public string CustomerEmail { get; set; }

    /// <summary>
    /// نوع خدمت: repair|warranty|support|consultation
    /// Service type
    /// </summary>
    public required string ServiceType { get; set; }

    /// <summary>
    /// شناسه/کد خدمت مرتبط
    /// Related service id/code
    /// </summary>
    public required string ServiceId { get; set; }

    /// <summary>
    /// امتیاز کلی 1..5
    /// Overall rating 1..5
    /// </summary>
    public int OverallRating { get; set; }

    /// <summary>
    /// امتیاز کیفیت 1..5
    /// Quality rating 1..5
    /// </summary>
    public int? QualityRating { get; set; }

    /// <summary>
    /// امتیاز سرعت 1..5
    /// Speed rating 1..5
    /// </summary>
    public int? SpeedRating { get; set; }

    /// <summary>
    /// امتیاز پشتیبانی 1..5
    /// Support rating 1..5
    /// </summary>
    public int? SupportRating { get; set; }

    /// <summary>
    /// امتیاز قیمت 1..5
    /// Pricing rating 1..5
    /// </summary>
    public int? PricingRating { get; set; }

    /// <summary>
    /// بازخورد متنی
    /// Feedback
    /// </summary>
    public string Feedback { get; set; }

    /// <summary>
    /// نیاز به پیگیری
    /// Follow up needed
    /// </summary>
    public bool FollowUpNeeded { get; set; }

    /// <summary>
    /// وضعیت: pending|completed|needs_attention|escalated
    /// Status
    /// </summary>
    public string Status { get; set; } = "completed";

    /// <summary>
    /// زمان ارسال نظرسنجی
    /// Submitted at
    /// </summary>
    public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
}

/// <summary>
/// پیکربندی موجودیت نظرسنجی رضایت مشتری
/// Customer Survey entity configuration
/// </summary>
public class CustomerSurveyConfiguration : IEntityTypeConfiguration<CustomerSurvey>
{
    public void Configure(EntityTypeBuilder<CustomerSurvey> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.SurveyNumber).IsRequired().HasMaxLength(100);
        builder.Property(e => e.CustomerName).IsRequired().HasMaxLength(200);
        builder.Property(e => e.CustomerPhone).IsRequired().HasMaxLength(20);
        builder.Property(e => e.CustomerEmail).HasMaxLength(200);
        builder.Property(e => e.ServiceType).IsRequired().HasMaxLength(50);
        builder.Property(e => e.ServiceId).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Feedback).HasMaxLength(2000);
        builder.Property(e => e.Status).HasMaxLength(50);

        builder.HasIndex(e => e.SurveyNumber).IsUnique();
        builder.HasIndex(e => e.CustomerPhone);
        builder.HasIndex(e => e.ServiceType);
        builder.HasIndex(e => e.Status);
        builder.HasIndex(e => e.SubmittedAt);
    }
}

