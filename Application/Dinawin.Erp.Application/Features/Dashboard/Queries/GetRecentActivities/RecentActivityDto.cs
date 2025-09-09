namespace Dinawin.Erp.Application.Features.Dashboard.Queries.GetRecentActivities;

/// <summary>
/// DTO فعالیت اخیر
/// </summary>
public class RecentActivityDto
{
    /// <summary>
    /// شناسه فعالیت
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// نوع فعالیت
    /// </summary>
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// عنوان فعالیت
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات فعالیت
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// نام کاربر
    /// </summary>
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// زمان فعالیت
    /// </summary>
    public DateTime Timestamp { get; set; }

    /// <summary>
    /// مبلغ (در صورت وجود)
    /// </summary>
    public decimal? Amount { get; set; }

    /// <summary>
    /// وضعیت
    /// </summary>
    public string? Status { get; set; }

    /// <summary>
    /// اولویت
    /// </summary>
    public string? Priority { get; set; }

    /// <summary>
    /// شناسه مرجع (مثل شناسه سفارش، مشتری و...)
    /// </summary>
    public Guid? ReferenceId { get; set; }

    /// <summary>
    /// نوع مرجع
    /// </summary>
    public string? ReferenceType { get; set; }
}
