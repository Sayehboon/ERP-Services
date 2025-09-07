using Dinawin.Erp.Application.Features.SalesInvoices.Queries.Dtos;
using Dinawin.Erp.Application.Features.SalesInvoices.Queries.GetAllSalesInvoices;
using Dinawin.Erp.Application.Features.SalesInvoices.Queries.GetSalesInvoiceById;
using Dinawin.Erp.Application.Features.SalesInvoices.Commands.CreateSalesInvoice;
using Dinawin.Erp.Application.Features.SalesInvoices.Commands.PostSalesInvoice;
using Dinawin.Erp.Application.Features.SalesInvoices.Commands.UpdateSalesInvoice;
using Dinawin.Erp.Application.Features.SalesInvoices.Commands.DeleteSalesInvoice;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;

namespace Dinawin.Erp.WebApi.Controllers.Sales;

/// <summary>
/// کنترلر مدیریت فاکتورهای فروش
/// </summary>
[Route("api/[controller]")]
public class SalesInvoicesController : BaseController
{
    /// <summary>
    /// سازنده کنترلر فاکتورهای فروش
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public SalesInvoicesController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت لیست تمام فاکتورهای فروش
    /// </summary>
    /// <param name="customerId">شناسه مشتری</param>
    /// <param name="status">وضعیت فاکتور</param>
    /// <param name="fromDate">از تاریخ</param>
    /// <param name="toDate">تا تاریخ</param>
    /// <param name="page">شماره صفحه</param>
    /// <param name="pageSize">تعداد آیتم در هر صفحه</param>
    /// <returns>لیست فاکتورهای فروش</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<SalesInvoiceDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetAllSalesInvoices(
        [FromQuery] Guid? customerId = null,
        [FromQuery] string? status = null,
        [FromQuery] DateTime? fromDate = null,
        [FromQuery] DateTime? toDate = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 25)
    {
        try
        {
            var result = await _mediator.Send(new GetAllSalesInvoicesQuery(customerId, status, fromDate, toDate, page, pageSize));
            return Success(result);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت لیست فاکتورهای فروش");
        }
    }

    /// <summary>
    /// دریافت فاکتور فروش با شناسه
    /// </summary>
    /// <param name="id">شناسه فاکتور</param>
    /// <returns>اطلاعات فاکتور فروش</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(SalesInvoiceDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> GetSalesInvoice(Guid id)
    {
        try
        {
            var result = await _mediator.Send(new GetSalesInvoiceByIdQuery(id));
            if (result == null) return NotFound($"فاکتور فروش با شناسه {id} پیدا نشد");
            return Success(result);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت اطلاعات فاکتور فروش");
        }
    }

    /// <summary>
    /// ایجاد فاکتور فروش جدید
    /// </summary>
    /// <param name="command">دستور ایجاد فاکتور</param>
    /// <returns>شناسه فاکتور ایجاد شده</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> CreateSalesInvoice([FromBody] CreateSalesInvoiceCommand command)
    {
        try
        {
            var id = await _mediator.Send(command);
            return Created(id, "فاکتور فروش با موفقیت ایجاد شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در ایجاد فاکتور فروش");
        }
    }

    /// <summary>
    /// ویرایش فاکتور فروش
    /// </summary>
    /// <param name="id">شناسه فاکتور</param>
    /// <param name="command">دستور ویرایش</param>
    /// <returns>نتیجه ویرایش</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> UpdateSalesInvoice(Guid id, [FromBody] UpdateSalesInvoiceCommand command)
    {
        try
        {
            if (command.Id != id) return BadRequest("شناسه فاکتور مطابقت ندارد");
            var ok = await _mediator.Send(command);
            if (!ok) return NotFound("فاکتور فروش یافت نشد");
            return Success("فاکتور فروش با موفقیت ویرایش شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در ویرایش فاکتور فروش");
        }
    }

    /// <summary>
    /// ثبت فاکتور فروش در دفتر کل
    /// </summary>
    /// <param name="id">شناسه فاکتور</param>
    /// <returns>نتیجه ثبت</returns>
    [HttpPost("{id}/post")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> PostSalesInvoice(Guid id)
    {
        try
        {
            var ok = await _mediator.Send(new PostSalesInvoiceCommand(id));
            if (!ok) return NotFound("فاکتور فروش یافت نشد");
            return Success("فاکتور فروش با موفقیت ثبت شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در ثبت فاکتور فروش");
        }
    }

    /// <summary>
    /// حذف فاکتور فروش
    /// </summary>
    /// <param name="id">شناسه فاکتور</param>
    /// <returns>نتیجه حذف</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> DeleteSalesInvoice(Guid id)
    {
        try
        {
            var ok = await _mediator.Send(new DeleteSalesInvoiceCommand(id));
            if (!ok) return NotFound("فاکتور فروش یافت نشد");
            return Success("فاکتور فروش با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در حذف فاکتور فروش");
        }
    }
}
