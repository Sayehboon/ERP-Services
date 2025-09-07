using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;
using Dinawin.Erp.Application.Features.Product.Units.Queries.GetAllUnits;
using Dinawin.Erp.Application.Features.Product.Units.Queries.GetUnitById;
using Dinawin.Erp.Application.Features.Product.Units.Commands.CreateUnit;
using Dinawin.Erp.Application.Features.Product.Units.Commands.UpdateUnit;
using Dinawin.Erp.Application.Features.Product.Units.Commands.DeleteUnit;

namespace Dinawin.Erp.WebApi.Controllers.Product;

/// <summary>
/// کنترلر مدیریت واحدها
/// </summary>
[Route("api/[controller]")]
public class UnitsController : BaseController
{
    /// <summary>
    /// سازنده کنترلر واحدها
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public UnitsController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت تمام واحدها
    /// </summary>
    /// <param name="searchTerm">عبارت جستجو</param>
    /// <param name="isActive">آیا فقط واحدهای فعال</param>
    /// <param name="page">شماره صفحه</param>
    /// <param name="pageSize">اندازه صفحه</param>
    /// <returns>لیست تمام واحدها</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<UnitDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetAllUnits(
        [FromQuery] string? searchTerm = null,
        [FromQuery] bool? isActive = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 25)
    {
        try
        {
            var query = new GetAllUnitsQuery
            {
                SearchTerm = searchTerm,
                IsActive = isActive,
                Page = page,
                PageSize = pageSize
            };

            var units = await _mediator.Send(query);
            return Success(units);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت لیست واحدها");
        }
    }

    /// <summary>
    /// دریافت واحد بر اساس شناسه
    /// </summary>
    /// <param name="id">شناسه واحد</param>
    /// <returns>اطلاعات واحد</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(UnitDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> GetUnit(Guid id)
    {
        try
        {
            var query = new GetUnitByIdQuery { Id = id };
            var unit = await _mediator.Send(query);
            
            if (unit == null)
            {
                return NotFound($"واحد با شناسه {id} یافت نشد");
            }
            
            return Success(unit);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت اطلاعات واحد");
        }
    }

    /// <summary>
    /// دریافت واحدهای فعال
    /// </summary>
    /// <returns>لیست واحدهای فعال</returns>
    [HttpGet("active")]
    [ProducesResponseType(typeof(IEnumerable<UnitDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetActiveUnits()
    {
        try
        {
            var query = new GetAllUnitsQuery { IsActive = true };
            var units = await _mediator.Send(query);
            return Success(units);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت واحدهای فعال");
        }
    }

    /// <summary>
    /// ایجاد واحد جدید
    /// </summary>
    /// <param name="command">دستور ایجاد واحد</param>
    /// <returns>شناسه واحد ایجاد شده</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> CreateUnit([FromBody] CreateUnitCommand command)
    {
        try
        {
            var unitId = await _mediator.Send(command);
            return Created(unitId, "واحد با موفقیت ایجاد شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در ایجاد واحد");
        }
    }

    /// <summary>
    /// به‌روزرسانی واحد
    /// </summary>
    /// <param name="id">شناسه واحد</param>
    /// <param name="command">دستور به‌روزرسانی</param>
    /// <returns>نتیجه به‌روزرسانی</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> UpdateUnit(Guid id, [FromBody] UpdateUnitCommand command)
    {
        try
        {
            command.Id = id;
            await _mediator.Send(command);
            return Success("واحد با موفقیت به‌روزرسانی شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در به‌روزرسانی واحد");
        }
    }

    /// <summary>
    /// حذف واحد
    /// </summary>
    /// <param name="id">شناسه واحد</param>
    /// <returns>نتیجه حذف</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> DeleteUnit(Guid id)
    {
        try
        {
            var command = new DeleteUnitCommand { Id = id };
            await _mediator.Send(command);
            return Success("واحد با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در حذف واحد");
        }
    }
}
