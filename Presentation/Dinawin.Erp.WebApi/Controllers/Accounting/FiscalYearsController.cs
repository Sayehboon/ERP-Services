using Dinawin.Erp.Application.Features.Accounting.FiscalYears.Queries.GetAllFiscalYears;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;
using Dinawin.Erp.Application.Features.Accounting.FiscalYears.Queries.GetFiscalYearById;
using Dinawin.Erp.Application.Features.Accounting.FiscalYears.Queries.GetActiveFiscalYear;
using Dinawin.Erp.Application.Features.Accounting.FiscalYears.Commands.CreateFiscalYear;
using Dinawin.Erp.Application.Features.Accounting.FiscalYears.Commands.UpdateFiscalYear;
using Dinawin.Erp.Application.Features.Accounting.FiscalYears.Commands.CloseFiscalYear;
using Dinawin.Erp.Application.Features.Accounting.FiscalYears.Commands.DeleteFiscalYear;

namespace Dinawin.Erp.WebApi.Controllers.Accounting;

/// <summary>
/// کنترلر سال‌های مالی
/// </summary>
[Route("api/[controller]")]
public class FiscalYearsController : BaseController
{
    /// <summary>
    /// سازنده کنترلر سال‌های مالی
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public FiscalYearsController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت تمام سال‌های مالی
    /// </summary>
    /// <returns>لیست تمام سال‌های مالی</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<object>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetAllFiscalYears()
    {
        try
        {
            var fiscalYears = await _mediator.Send(new GetAllFiscalYearsQuery());
            return Success(fiscalYears);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت لیست سال‌های مالی");
        }
    }

    /// <summary>
    /// دریافت سال مالی بر اساس شناسه
    /// </summary>
    /// <param name="id">شناسه سال مالی</param>
    /// <returns>اطلاعات سال مالی</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(object), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> GetFiscalYear(Guid id)
    {
        try
        {
            var fy = await _mediator.Send(new GetFiscalYearByIdQuery(id));
            if (fy == null) return NotFound("سال مالی یافت نشد");
            return Success(fy);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت اطلاعات سال مالی");
        }
    }

    /// <summary>
    /// دریافت سال مالی فعال
    /// </summary>
    /// <returns>سال مالی فعال</returns>
    [HttpGet("active")]
    [ProducesResponseType(typeof(object), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> GetActiveFiscalYear()
    {
        try
        {
            var fy = await _mediator.Send(new GetActiveFiscalYearQuery());
            if (fy == null) return NotFound("سال مالی فعالی یافت نشد");
            return Success(fy);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت سال مالی فعال");
        }
    }

    /// <summary>
    /// ایجاد سال مالی جدید
    /// </summary>
    /// <param name="command">دستور ایجاد سال مالی</param>
    /// <returns>شناسه سال مالی ایجاد شده</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> CreateFiscalYear([FromBody] CreateFiscalYearCommand command)
    {
        try
        {
            var fiscalYearId = await _mediator.Send(command);
            return Created(fiscalYearId, "سال مالی با موفقیت ایجاد شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در ایجاد سال مالی");
        }
    }

    /// <summary>
    /// به‌روزرسانی سال مالی
    /// </summary>
    /// <param name="id">شناسه سال مالی</param>
    /// <param name="command">دستور به‌روزرسانی</param>
    /// <returns>نتیجه به‌روزرسانی</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> UpdateFiscalYear(Guid id, [FromBody] UpdateFiscalYearCommand command)
    {
        try
        {
            if (command.Id != id) return BadRequest("شناسه سال مالی مطابقت ندارد");
            var ok = await _mediator.Send(command);
            if (!ok) return NotFound("سال مالی یافت نشد");
            return Success("سال مالی با موفقیت به‌روزرسانی شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در به‌روزرسانی سال مالی");
        }
    }

    /// <summary>
    /// بستن سال مالی
    /// </summary>
    /// <param name="id">شناسه سال مالی</param>
    /// <returns>نتیجه بستن سال مالی</returns>
    [HttpPost("{id}/close")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> CloseFiscalYear(Guid id)
    {
        try
        {
            var ok = await _mediator.Send(new CloseFiscalYearCommand(id));
            if (!ok) return NotFound("سال مالی یافت نشد");
            return Success("سال مالی با موفقیت بسته شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در بستن سال مالی");
        }
    }

    /// <summary>
    /// حذف سال مالی
    /// </summary>
    /// <param name="id">شناسه سال مالی</param>
    /// <returns>نتیجه حذف</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> DeleteFiscalYear(Guid id)
    {
        try
        {
            var ok = await _mediator.Send(new DeleteFiscalYearCommand(id));
            if (!ok) return NotFound("سال مالی یافت نشد");
            return Success("سال مالی با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در حذف سال مالی");
        }
    }
}
