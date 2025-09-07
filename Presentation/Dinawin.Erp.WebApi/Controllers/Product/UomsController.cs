using Dinawin.Erp.Application.Features.Products.Uoms.Queries.GetAllUoms;
using Dinawin.Erp.Application.Features.Products.Uoms.Commands.UpsertUom;
using Dinawin.Erp.Application.Features.Products.Uoms.Commands.DeleteUom;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;

namespace Dinawin.Erp.WebApi.Controllers.Product;

/// <summary>
/// کنترلر واحدهای اندازه‌گیری
/// </summary>
[Route("api/[controller]")]
public class UomsController : BaseController
{
    /// <summary>
    /// سازنده کنترلر واحدهای اندازه‌گیری
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public UomsController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت تمام واحدهای اندازه‌گیری
    /// </summary>
    /// <param name="type">نوع واحد</param>
    /// <returns>لیست واحدهای اندازه‌گیری</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<object>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetAllUoms([FromQuery] string? type = null)
    {
        try
        {
            var result = await _mediator.Send(new GetAllUomsQuery(type));
            return Success(result);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت لیست واحدهای اندازه‌گیری");
        }
    }

    /// <summary>
    /// دریافت واحد اندازه‌گیری بر اساس شناسه
    /// </summary>
    /// <param name="id">شناسه واحد</param>
    /// <returns>اطلاعات واحد اندازه‌گیری</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(object), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> GetUom(Guid id)
    {
        try
        {
            // TODO: پیاده‌سازی GetUomByIdQuery
            var uom = new { 
                Id = id, 
                Name = "عدد",
                Symbol = "عدد",
                Type = "Count",
                IsActive = true
            };
            return Success(uom);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت اطلاعات واحد اندازه‌گیری");
        }
    }

    /// <summary>
    /// دریافت واحدهای اندازه‌گیری فعال
    /// </summary>
    /// <returns>لیست واحدهای فعال</returns>
    [HttpGet("active")]
    [ProducesResponseType(typeof(IEnumerable<object>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetActiveUoms()
    {
        try
        {
            // TODO: پیاده‌سازی GetActiveUomsQuery
            var uoms = new List<object>
            {
                new { 
                    Id = Guid.NewGuid(), 
                    Name = "عدد",
                    Symbol = "عدد",
                    Type = "Count",
                    IsActive = true
                }
            };
            return Success(uoms);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت واحدهای اندازه‌گیری فعال");
        }
    }

    /// <summary>
    /// ایجاد واحد اندازه‌گیری جدید
    /// </summary>
    /// <param name="command">دستور ایجاد واحد</param>
    /// <returns>شناسه واحد ایجاد شده</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> CreateUom([FromBody] UpsertUomCommand command)
    {
        try
        {
            if (command.Id != null) return BadRequest("برای ایجاد واحد جدید، شناسه نباید مشخص باشد");
            var id = await _mediator.Send(command);
            return Created(id, "واحد اندازه‌گیری با موفقیت ایجاد شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در ایجاد واحد اندازه‌گیری");
        }
    }

    /// <summary>
    /// به‌روزرسانی واحد اندازه‌گیری
    /// </summary>
    /// <param name="id">شناسه واحد</param>
    /// <param name="command">دستور به‌روزرسانی</param>
    /// <returns>نتیجه به‌روزرسانی</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> UpdateUom(Guid id, [FromBody] UpsertUomCommand command)
    {
        try
        {
            if (command.Id != id) return BadRequest("شناسه واحد مطابقت ندارد");
            await _mediator.Send(command);
            return Success("واحد اندازه‌گیری با موفقیت به‌روزرسانی شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در به‌روزرسانی واحد اندازه‌گیری");
        }
    }

    /// <summary>
    /// حذف واحد اندازه‌گیری
    /// </summary>
    /// <param name="id">شناسه واحد</param>
    /// <returns>نتیجه حذف</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> DeleteUom(Guid id)
    {
        try
        {
            var ok = await _mediator.Send(new DeleteUomCommand(id));
            if (!ok) return NotFound("واحد اندازه‌گیری یافت نشد");
            return Success("واحد اندازه‌گیری با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در حذف واحد اندازه‌گیری");
        }
    }
}
