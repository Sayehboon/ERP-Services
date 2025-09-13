using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;
using Dinawin.Erp.Application.Features.Dashboard.Queries.GetDashboardOverview;
using Dinawin.Erp.Application.Features.Dashboard.Queries.GetSalesStats;
using Dinawin.Erp.Application.Features.Dashboard.Queries.GetInventoryStats;
using Dinawin.Erp.Application.Features.Dashboard.Queries.GetCrmStats;
using Dinawin.Erp.Application.Features.Dashboard.Queries.GetSalesChart;
using Dinawin.Erp.Application.Features.Dashboard.Queries.GetRecentActivities;

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
    public async Task<object> GetOverview(
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
    public async Task<object> GetSalesStats(
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
    public async Task<object> GetInventoryStats(
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
    public async Task<object> GetCrmStats()
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
    public async Task<object> GetSalesChart([FromQuery] string period = "monthly")
    {
        try
        {
            var query = new GetSalesChartQuery
            {
                Period = period
            };
            
            var chartData = await _mediator.Send(query);
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
    public async Task<object> GetRecentActivities()
    {
        try
        {
            var query = new GetRecentActivitiesQuery
            {
                Count = 10
            };
            
            var activities = await _mediator.Send(query);
            return Success(activities);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت فعالیت‌های اخیر");
        }
    }
}
