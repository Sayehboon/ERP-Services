using MediatR;

namespace Dinawin.Erp.Application.Features.TaskManagement.Tasks.Queries.GetTaskStatistics;

/// <summary>
/// پرس‌وجو دریافت آمار وظایف
/// </summary>
public sealed class GetTaskStatisticsQuery : IRequest<TaskStatisticsDto>
{
    /// <summary>
    /// شناسه پروژه (اختیاری)
    /// </summary>
    public Guid? ProjectId { get; init; }

    /// <summary>
    /// شناسه کاربر (اختیاری)
    /// </summary>
    public Guid? UserId { get; init; }

    /// <summary>
    /// تاریخ شروع (اختیاری)
    /// </summary>
    public DateTime? FromDate { get; init; }

    /// <summary>
    /// تاریخ پایان (اختیاری)
    /// </summary>
    public DateTime? ToDate { get; init; }

    /// <summary>
    /// نوع آمار
    /// </summary>
    public string StatisticsType { get; init; } = "overview";
}
