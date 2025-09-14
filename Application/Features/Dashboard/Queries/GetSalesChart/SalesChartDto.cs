namespace Dinawin.Erp.Application.Features.Dashboard.Queries.GetSalesChart;

/// <summary>
/// DTO نمودار فروش
/// </summary>
public class SalesChartDto
{
    /// <summary>
    /// دوره زمانی
    /// </summary>
    public string Period { get; set; } = string.Empty;

    /// <summary>
    /// برچسب‌های محور X
    /// </summary>
    public List<string> Labels { get; set; } = new();

    /// <summary>
    /// داده‌های مبلغ فروش
    /// </summary>
    public List<decimal> SalesAmounts { get; set; } = new();

    /// <summary>
    /// داده‌های تعداد فروش
    /// </summary>
    public List<int> SalesCounts { get; set; } = new();

    /// <summary>
    /// مجموع فروش
    /// </summary>
    public decimal TotalSales { get; set; }

    /// <summary>
    /// مجموع تعداد فروش
    /// </summary>
    public int TotalCount { get; set; }

    /// <summary>
    /// میانگین فروش
    /// </summary>
    public decimal AverageSales { get; set; }

    /// <summary>
    /// درصد رشد نسبت به دوره قبل
    /// </summary>
    public decimal GrowthPercentage { get; set; }
}
