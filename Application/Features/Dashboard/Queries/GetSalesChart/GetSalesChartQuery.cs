using MediatR;

namespace Dinawin.Erp.Application.Features.Dashboard.Queries.GetSalesChart;

/// <summary>
/// پرس‌وجو دریافت نمودار فروش
/// </summary>
public sealed class GetSalesChartQuery : IRequest<SalesChartDto>
{
    /// <summary>
    /// دوره زمانی (daily, weekly, monthly, yearly)
    /// </summary>
    public string Period { get; init; } = "monthly";

    /// <summary>
    /// تعداد دوره‌های گذشته
    /// </summary>
    public int Periods { get; init; } = 6;

    /// <summary>
    /// تاریخ شروع (اختیاری)
    /// </summary>
    public DateTime? StartDate { get; init; }

    /// <summary>
    /// تاریخ پایان (اختیاری)
    /// </summary>
    public DateTime? EndDate { get; init; }
}
