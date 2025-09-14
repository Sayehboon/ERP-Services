using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using System.Globalization;

namespace Dinawin.Erp.Application.Features.Dashboard.Queries.GetSalesChart;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت نمودار فروش
/// </summary>
public sealed class GetSalesChartQueryHandler : IRequestHandler<GetSalesChartQuery, SalesChartDto>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت نمودار فروش
    /// </summary>
    public GetSalesChartQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش پرس‌وجو دریافت نمودار فروش
    /// </summary>
    public Task<SalesChartDto> Handle(GetSalesChartQuery request, CancellationToken cancellationToken)
    {
        var endDate = request.EndDate ?? DateTime.UtcNow;
        var startDate = request.StartDate ?? GetStartDateByPeriod(request.Period, request.Periods, endDate);

        // در حال حاضر داده‌های نمونه برمی‌گردانیم
        // TODO: پیاده‌سازی واقعی با استفاده از جداول فروش
        var chartData = new SalesChartDto
        {
            Period = request.Period,
            Labels = GenerateLabels(request.Period, request.Periods),
            SalesAmounts = GenerateSampleSalesAmounts(request.Periods),
            SalesCounts = GenerateSampleSalesCounts(request.Periods),
            TotalSales = 0,
            TotalCount = 0,
            AverageSales = 0,
            GrowthPercentage = 0
        };

        // محاسبه آمار
        chartData.TotalSales = chartData.SalesAmounts.Sum();
        chartData.TotalCount = chartData.SalesCounts.Sum();
        chartData.AverageSales = chartData.SalesAmounts.Any() ? chartData.SalesAmounts.Average() : 0;
        
        // محاسبه درصد رشد
        if (chartData.SalesAmounts.Count >= 2)
        {
            var currentPeriod = chartData.SalesAmounts.Last();
            var previousPeriod = chartData.SalesAmounts[chartData.SalesAmounts.Count - 2];
            if (previousPeriod > 0)
            {
                chartData.GrowthPercentage = ((currentPeriod - previousPeriod) / previousPeriod) * 100;
            }
        }

        return Task.FromResult(chartData);
    }

    /// <summary>
    /// محاسبه تاریخ شروع بر اساس دوره
    /// </summary>
    private static DateTime GetStartDateByPeriod(string period, int periods, DateTime endDate)
    {
        return period.ToLower() switch
        {
            "daily" => endDate.AddDays(-periods),
            "weekly" => endDate.AddDays(-periods * 7),
            "monthly" => endDate.AddMonths(-periods),
            "yearly" => endDate.AddYears(-periods),
            _ => endDate.AddMonths(-periods)
        };
    }

    /// <summary>
    /// تولید برچسب‌ها بر اساس دوره
    /// </summary>
    private static List<string> GenerateLabels(string period, int periods)
    {
        var labels = new List<string>();
        var currentDate = DateTime.UtcNow;

        for (int i = periods - 1; i >= 0; i--)
        {
            var date = period.ToLower() switch
            {
                "daily" => currentDate.AddDays(-i),
                "weekly" => currentDate.AddDays(-i * 7),
                "monthly" => currentDate.AddMonths(-i),
                "yearly" => currentDate.AddYears(-i),
                _ => currentDate.AddMonths(-i)
            };

            labels.Add(period.ToLower() switch
            {
                "daily" => date.ToString("dd/MM"),
                "weekly" => $"هفته {GetWeekOfYear(date)}",
                "monthly" => GetPersianMonthName(date.Month),
                "yearly" => date.Year.ToString(),
                _ => GetPersianMonthName(date.Month)
            });
        }

        return labels;
    }

    /// <summary>
    /// تولید داده‌های نمونه مبلغ فروش
    /// </summary>
    private static List<decimal> GenerateSampleSalesAmounts(int periods)
    {
        var random = new Random();
        var amounts = new List<decimal>();

        for (int i = 0; i < periods; i++)
        {
            // تولید اعداد تصادفی بین 100 میلیون تا 2 میلیارد
            var amount = random.Next(100000000, 2000000000);
            amounts.Add(amount);
        }

        return amounts;
    }

    /// <summary>
    /// تولید داده‌های نمونه تعداد فروش
    /// </summary>
    private static List<int> GenerateSampleSalesCounts(int periods)
    {
        var random = new Random();
        var counts = new List<int>();

        for (int i = 0; i < periods; i++)
        {
            // تولید اعداد تصادفی بین 5 تا 50
            var count = random.Next(5, 51);
            counts.Add(count);
        }

        return counts;
    }

    /// <summary>
    /// دریافت نام ماه فارسی
    /// </summary>
    private static string GetPersianMonthName(int month)
    {
        var persianMonths = new[]
        {
            "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور",
            "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند"
        };

        return month >= 1 && month <= 12 ? persianMonths[month - 1] : month.ToString();
    }

    /// <summary>
    /// دریافت شماره هفته سال
    /// </summary>
    private static int GetWeekOfYear(DateTime date)
    {
        var calendar = CultureInfo.CurrentCulture.Calendar;
        return calendar.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Saturday);
    }
}
