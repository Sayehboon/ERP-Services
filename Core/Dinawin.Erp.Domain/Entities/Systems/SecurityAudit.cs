using Dinawin.Erp.Domain.Common;

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
    public string? IpAddress { get; set; }

    /// <summary>
    /// User Agent
    /// User agent
    /// </summary>
    public string? UserAgent { get; set; }

    /// <summary>
    /// نتیجه رویداد
    /// Event result
    /// </summary>
    public string EventResult { get; set; } = string.Empty;

    /// <summary>
    /// جزئیات اضافی
    /// Additional details
    /// </summary>
    public string? AdditionalDetails { get; set; }

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
