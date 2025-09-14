using Dinawin.Erp.Application.Features.Accounting.FiscalPeriods.Queries.GetPeriodsByYear;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;
using Dinawin.Erp.Application.Features.Accounting.FiscalPeriods.Queries.GetFiscalPeriodById;
using Dinawin.Erp.Application.Features.Accounting.FiscalPeriods.Queries.GetActiveFiscalPeriod;
using Dinawin.Erp.Application.Features.Accounting.FiscalPeriods.Commands.CreateFiscalPeriod;
using Dinawin.Erp.Application.Features.Accounting.FiscalPeriods.Commands.UpdateFiscalPeriod;
using Dinawin.Erp.Application.Features.Accounting.FiscalPeriods.Commands.DeleteFiscalPeriod;
using Dinawin.Erp.Application.Features.Accounting.FiscalPeriods.Queries.GetAllFiscalPeriods;

namespace Dinawin.Erp.WebApi.Controllers.Accounting;

/// <summary>
/// کنترلر دوره‌های مالی
/// </summary>
[Route("api/[controller]")]
public class FiscalPeriodsController : BaseController
{
    /// <summary>
    /// سازنده کنترلر دوره‌های مالی
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public FiscalPeriodsController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت تمام دوره‌های مالی
    /// </summary>
    /// <returns>لیست تمام دوره‌های مالی</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<object>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<IReadOnlyList<FiscalPeriodDto>>> GetAllFiscalPeriods()
    {
        try
        {
            var periods = await _mediator.Send(new GetAllFiscalPeriodsQuery());
            return Success(periods);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت لیست دوره‌های مالی");
        }
    }

    /// <summary>
    /// دریافت دوره مالی بر اساس شناسه
    /// </summary>
    /// <param name="id">شناسه دوره مالی</param>
    /// <returns>اطلاعات دوره مالی</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(object), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<FiscalPeriodDto>> GetFiscalPeriod(Guid id)
    {
        try
        {
            var period = await _mediator.Send(new GetFiscalPeriodByIdQuery(id));
            if (period == null) return NotFound("دوره مالی یافت نشد");
            return Success(period);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت اطلاعات دوره مالی");
        }
    }

    /// <summary>
    /// لیست دوره‌های یک سال مالی
    /// </summary>
    /// <param name="fiscalYearId">شناسه سال مالی</param>
    /// <returns>لیست دوره‌های سال مالی</returns>
    [HttpGet("by-year/{fiscalYearId}")]
    [ProducesResponseType(typeof(IEnumerable<object>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<IReadOnlyList<FiscalPeriodDto>>> GetByYear(Guid fiscalYearId)
    {
        try
        {
            var result = await _mediator.Send(new GetPeriodsByYearQuery(fiscalYearId));
            return Success(result);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت دوره‌های سال مالی");
        }
    }

    /// <summary>
    /// دریافت دوره مالی فعال
    /// </summary>
    /// <returns>دوره مالی فعال</returns>
    [HttpGet("active")]
    [ProducesResponseType(typeof(object), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<FiscalPeriodDto>> GetActiveFiscalPeriod([FromQuery] Guid fiscalYearId)
    {
        try
        {
            var period = await _mediator.Send(new GetActiveFiscalPeriodQuery(fiscalYearId));
            if (period == null) return NotFound("دوره مالی فعالی یافت نشد");
            return Success(period);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت دوره مالی فعال");
        }
    }

    /// <summary>
    /// ایجاد دوره مالی جدید
    /// </summary>
    /// <param name="command">دستور ایجاد دوره مالی</param>
    /// <returns>شناسه دوره مالی ایجاد شده</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Guid>> CreateFiscalPeriod([FromBody] CreateFiscalPeriodCommand command)
    {
        try
        {
            var periodId = await _mediator.Send(command);
            return Created(periodId, "دوره مالی با موفقیت ایجاد شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در ایجاد دوره مالی");
        }
    }

    /// <summary>
    /// به‌روزرسانی دوره مالی
    /// </summary>
    /// <param name="id">شناسه دوره مالی</param>
    /// <param name="command">دستور به‌روزرسانی</param>
    /// <returns>نتیجه به‌روزرسانی</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> UpdateFiscalPeriod(Guid id, [FromBody] UpdateFiscalPeriodCommand command)
    {
        try
        {
            if (command.Id != id) return BadRequest("شناسه دوره مالی مطابقت ندارد");
            var ok = await _mediator.Send(command);
            if (!ok) return NotFound("دوره مالی یافت نشد");
            return Success("دوره مالی با موفقیت به‌روزرسانی شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در به‌روزرسانی دوره مالی");
        }
    }

    /// <summary>
    /// حذف دوره مالی
    /// </summary>
    /// <param name="id">شناسه دوره مالی</param>
    /// <returns>نتیجه حذف</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> DeleteFiscalPeriod(Guid id)
    {
        try
        {
            var ok = await _mediator.Send(new DeleteFiscalPeriodCommand(id));
            if (!ok) return NotFound("دوره مالی یافت نشد");
            return Success("دوره مالی با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در حذف دوره مالی");
        }
    }
}
