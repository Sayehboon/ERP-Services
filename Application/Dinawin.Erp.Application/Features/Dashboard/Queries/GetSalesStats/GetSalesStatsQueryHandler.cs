using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Dashboard.Queries.GetSalesStats;

/// <summary>
/// مدیریت‌کننده پرس‌وجو دریافت آمار فروش
/// </summary>
public sealed class GetSalesStatsQueryHandler : IRequestHandler<GetSalesStatsQuery, SalesStatsDto>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده پرس‌وجو دریافت آمار فروش
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public GetSalesStatsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای پرس‌وجو دریافت آمار فروش
    /// </summary>
    public async Task<SalesStatsDto> Handle(GetSalesStatsQuery request, CancellationToken cancellationToken)
    {
        var (fromDate, toDate) = GetDateRange(request.Period, request.FromDate, request.ToDate);
        var previousPeriodDates = GetPreviousPeriodDates(request.Period, fromDate, toDate);

        var query = _context.SalesOrders.AsQueryable();

        // اعمال فیلترها
        query = query.Where(so => so.OrderDate >= fromDate && so.OrderDate <= toDate);

        if (request.UserId.HasValue)
        {
            query = query.Where(so => so.CreatedBy == request.UserId.Value);
        }

        if (request.CustomerId.HasValue)
        {
            query = query.Where(so => so.CustomerId == request.CustomerId.Value);
        }

        // محاسبه آمار کلی
        var totalSales = await query.SumAsync(so => so.TotalAmount, cancellationToken);
        var totalOrders = await query.CountAsync(cancellationToken);
        var averageOrderValue = totalOrders > 0 ? totalSales / totalOrders : 0;
        var totalCustomers = await query.Select(so => so.CustomerId).Distinct().CountAsync(cancellationToken);

        // محاسبه آمار دوره قبل
        var previousQuery = _context.SalesOrders
            .Where(so => so.OrderDate >= previousPeriodDates.fromDate && so.OrderDate <= previousPeriodDates.toDate);
        
        if (request.UserId.HasValue)
        {
            previousQuery = previousQuery.Where(so => so.CreatedBy == request.UserId.Value);
        }

        if (request.CustomerId.HasValue)
        {
            previousQuery = previousQuery.Where(so => so.CustomerId == request.CustomerId.Value);
        }

        var previousTotalSales = await previousQuery.SumAsync(so => so.TotalAmount, cancellationToken);
        var growthPercentage = previousTotalSales > 0 ? ((totalSales - previousTotalSales) / previousTotalSales) * 100 : 0;

        // آمار بر اساس وضعیت
        var statusStats = await query
            .GroupBy(so => so.Status)
            .Select(g => new SalesStatusStatsDto
            {
                Status = g.Key,
                Count = g.Count(),
                TotalAmount = g.Sum(so => so.TotalAmount)
            })
            .ToListAsync(cancellationToken);

        var totalAmount = statusStats.Sum(s => s.TotalAmount);
        foreach (var stat in statusStats)
        {
            stat.Percentage = totalAmount > 0 ? (stat.TotalAmount / totalAmount) * 100 : 0;
        }

        // آمار بر اساس مشتری (Top 10)
        var customerStats = await query
            .Include(so => so.Customer)
            .GroupBy(so => new { so.CustomerId, so.Customer.Name })
            .Select(g => new CustomerSalesStatsDto
            {
                CustomerId = g.Key.CustomerId,
                CustomerName = g.Key.Name,
                OrderCount = g.Count(),
                TotalAmount = g.Sum(so => so.TotalAmount),
                AverageOrderValue = g.Average(so => so.TotalAmount)
            })
            .OrderByDescending(c => c.TotalAmount)
            .Take(10)
            .ToListAsync(cancellationToken);

        // آمار روزانه
        var dailyStats = await query
            .GroupBy(so => so.OrderDate.Date)
            .Select(g => new DailySalesStatsDto
            {
                Date = g.Key,
                OrderCount = g.Count(),
                TotalAmount = g.Sum(so => so.TotalAmount)
            })
            .OrderBy(d => d.Date)
            .ToListAsync(cancellationToken);

        return new SalesStatsDto
        {
            TotalSales = totalSales,
            TotalOrders = totalOrders,
            AverageOrderValue = averageOrderValue,
            TotalCustomers = totalCustomers,
            GrowthPercentage = growthPercentage,
            StatusStats = statusStats,
            CustomerStats = customerStats,
            DailyStats = dailyStats
        };
    }

    /// <summary>
    /// محاسبه محدوده تاریخ بر اساس دوره
    /// </summary>
    private static (DateTime fromDate, DateTime toDate) GetDateRange(string period, DateTime? fromDate, DateTime? toDate)
    {
        if (fromDate.HasValue && toDate.HasValue)
        {
            return (fromDate.Value, toDate.Value);
        }

        var now = DateTime.UtcNow;
        return period.ToLower() switch
        {
            "daily" => (now.Date, now.Date.AddDays(1).AddTicks(-1)),
            "weekly" => (now.Date.AddDays(-7), now.Date.AddDays(1).AddTicks(-1)),
            "monthly" => (new DateTime(now.Year, now.Month, 1), now.Date.AddDays(1).AddTicks(-1)),
            "yearly" => (new DateTime(now.Year, 1, 1), now.Date.AddDays(1).AddTicks(-1)),
            _ => (now.Date.AddDays(-30), now.Date.AddDays(1).AddTicks(-1))
        };
    }

    /// <summary>
    /// محاسبه محدوده تاریخ دوره قبل
    /// </summary>
    private static (DateTime fromDate, DateTime toDate) GetPreviousPeriodDates(string period, DateTime fromDate, DateTime toDate)
    {
        var duration = toDate - fromDate;
        return (fromDate - duration, fromDate.AddTicks(-1));
    }
}
