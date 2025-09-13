using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.Application.Services;
using Dinawin.Erp.WebApi.Controllers;

namespace Dinawin.Erp.WebApi.Controllers.SystemManagement;

/// <summary>
/// کنترلر برای وارد کردن داده‌های نمونه
/// Controller for seeding sample data
/// </summary>
[Route("api/[controller]")]
public class SampleDataController : BaseController
{
    private readonly SampleDataService _sampleDataService;

    /// <summary>
    /// سازنده کنترلر داده‌های نمونه
    /// </summary>
    /// <param name="sampleDataService">سرویس داده‌های نمونه</param>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public SampleDataController(SampleDataService sampleDataService, IMediator mediator) : base(mediator)
    {
        _sampleDataService = sampleDataService;
    }

    /// <summary>
    /// وارد کردن تمام داده‌های نمونه
    /// Seed all sample data
    /// </summary>
    /// <returns>نتیجه عملیات</returns>
    [HttpPost("seed-all")]
    public async Task<ActionResult<object>> SeedAllData()
    {
        try
        {
            await _sampleDataService.SeedAllSampleDataAsync();
            return Success("تمام داده‌های نمونه با موفقیت وارد شدند");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در وارد کردن داده‌ها");
        }
    }

    /// <summary>
    /// وارد کردن داده‌های نمونه CRM
    /// Seed CRM sample data
    /// </summary>
    /// <returns>نتیجه عملیات</returns>
    [HttpPost("seed-crm")]
    public async Task<ActionResult> SeedCrmData()
    {
        try
        {
            await _sampleDataService.SeedCrmDataAsync();
            return Success("داده‌های نمونه CRM با موفقیت وارد شدند");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در وارد کردن داده‌های CRM");
        }
    }

    /// <summary>
    /// وارد کردن داده‌های نمونه سفارشات فروش
    /// Seed Sales Orders sample data
    /// </summary>
    /// <returns>نتیجه عملیات</returns>
    [HttpPost("seed-sales-orders")]
    public async Task<ActionResult<object>> SeedSalesOrdersData()
    {
        try
        {
            await _sampleDataService.SeedSalesOrdersDataAsync();
            return Success("داده‌های نمونه سفارشات فروش با موفقیت وارد شدند");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در وارد کردن داده‌های سفارشات فروش");
        }
    }

    /// <summary>
    /// وارد کردن داده‌های نمونه سفارشات خرید
    /// Seed Purchase Orders sample data
    /// </summary>
    /// <returns>نتیجه عملیات</returns>
    [HttpPost("seed-purchase-orders")]
    public async Task<ActionResult<object>> SeedPurchaseOrdersData()
    {
        try
        {
            await _sampleDataService.SeedPurchaseOrdersDataAsync();
            return Success("داده‌های نمونه سفارشات خرید با موفقیت وارد شدند");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در وارد کردن داده‌های سفارشات خرید");
        }
    }

    /// <summary>
    /// وارد کردن داده‌های نمونه محصولات
    /// Seed Product sample data
    /// </summary>
    /// <returns>نتیجه عملیات</returns>
    [HttpPost("seed-products")]
    public async Task<ActionResult<object>> SeedProductData()
    {
        try
        {
            await _sampleDataService.SeedProductDataAsync();
            return Success("داده‌های نمونه محصولات با موفقیت وارد شدند");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در وارد کردن داده‌های محصولات");
        }
    }

    /// <summary>
    /// وارد کردن داده‌های نمونه مخاطبین
    /// Seed Contacts sample data
    /// </summary>
    /// <returns>نتیجه عملیات</returns>
    [HttpPost("seed-contacts")]
    public async Task<ActionResult<object>> SeedContactsData()
    {
        try
        {
            await _sampleDataService.SeedContactsDataAsync();
            return Success("داده‌های نمونه مخاطبین با موفقیت وارد شدند");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در وارد کردن داده‌های مخاطبین");
        }
    }

    /// <summary>
    /// وارد کردن داده‌های نمونه لیدها
    /// Seed Leads sample data
    /// </summary>
    /// <returns>نتیجه عملیات</returns>
    [HttpPost("seed-leads")]
    public async Task<ActionResult<object>> SeedLeadsData()
    {
        try
        {
            await _sampleDataService.SeedLeadsDataAsync();
            return Success("داده‌های نمونه لیدها با موفقیت وارد شدند");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در وارد کردن داده‌های لیدها");
        }
    }

    /// <summary>
    /// وارد کردن داده‌های نمونه فرصت‌ها
    /// Seed Opportunities sample data
    /// </summary>
    /// <returns>نتیجه عملیات</returns>
    [HttpPost("seed-opportunities")]
    public async Task<ActionResult<object>> SeedOpportunitiesData()
    {
        try
        {
            await _sampleDataService.SeedOpportunitiesDataAsync();
            return Success("داده‌های نمونه فرصت‌ها با موفقیت وارد شدند");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در وارد کردن داده‌های فرصت‌ها");
        }
    }

    /// <summary>
    /// وارد کردن داده‌های نمونه تیکت‌ها
    /// Seed Tickets sample data
    /// </summary>
    /// <returns>نتیجه عملیات</returns>
    [HttpPost("seed-tickets")]
    public async Task<ActionResult<object>> SeedTicketsData()
    {
        try
        {
            await _sampleDataService.SeedTicketsDataAsync();
            return Success("داده‌های نمونه تیکت‌ها با موفقیت وارد شدند");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در وارد کردن داده‌های تیکت‌ها");
        }
    }
}
