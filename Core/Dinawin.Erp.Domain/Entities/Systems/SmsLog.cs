using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Systems;

/// <summary>
/// لاگ پیامک
/// SMS Log
/// </summary>
public class SmsLog : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شماره تلفن مقصد
    /// Destination phone number
    /// </summary>
    public string PhoneNumber { get; set; } = string.Empty;

    /// <summary>
    /// متن پیام
    /// Message text
    /// </summary>
    public string MessageText { get; set; } = string.Empty;

    /// <summary>
    /// وضعیت ارسال
    /// Send status
    /// </summary>
    public string SendStatus { get; set; } = "pending";

    /// <summary>
    /// تاریخ ارسال
    /// Send date
    /// </summary>
    public DateTime? SendDate { get; set; }

    /// <summary>
    /// تاریخ تحویل
    /// Delivery date
    /// </summary>
    public DateTime? DeliveryDate { get; set; }

    /// <summary>
    /// شناسه پیام از سرویس دهنده
    /// Provider message ID
    /// </summary>
    public string? ProviderMessageId { get; set; }

    /// <summary>
    /// کد خطا
    /// Error code
    /// </summary>
    public string? ErrorCode { get; set; }

    /// <summary>
    /// پیام خطا
    /// Error message
    /// </summary>
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// تعداد تلاش
    /// Retry count
    /// </summary>
    public int RetryCount { get; set; } = 0;

    /// <summary>
    /// حداکثر تلاش
    /// Max retry
    /// </summary>
    public int MaxRetry { get; set; } = 3;
}

/// <summary>
/// پیکربندی موجودیت لاگ پیامک
/// SMS Log entity configuration
/// </summary>
public class SmsLogConfiguration : IEntityTypeConfiguration<SmsLog>
{
    public void Configure(EntityTypeBuilder<SmsLog> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(20);
        builder.Property(e => e.MessageText).IsRequired().HasMaxLength(1000);
        builder.Property(e => e.SendStatus).IsRequired().HasMaxLength(50);
        builder.Property(e => e.ProviderMessageId).HasMaxLength(100);
        builder.Property(e => e.ErrorCode).HasMaxLength(50);
        builder.Property(e => e.ErrorMessage).HasMaxLength(500);

        builder.HasIndex(e => e.PhoneNumber);
        builder.HasIndex(e => e.SendStatus);
        builder.HasIndex(e => e.SendDate);
        builder.HasIndex(e => e.ProviderMessageId);
    }
}
