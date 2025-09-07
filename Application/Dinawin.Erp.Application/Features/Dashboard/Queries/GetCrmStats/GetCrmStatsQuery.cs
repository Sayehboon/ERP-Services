using MediatR;

namespace Dinawin.Erp.Application.Features.Dashboard.Queries.GetCrmStats;

/// <summary>
/// پرس‌وجو دریافت آمار CRM
/// </summary>
public sealed class GetCrmStatsQuery : IRequest<CrmStatsDto>
{
    /// <summary>
    /// تاریخ شروع برای فیلتر
    /// </summary>
    public DateTime? FromDate { get; init; }

    /// <summary>
    /// تاریخ پایان برای فیلتر
    /// </summary>
    public DateTime? ToDate { get; init; }

    /// <summary>
    /// شناسه کاربر برای فیلتر
    /// </summary>
    public Guid? UserId { get; init; }
}
