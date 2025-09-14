using MediatR;

namespace Dinawin.Erp.Application.Features.Dashboard.Queries.GetRecentActivities;

/// <summary>
/// پرس‌وجو دریافت فعالیت‌های اخیر
/// </summary>
public sealed class GetRecentActivitiesQuery : IRequest<IEnumerable<RecentActivityDto>>
{
    /// <summary>
    /// تعداد فعالیت‌ها
    /// </summary>
    public int Count { get; init; } = 10;

    /// <summary>
    /// نوع فعالیت (اختیاری)
    /// </summary>
    public string ActivityType { get; init; }

    /// <summary>
    /// شناسه کاربر (اختیاری)
    /// </summary>
    public Guid? UserId { get; init; }
}
