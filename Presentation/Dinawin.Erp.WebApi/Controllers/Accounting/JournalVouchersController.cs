using Dinawin.Erp.Application.Features.Accounting.JournalVouchers.Queries.GetAllJournalVouchers;
using Dinawin.Erp.Application.Features.Accounting.JournalVouchers.Queries.Dtos;
using Dinawin.Erp.Application.Features.Accounting.JournalVouchers.Commands.CreateJournalVoucher;
using Dinawin.Erp.Application.Features.Accounting.JournalVouchers.Commands.UpdateJournalVoucher;
using Dinawin.Erp.Application.Features.Accounting.JournalVouchers.Commands.PostJournalVoucher;
using Dinawin.Erp.Application.Features.Accounting.JournalVouchers.Commands.DeleteJournalVoucher;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;

namespace Dinawin.Erp.WebApi.Controllers.Accounting;

/// <summary>
/// کنترلر اسناد حسابداری
/// </summary>
[Route("api/[controller]")]
public class JournalVouchersController : BaseController
{
    /// <summary>
    /// سازنده کنترلر اسناد حسابداری
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public JournalVouchersController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت تمام اسناد حسابداری
    /// </summary>
    /// <param name="status">وضعیت سند</param>
    /// <param name="type">نوع سند</param>
    /// <param name="number">شماره سند</param>
    /// <param name="fromDate">تاریخ شروع</param>
    /// <param name="toDate">تاریخ پایان</param>
    /// <param name="sortBy">مرتب‌سازی بر اساس</param>
    /// <returns>لیست اسناد حسابداری</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<JournalVoucherDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetAllJournalVouchers(
        [FromQuery] string? status = null,
        [FromQuery] string? type = null,
        [FromQuery] string? number = null,
        [FromQuery] DateTime? fromDate = null,
        [FromQuery] DateTime? toDate = null,
        [FromQuery] string? sortBy = "seq_no")
    {
        try
        {
            // TODO: پیاده‌سازی GetAllJournalVouchersQuery
            var result = await _mediator.Send(new GetAllJournalVouchersQuery(status, type, number, fromDate, toDate, sortBy));
            return Success(result);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت لیست اسناد حسابداری");
        }
    }

    /// <summary>
    /// دریافت سند حسابداری بر اساس شناسه
    /// </summary>
    /// <param name="id">شناسه سند</param>
    /// <returns>اطلاعات سند حسابداری</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(JournalVoucherDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> GetJournalVoucher(Guid id)
    {
        try
        {
            // TODO: پیاده‌سازی GetJournalVoucherByIdQuery
            var voucher = new { 
                Id = id, 
                VoucherNumber = "JV001",
                VoucherDate = DateTime.Now,
                Description = "سند حسابداری"
            };
            return Success(voucher);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت اطلاعات سند حسابداری");
        }
    }

    /// <summary>
    /// ایجاد سند حسابداری جدید
    /// </summary>
    /// <param name="command">دستور ایجاد سند</param>
    /// <returns>شناسه سند ایجاد شده</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> CreateJournalVoucher([FromBody] CreateJournalVoucherCommand command)
    {
        try
        {
            var id = await _mediator.Send(command);
            return Created(id, "سند حسابداری با موفقیت ایجاد شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در ایجاد سند حسابداری");
        }
    }

    /// <summary>
    /// به‌روزرسانی سند حسابداری
    /// </summary>
    /// <param name="id">شناسه سند</param>
    /// <param name="command">دستور به‌روزرسانی</param>
    /// <returns>نتیجه به‌روزرسانی</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> UpdateJournalVoucher(Guid id, [FromBody] UpdateJournalVoucherCommand command)
    {
        try
        {
            if (command.Id != id) return BadRequest("شناسه سند مطابقت ندارد");
            var ok = await _mediator.Send(command);
            if (!ok) return NotFound("سند حسابداری یافت نشد");
            return Success("سند حسابداری با موفقیت به‌روزرسانی شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در به‌روزرسانی سند حسابداری");
        }
    }

    /// <summary>
    /// تایید سند حسابداری
    /// </summary>
    /// <param name="id">شناسه سند</param>
    /// <returns>نتیجه تایید</returns>
    [HttpPost("{id}/post")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> PostJournalVoucher(Guid id)
    {
        try
        {
            var ok = await _mediator.Send(new PostJournalVoucherCommand(id));
            if (!ok) return NotFound("سند حسابداری یافت نشد");
            return Success("سند حسابداری با موفقیت تایید شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در تایید سند حسابداری");
        }
    }

    /// <summary>
    /// حذف سند حسابداری
    /// </summary>
    /// <param name="id">شناسه سند</param>
    /// <returns>نتیجه حذف</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> DeleteJournalVoucher(Guid id)
    {
        try
        {
            var ok = await _mediator.Send(new DeleteJournalVoucherCommand(id));
            if (!ok) return NotFound("سند حسابداری یافت نشد");
            return Success("سند حسابداری با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در حذف سند حسابداری");
        }
    }
}
