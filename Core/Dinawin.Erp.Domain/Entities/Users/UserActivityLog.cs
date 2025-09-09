using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Users;

/// <summary>
/// لاگ فعالیت کاربر (مطابق Supabase: user_activity_logs)
/// User activity log entity
/// </summary>
public class UserActivityLog : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه کاربر (auth)
    /// User id
    /// </summary>
    public Guid? UserId { get; set; }

    /// <summary>
    /// نوع فعالیت
    /// Activity type
    /// </summary>
    public required string ActivityType { get; set; }

    /// <summary>
    /// داده‌های فعالیت (JSON)
    /// Activity data (JSON)
    /// </summary>
    public string? ActivityDataJson { get; set; }

    /// <summary>
    /// آدرس IP
    /// IP address
    /// </summary>
    public string? IpAddress { get; set; }

    /// <summary>
    /// مرورگر/عامل کاربر
    /// User agent
    /// </summary>
    public string? UserAgent { get; set; }
}


