using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;
using Dinawin.Erp.Application.Features.Accounting.JournalEntries.Queries.GetAllJournalEntries;
using Dinawin.Erp.Application.Features.Accounting.JournalEntries.Queries.GetJournalEntryById;
using Dinawin.Erp.Application.Features.Accounting.JournalEntries.Commands.UpdateJournalEntry;
using Dinawin.Erp.Application.Features.Accounting.JournalEntries.Commands.DeleteJournalEntry;

namespace Dinawin.Erp.WebApi.Controllers.Accounting;

/// <summary>
/// کنترلر مدیریت سندهای حسابداری
/// </summary>
[Route("api/[controller]")]
public class JournalEntriesController : BaseController
{
    /// <summary>
    /// سازنده کنترلر سندهای حسابداری
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public JournalEntriesController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت تمام سندهای حسابداری
    /// </summary>
    /// <param name="searchTerm">عبارت جستجو</param>
    /// <param name="accountId">شناسه حساب</param>
    /// <param name="entryType">نوع سند</param>
    /// <param name="fromDate">از تاریخ</param>
    /// <param name="toDate">تا تاریخ</param>
    /// <param name="isApproved">وضعیت تأیید</param>
    /// <param name="referenceType">نوع سند مرجع</param>
    /// <param name="page">شماره صفحه</param>
    /// <param name="pageSize">تعداد آیتم در هر صفحه</param>
    /// <returns>لیست تمام سندهای حسابداری</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<JournalEntryDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetAllJournalEntries(
        [FromQuery] string? searchTerm = null,
        [FromQuery] Guid? accountId = null,
        [FromQuery] string? entryType = null,
        [FromQuery] DateTime? fromDate = null,
        [FromQuery] DateTime? toDate = null,
        [FromQuery] bool? isApproved = null,
        [FromQuery] string? referenceType = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 25)
    {
        try
        {
            var query = new GetAllJournalEntriesQuery
            {
                SearchTerm = searchTerm,
                AccountId = accountId,
                EntryType = entryType,
                FromDate = fromDate,
                ToDate = toDate,
                IsApproved = isApproved,
                ReferenceType = referenceType,
                Page = page,
                PageSize = pageSize
            };

            var entries = await _mediator.Send(query);
            return Success(entries);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت لیست سندهای حسابداری");
        }
    }

    /// <summary>
    /// دریافت سند حسابداری بر اساس شناسه
    /// </summary>
    /// <param name="id">شناسه سند</param>
    /// <returns>اطلاعات سند حسابداری</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(JournalEntryDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> GetJournalEntry(Guid id)
    {
        try
        {
            var query = new GetJournalEntryByIdQuery { Id = id };
            var entry = await _mediator.Send(query);
            
            if (entry == null)
            {
                return NotFound($"سند حسابداری با شناسه {id} یافت نشد");
            }
            
            return Success(entry);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت اطلاعات سند حسابداری");
        }
    }

    /// <summary>
    /// دریافت سندهای حسابداری یک دوره
    /// </summary>
    /// <param name="fromDate">تاریخ شروع</param>
    /// <param name="toDate">تاریخ پایان</param>
    /// <returns>لیست سندهای دوره</returns>
    [HttpGet("by-date-range")]
    [ProducesResponseType(typeof(IEnumerable<JournalEntryDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetJournalEntriesByDateRange([FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
    {
        try
        {
            var query = new GetAllJournalEntriesQuery 
            { 
                FromDate = fromDate, 
                ToDate = toDate 
            };
            var entries = await _mediator.Send(query);
            return Success(entries);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت سندهای دوره");
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
    public async Task<ActionResult> CreateJournalEntry([FromBody] object command)
    {
        try
        {
            // TODO: پیاده‌سازی CreateJournalEntryCommand
            var entryId = Guid.NewGuid();
            return Created(entryId, "سند حسابداری با موفقیت ایجاد شد");
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
    public async Task<ActionResult> UpdateJournalEntry(Guid id, [FromBody] UpdateJournalEntryCommand command)
    {
        try
        {
            command.Id = id;
            var result = await _mediator.Send(command);
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
    public async Task<ActionResult> PostJournalEntry(Guid id)
    {
        try
        {
            // TODO: پیاده‌سازی PostJournalEntryCommand
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
    public async Task<ActionResult> DeleteJournalEntry(Guid id)
    {
        try
        {
            var command = new DeleteJournalEntryCommand { Id = id };
            var result = await _mediator.Send(command);
            return Success("سند حسابداری با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در حذف سند حسابداری");
        }
    }
}
