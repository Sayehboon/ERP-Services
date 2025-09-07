using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;
using Dinawin.Erp.Application.Features.Dashboard.Queries.GetDashboardOverview;
using Dinawin.Erp.Application.Features.Dashboard.Queries.GetSalesStats;
using Dinawin.Erp.Application.Features.Dashboard.Queries.GetInventoryStats;
using Dinawin.Erp.Application.Features.Dashboard.Queries.GetCrmStats;

namespace Dinawin.Erp.WebApi.Controllers.Dashboard;

/// <summary>
/// کنترلر داشبورد و آمار کلی
/// </summary>
[Route("api/[controller]")]
public class DashboardController : BaseController
{
    /// <summary>
    /// سازنده کنترلر داشبورد
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public DashboardController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت آمار کلی سیستم
    /// </summary>
    /// <param name="userId">شناسه کاربر</param>
    /// <param name="fromDate">تاریخ شروع</param>
    /// <param name="toDate">تاریخ پایان</param>
    /// <returns>آمار کلی سیستم</returns>
    [HttpGet("overview")]
    [ProducesResponseType(typeof(DashboardOverviewDto), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetOverview(
        [FromQuery] Guid? userId = null,
        [FromQuery] DateTime? fromDate = null,
        [FromQuery] DateTime? toDate = null)
    {
        try
        {
            var query = new GetDashboardOverviewQuery
            {
                UserId = userId,
                FromDate = fromDate,
                ToDate = toDate
            };

            var overview = await _mediator.Send(query);
            return Success(overview);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت آمار کلی");
        }
    }

    /// <summary>
    /// دریافت آمار فروش
    /// </summary>
    /// <param name="period">دوره زمانی (daily, weekly, monthly, yearly)</param>
    /// <returns>آمار فروش</returns>
    [HttpGet("sales-stats")]
    [ProducesResponseType(typeof(SalesStatsDto), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetSalesStats(
        [FromQuery] string period = "monthly",
        [FromQuery] DateTime? fromDate = null,
        [FromQuery] DateTime? toDate = null,
        [FromQuery] Guid? userId = null,
        [FromQuery] Guid? customerId = null)
    {
        try
        {
            var query = new GetSalesStatsQuery
            {
                Period = period,
                FromDate = fromDate,
                ToDate = toDate,
                UserId = userId,
                CustomerId = customerId
            };

            var salesStats = await _mediator.Send(query);
            return Success(salesStats);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت آمار فروش");
        }
    }

    /// <summary>
    /// دریافت آمار موجودی
    /// </summary>
    /// <param name="warehouseId">شناسه انبار</param>
    /// <param name="categoryId">شناسه دسته‌بندی</param>
    /// <param name="productId">شناسه محصول</param>
    /// <returns>آمار موجودی</returns>
    [HttpGet("inventory-stats")]
    [ProducesResponseType(typeof(InventoryStatsDto), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetInventoryStats(
        [FromQuery] Guid? warehouseId = null,
        [FromQuery] Guid? categoryId = null,
        [FromQuery] Guid? productId = null)
    {
        try
        {
            var query = new GetInventoryStatsQuery
            {
                WarehouseId = warehouseId,
                CategoryId = categoryId,
                ProductId = productId
            };

            var inventoryStats = await _mediator.Send(query);
            return Success(inventoryStats);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت آمار موجودی");
        }
    }

    /// <summary>
    /// دریافت آمار CRM
    /// </summary>
    /// <returns>آمار CRM</returns>
    [HttpGet("crm-stats")]
    [ProducesResponseType(typeof(CrmStatsDto), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetCrmStats()
    {
        try
        {
            var query = new GetCrmStatsQuery();
            var crmStats = await _mediator.Send(query);
            return Success(crmStats);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت آمار CRM");
        }
    }

    /// <summary>
    /// دریافت نمودار فروش
    /// </summary>
    /// <param name="period">دوره زمانی</param>
    /// <returns>داده‌های نمودار فروش</returns>
    [HttpGet("sales-chart")]
    [ProducesResponseType(typeof(object), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetSalesChart([FromQuery] string period = "monthly")
    {
        try
        {
            // TODO: پیاده‌سازی GetSalesChartQuery
            var chartData = new
            {
                Period = period,
                Labels = new[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور" },
                Data = new[] { 500000000, 800000000, 1200000000, 950000000, 1100000000, 1300000000 },
                Count = new[] { 5, 8, 12, 9, 11, 13 }
            };
            return Success(chartData);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت نمودار فروش");
        }
    }

    /// <summary>
    /// دریافت فعالیت‌های اخیر
    /// </summary>
    /// <returns>لیست فعالیت‌های اخیر</returns>
    [HttpGet("recent-activities")]
    [ProducesResponseType(typeof(IEnumerable<object>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetRecentActivities()
    {
        try
        {
            // TODO: پیاده‌سازی GetRecentActivitiesQuery
            var activities = new List<object>
            {
                new { 
                    Id = Guid.NewGuid(),
                    Type = "Sale",
                    Description = "فروش تویوتا کامری ۱۴۰۳",
                    UserName = "احمد محمدی",
                    Timestamp = DateTime.Now.AddHours(-2),
                    Amount = 500000000
                },
                new { 
                    Id = Guid.NewGuid(),
                    Type = "Lead",
                    Description = "لید جدید: علی رضایی",
                    UserName = "سارا احمدی",
                    Timestamp = DateTime.Now.AddHours(-4),
                    Amount = null
                },
                new { 
                    Id = Guid.NewGuid(),
                    Type = "Purchase",
                    Description = "خرید ۵ دستگاه تویوتا کامری",
                    UserName = "محمد کریمی",
                    Timestamp = DateTime.Now.AddHours(-6),
                    Amount = 2500000000
                }
            };
            return Success(activities);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت فعالیت‌های اخیر");
        }
    }
}
