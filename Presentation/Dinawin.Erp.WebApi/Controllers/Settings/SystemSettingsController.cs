using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;
using Dinawin.Erp.Application.Features.SystemSettings.Queries.GetAllSystemSettings;
using Dinawin.Erp.Application.Features.SystemSettings.Queries.GetSystemSettingByKey;
using Dinawin.Erp.Application.Features.SystemSettings.Queries.GetSystemSettingsByCategory;
using Dinawin.Erp.Application.Features.SystemSettings.Queries.GetSystemSettingCategories;
using Dinawin.Erp.Application.Features.SystemSettings.Commands.UpdateSystemSettingByKey;
using Dinawin.Erp.Application.Features.SystemSettings.Commands.UpdateSystemSettingsBatch;
using Dinawin.Erp.Application.Features.SystemSettings.Commands.ResetSystemSettings;

namespace Dinawin.Erp.WebApi.Controllers.Settings;

/// <summary>
/// کنترلر تنظیمات سیستم
/// </summary>
[Route("api/[controller]")]
public class SystemSettingsController : BaseController
{
    /// <summary>
    /// سازنده کنترلر تنظیمات سیستم
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public SystemSettingsController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت تمام تنظیمات سیستم
    /// </summary>
    /// <param name="searchTerm">عبارت جستجو</param>
    /// <param name="category">دسته‌بندی</param>
    /// <param name="dataType">نوع داده</param>
    /// <param name="isActive">وضعیت فعال بودن</param>
    /// <param name="isEditable">وضعیت قابل ویرایش بودن</param>
    /// <param name="page">شماره صفحه</param>
    /// <param name="pageSize">تعداد آیتم در هر صفحه</param>
    /// <returns>لیست تمام تنظیمات</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<SystemSettingDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetAllSettings(
        [FromQuery] string? searchTerm = null,
        [FromQuery] string? category = null,
        [FromQuery] string? dataType = null,
        [FromQuery] bool? isActive = null,
        [FromQuery] bool? isEditable = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 25)
    {
        try
        {
            var query = new GetAllSystemSettingsQuery
            {
                SearchTerm = searchTerm,
                Category = category,
                DataType = dataType,
                IsActive = isActive,
                IsEditable = isEditable,
                Page = page,
                PageSize = pageSize
            };

            var settings = await _mediator.Send(query);
            return Success(settings);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت تنظیمات سیستم");
        }
    }

    /// <summary>
    /// دریافت تنظیم بر اساس کلید
    /// </summary>
    /// <param name="key">کلید تنظیم</param>
    /// <returns>مقدار تنظیم</returns>
    [HttpGet("{key}")]
    [ProducesResponseType(typeof(SystemSettingDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> GetSetting(string key)
    {
        try
        {
            var query = new GetSystemSettingByKeyQuery { Key = key };
            var setting = await _mediator.Send(query);
            
            if (setting == null)
            {
                return NotFound($"تنظیم با کلید {key} یافت نشد");
            }
            
            return Success(setting);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت تنظیم");
        }
    }

    /// <summary>
    /// دریافت تنظیمات یک دسته‌بندی
    /// </summary>
    /// <param name="category">دسته‌بندی تنظیمات</param>
    /// <param name="searchTerm">عبارت جستجو</param>
    /// <param name="page">شماره صفحه</param>
    /// <param name="pageSize">تعداد آیتم در هر صفحه</param>
    /// <returns>لیست تنظیمات دسته‌بندی</returns>
    [HttpGet("category/{category}")]
    [ProducesResponseType(typeof(IEnumerable<SystemSettingDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetSettingsByCategory(
        string category,
        [FromQuery] string? searchTerm = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 25)
    {
        try
        {
            var query = new GetSystemSettingsByCategoryQuery
            {
                Category = category,
                SearchTerm = searchTerm,
                Page = page,
                PageSize = pageSize
            };

            var settings = await _mediator.Send(query);
            return Success(settings);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت تنظیمات دسته‌بندی");
        }
    }

    /// <summary>
    /// به‌روزرسانی تنظیم
    /// </summary>
    /// <param name="key">کلید تنظیم</param>
    /// <param name="command">دستور به‌روزرسانی</param>
    /// <returns>نتیجه به‌روزرسانی</returns>
    [HttpPut("{key}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> UpdateSetting(string key, [FromBody] UpdateSystemSettingByKeyCommand command)
    {
        try
        {
            command.Key = key;
            var result = await _mediator.Send(command);
            return Success("تنظیم با موفقیت به‌روزرسانی شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در به‌روزرسانی تنظیم");
        }
    }

    /// <summary>
    /// به‌روزرسانی چندین تنظیم
    /// </summary>
    /// <param name="command">دستور به‌روزرسانی دسته‌ای</param>
    /// <returns>نتیجه به‌روزرسانی</returns>
    [HttpPut("batch")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> UpdateSettingsBatch([FromBody] UpdateSystemSettingsBatchCommand command)
    {
        try
        {
            var result = await _mediator.Send(command);
            return Success("تنظیمات با موفقیت به‌روزرسانی شدند");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در به‌روزرسانی تنظیمات");
        }
    }

    /// <summary>
    /// بازنشانی تنظیمات به حالت پیش‌فرض
    /// </summary>
    /// <param name="category">دسته‌بندی (اختیاری)</param>
    /// <returns>نتیجه بازنشانی</returns>
    [HttpPost("reset")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> ResetSettings([FromQuery] string? category = null)
    {
        try
        {
            var command = new ResetSystemSettingsCommand { Category = category };
            var result = await _mediator.Send(command);
            
            var message = category != null 
                ? $"تنظیمات دسته‌بندی {category} به حالت پیش‌فرض بازنشانی شدند"
                : "تمام تنظیمات به حالت پیش‌فرض بازنشانی شدند";
            return Success(message);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در بازنشانی تنظیمات");
        }
    }

    /// <summary>
    /// دریافت دسته‌بندی‌های تنظیمات
    /// </summary>
    /// <returns>لیست دسته‌بندی‌ها</returns>
    [HttpGet("categories")]
    [ProducesResponseType(typeof(IEnumerable<SystemSettingCategoryDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetSettingCategories()
    {
        try
        {
            var query = new GetSystemSettingCategoriesQuery();
            var categories = await _mediator.Send(query);
            return Success(categories);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت دسته‌بندی‌های تنظیمات");
        }
    }
}
