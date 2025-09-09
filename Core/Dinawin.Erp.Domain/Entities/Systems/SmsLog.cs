using Dinawin.Erp.Domain.Common;

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
