using Dinawin.Erp.Application.Features.Products.Uoms.Conversions.Queries.GetConversions;
using Dinawin.Erp.Application.Features.Products.Uoms.Conversions.Commands.UpsertUomConversion;
using Dinawin.Erp.Application.Features.Products.Uoms.Conversions.Commands.DeleteUomConversion;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;

namespace Dinawin.Erp.WebApi.Controllers.Product;

/// <summary>
/// کنترلر تبدیلات واحدهای اندازه‌گیری
/// </summary>
[Route("api/[controller]")]
public class UomConversionsController : BaseController
{
    /// <summary>
    /// سازنده کنترلر تبدیلات واحدهای اندازه‌گیری
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public UomConversionsController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت تمام تبدیلات واحدهای اندازه‌گیری
    /// </summary>
    /// <returns>لیست تبدیلات واحدها</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<object>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetAllUomConversions()
    {
        try
        {
            var result = await _mediator.Send(new GetUomConversionsQuery());
            return Success(result);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت لیست تبدیلات واحدهای اندازه‌گیری");
        }
    }

    /// <summary>
    /// دریافت تبدیل واحد بر اساس شناسه
    /// </summary>
    /// <param name="id">شناسه تبدیل</param>
    /// <returns>اطلاعات تبدیل واحد</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(object), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> GetUomConversion(Guid id)
    {
        try
        {
            // TODO: پیاده‌سازی GetUomConversionByIdQuery
            var conversion = new { 
                Id = id, 
                FromUomId = Guid.NewGuid(),
                FromUomName = "کیلوگرم",
                ToUomId = Guid.NewGuid(),
                ToUomName = "گرم",
                ConversionFactor = 1000
            };
            return Success(conversion);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت اطلاعات تبدیل واحد");
        }
    }

    /// <summary>
    /// دریافت تبدیلات یک واحد
    /// </summary>
    /// <param name="uomId">شناسه واحد</param>
    /// <returns>لیست تبدیلات واحد</returns>
    [HttpGet("by-uom/{uomId}")]
    [ProducesResponseType(typeof(IEnumerable<object>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetConversionsByUom(Guid uomId)
    {
        try
        {
            // TODO: پیاده‌سازی GetConversionsByUomQuery
            var conversions = new List<object>
            {
                new { 
                    Id = Guid.NewGuid(), 
                    FromUomId = uomId,
                    FromUomName = "کیلوگرم",
                    ToUomId = Guid.NewGuid(),
                    ToUomName = "گرم",
                    ConversionFactor = 1000
                }
            };
            return Success(conversions);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت تبدیلات واحد");
        }
    }

    /// <summary>
    /// ایجاد تبدیل واحد جدید
    /// </summary>
    /// <param name="command">دستور ایجاد تبدیل</param>
    /// <returns>شناسه تبدیل ایجاد شده</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> CreateUomConversion([FromBody] UpsertUomConversionCommand command)
    {
        try
        {
            if (command.Id != null) return BadRequest("برای ایجاد تبدیل جدید، شناسه نباید مشخص باشد");
            var id = await _mediator.Send(command);
            return Created(id, "تبدیل واحد با موفقیت ایجاد شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در ایجاد تبدیل واحد");
        }
    }

    /// <summary>
    /// به‌روزرسانی تبدیل واحد
    /// </summary>
    /// <param name="id">شناسه تبدیل</param>
    /// <param name="command">دستور به‌روزرسانی</param>
    /// <returns>نتیجه به‌روزرسانی</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> UpdateUomConversion(Guid id, [FromBody] UpsertUomConversionCommand command)
    {
        try
        {
            if (command.Id != id) return BadRequest("شناسه تبدیل مطابقت ندارد");
            await _mediator.Send(command);
            return Success("تبدیل واحد با موفقیت به‌روزرسانی شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در به‌روزرسانی تبدیل واحد");
        }
    }

    /// <summary>
    /// حذف تبدیل واحد
    /// </summary>
    /// <param name="id">شناسه تبدیل</param>
    /// <returns>نتیجه حذف</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> DeleteUomConversion(Guid id)
    {
        try
        {
            var ok = await _mediator.Send(new DeleteUomConversionCommand(id));
            if (!ok) return NotFound("تبدیل واحد یافت نشد");
            return Success("تبدیل واحد با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در حذف تبدیل واحد");
        }
    }
}
