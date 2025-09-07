using MediatR;

namespace Dinawin.Erp.Application.Features.Dashboard.Queries.GetDashboardOverview;

/// <summary>
/// پرس‌وجو دریافت نمای کلی داشبورد
/// </summary>
public sealed class GetDashboardOverviewQuery : IRequest<DashboardOverviewDto>
{
    /// <summary>
    /// شناسه کاربر
    /// </summary>
    public Guid? UserId { get; init; }

    /// <summary>
    /// تاریخ شروع برای فیلتر
    /// </summary>
    public DateTime? FromDate { get; init; }

    /// <summary>
    /// تاریخ پایان برای فیلتر
    /// </summary>
    public DateTime? ToDate { get; init; }
}
