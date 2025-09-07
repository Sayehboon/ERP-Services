namespace Dinawin.Erp.Application.Features.Dashboard.Queries.GetSalesStats;

/// <summary>
/// مدل انتقال داده آمار فروش
/// </summary>
public sealed class SalesStatsDto
{
    /// <summary>
    /// مجموع فروش
    /// </summary>
    public decimal TotalSales { get; set; }

    /// <summary>
    /// تعداد سفارشات
    /// </summary>
    public int TotalOrders { get; set; }

    /// <summary>
    /// میانگین ارزش سفارش
    /// </summary>
    public decimal AverageOrderValue { get; set; }

    /// <summary>
    /// تعداد مشتریان
    /// </summary>
    public int TotalCustomers { get; set; }

    /// <summary>
    /// درصد رشد نسبت به دوره قبل
    /// </summary>
    public decimal GrowthPercentage { get; set; }

    /// <summary>
    /// آمار فروش بر اساس وضعیت
    /// </summary>
    public List<SalesStatusStatsDto> StatusStats { get; set; } = new();

    /// <summary>
    /// آمار فروش بر اساس مشتری
    /// </summary>
    public List<CustomerSalesStatsDto> CustomerStats { get; set; } = new();

    /// <summary>
    /// آمار فروش روزانه
    /// </summary>
    public List<DailySalesStatsDto> DailyStats { get; set; } = new();
}

/// <summary>
/// مدل آمار فروش بر اساس وضعیت
/// </summary>
public sealed class SalesStatusStatsDto
{
    /// <summary>
    /// وضعیت سفارش
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// تعداد سفارشات
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// مجموع فروش
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// درصد از کل
    /// </summary>
    public decimal Percentage { get; set; }
}

/// <summary>
/// مدل آمار فروش بر اساس مشتری
/// </summary>
public sealed class CustomerSalesStatsDto
{
    /// <summary>
    /// شناسه مشتری
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// نام مشتری
    /// </summary>
    public string CustomerName { get; set; } = string.Empty;

    /// <summary>
    /// تعداد سفارشات
    /// </summary>
    public int OrderCount { get; set; }

    /// <summary>
    /// مجموع فروش
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// میانگین ارزش سفارش
    /// </summary>
    public decimal AverageOrderValue { get; set; }
}

/// <summary>
/// مدل آمار فروش روزانه
/// </summary>
public sealed class DailySalesStatsDto
{
    /// <summary>
    /// تاریخ
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// تعداد سفارشات
    /// </summary>
    public int OrderCount { get; set; }

    /// <summary>
    /// مجموع فروش
    /// </summary>
    public decimal TotalAmount { get; set; }
}
