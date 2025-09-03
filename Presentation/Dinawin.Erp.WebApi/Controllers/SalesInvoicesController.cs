using Dinawin.Erp.Application.Features.SalesInvoices.Queries.Dtos;
using Dinawin.Erp.Application.Features.SalesInvoices.Queries.GetAllSalesInvoices;
using Dinawin.Erp.Application.Features.SalesInvoices.Queries.GetSalesInvoiceById;
using Dinawin.Erp.Application.Features.SalesInvoices.Commands.CreateSalesInvoice;
using Dinawin.Erp.Application.Features.SalesInvoices.Commands.PostSalesInvoice;
using Dinawin.Erp.Application.Features.SalesInvoices.Commands.UpdateSalesInvoice;
using Dinawin.Erp.Application.Features.SalesInvoices.Commands.DeleteSalesInvoice;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dinawin.Erp.WebApi.Controllers;

/// <summary>
/// کنترلر مدیریت فاکتورهای فروش
/// Controller for managing sales invoices
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class SalesInvoicesController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// سازنده کنترلر فاکتورهای فروش
    /// Sales invoices controller constructor
    /// </summary>
    /// <param name="mediator">واسط میدیاتور</param>
    public SalesInvoicesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// دریافت لیست تمام فاکتورهای فروش
    /// Gets all sales invoices with optional filtering
    /// </summary>
    /// <param name="customerId">شناسه مشتری</param>
    /// <param name="status">وضعیت فاکتور</param>
    /// <param name="fromDate">از تاریخ</param>
    /// <param name="toDate">تا تاریخ</param>
    /// <param name="page">شماره صفحه</param>
    /// <param name="pageSize">تعداد آیتم در هر صفحه</param>
    /// <returns>لیست فاکتورهای فروش</returns>
    /// <response code="200">لیست فاکتورهای فروش با موفقیت بازگردانده شد</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<SalesInvoiceDto>), 200)]
    public async Task<ActionResult<IEnumerable<SalesInvoiceDto>>> GetAllSalesInvoices(
        [FromQuery] Guid? customerId = null,
        [FromQuery] string? status = null,
        [FromQuery] DateTime? fromDate = null,
        [FromQuery] DateTime? toDate = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 25)
    {
        var result = await _mediator.Send(new GetAllSalesInvoicesQuery(customerId, status, fromDate, toDate, page, pageSize));
        return Ok(result);
    }

    /// <summary>
    /// دریافت فاکتور فروش با شناسه
    /// Gets a sales invoice by ID
    /// </summary>
    /// <param name="id">شناسه فاکتور</param>
    /// <returns>اطلاعات فاکتور فروش</returns>
    /// <response code="200">فاکتور پیدا شد</response>
    /// <response code="404">فاکتور پیدا نشد</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(SalesInvoiceDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<SalesInvoiceDto>> GetSalesInvoice(Guid id)
    {
        var result = await _mediator.Send(new GetSalesInvoiceByIdQuery(id));
        if (result == null) return NotFound($"فاکتور فروش با شناسه {id} پیدا نشد");
        return Ok(result);
    }

    /// <summary>
    /// ایجاد فاکتور فروش جدید
    /// Creates a new sales invoice
    /// </summary>
    /// <returns>شناسه فاکتور ایجاد شده</returns>
    /// <response code="201">فاکتور با موفقیت ایجاد شد</response>
    /// <response code="400">اطلاعات ارسالی نامعتبر است</response>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Guid>> CreateSalesInvoice([FromBody] CreateSalesInvoiceCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetSalesInvoice), new { id }, id);
    }

    /// <summary>
    /// ویرایش فاکتور فروش
    /// Updates an existing sales invoice
    /// </summary>
    /// <param name="id">شناسه فاکتور</param>
    /// <returns>نتیجه ویرایش</returns>
    /// <response code="200">فاکتور با موفقیت ویرایش شد</response>
    /// <response code="404">فاکتور پیدا نشد</response>
    /// <response code="400">اطلاعات ارسالی نامعتبر است</response>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> UpdateSalesInvoice(Guid id, [FromBody] UpdateSalesInvoiceCommand command)
    {
        if (command.Id != id) return BadRequest();
        var ok = await _mediator.Send(command);
        if (!ok) return NotFound();
        return Ok(new { message = "فاکتور فروش با موفقیت ویرایش شد" });
    }

    /// <summary>
    /// ثبت فاکتور فروش در دفتر کل
    /// Posts a sales invoice to general ledger
    /// </summary>
    /// <param name="id">شناسه فاکتور</param>
    /// <returns>نتیجه ثبت</returns>
    /// <response code="200">فاکتور با موفقیت ثبت شد</response>
    /// <response code="404">فاکتور پیدا نشد</response>
    /// <response code="400">فاکتور قابل ثبت نیست</response>
    [HttpPost("{id}/post")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> PostSalesInvoice(Guid id)
    {
        try
        {
            var ok = await _mediator.Send(new PostSalesInvoiceCommand(id));
            if (!ok) return NotFound();
            return Ok(new { message = "فاکتور فروش با موفقیت ثبت شد" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "خطا در ثبت فاکتور فروش", error = ex.Message });
        }
    }

    /// <summary>
    /// حذف فاکتور فروش
    /// Deletes a sales invoice
    /// </summary>
    /// <param name="id">شناسه فاکتور</param>
    /// <returns>نتیجه حذف</returns>
    /// <response code="204">فاکتور با موفقیت حذف شد</response>
    /// <response code="404">فاکتور پیدا نشد</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteSalesInvoice(Guid id)
    {
        var ok = await _mediator.Send(new DeleteSalesInvoiceCommand(id));
        if (!ok) return NotFound();
        return NoContent();
    }
}
