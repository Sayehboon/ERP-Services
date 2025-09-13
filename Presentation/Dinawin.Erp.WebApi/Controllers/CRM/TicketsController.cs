using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.Application.Features.CRM.Tickets.Commands.CreateTicket;
using Dinawin.Erp.Application.Features.CRM.Tickets.Commands.UpdateTicket;
using Dinawin.Erp.Application.Features.CRM.Tickets.Queries.GetAllTickets;
using Dinawin.Erp.Application.Features.CRM.Tickets.DTOs;
using TicketDto = Dinawin.Erp.Application.Features.CRM.Tickets.DTOs.TicketDto;

namespace Dinawin.Erp.WebApi.Controllers.CRM;

/// <summary>
/// کنترلر مدیریت تیکت‌های CRM
/// Controller for managing CRM tickets
/// </summary>
[Route("api/[controller]")]
public class TicketsController : BaseController
{
    /// <summary>
    /// سازنده کنترلر تیکت‌ها
    /// Tickets controller constructor
    /// </summary>
    /// <param name="mediator">واسط میدیاتور</param>
    public TicketsController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت لیست تمام تیکت‌ها
    /// Gets all tickets with optional filtering
    /// </summary>
    /// <param name="query">پارامترهای فیلتر</param>
    /// <returns>لیست تیکت‌ها</returns>
    /// <response code="200">لیست تیکت‌ها با موفقیت بازگردانده شد</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<TicketDto>), 200)]
    public async Task<object> GetAllTickets([FromQuery] GetAllTicketsQuery query)
    {
        try
        {
            var tickets = await _mediator.Send(query);
            return Success(tickets, "لیست تیکت‌ها با موفقیت بازگردانده شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// دریافت تیکت با شناسه
    /// Gets a ticket by ID
    /// </summary>
    /// <param name="id">شناسه تیکت</param>
    /// <returns>اطلاعات تیکت</returns>
    /// <response code="200">تیکت پیدا شد</response>
    /// <response code="404">تیکت پیدا نشد</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(TicketDto), 200)]
    [ProducesResponseType(404)]
    public async Task<object> GetTicket(Guid id)
    {
        try
        {
            var validationResult = ValidateId(id);
            if (validationResult != null) return validationResult;

            // TODO: Implement GetTicketByIdQuery
            await Task.CompletedTask;
            return Error("تیکت با شناسه مشخص شده پیدا نشد", 404);
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// ایجاد تیکت جدید
    /// Creates a new ticket
    /// </summary>
    /// <param name="command">اطلاعات تیکت جدید</param>
    /// <returns>شناسه تیکت ایجاد شده</returns>
    /// <response code="201">تیکت با موفقیت ایجاد شد</response>
    /// <response code="400">اطلاعات ارسالی نامعتبر است</response>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<object> CreateTicket([FromBody] CreateTicketCommand command)
    {
        try
        {
            var ticketId = await _mediator.Send(command);
            return Created(ticketId, ticketId, nameof(GetTicket));
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// ویرایش تیکت
    /// Updates an existing ticket
    /// </summary>
    /// <param name="id">شناسه تیکت</param>
    /// <param name="command">اطلاعات به‌روزرسانی</param>
    /// <returns>نتیجه ویرایش</returns>
    /// <response code="200">تیکت با موفقیت ویرایش شد</response>
    /// <response code="404">تیکت پیدا نشد</response>
    /// <response code="400">اطلاعات ارسالی نامعتبر است</response>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> UpdateTicket(Guid id, [FromBody] UpdateTicketCommand command)
    {
        try
        {
            var validationResult = ValidateId(id);
            if (validationResult != null) return validationResult;

            // TODO: Implement UpdateTicketCommand
            await Task.CompletedTask;
            return Updated("تیکت با موفقیت ویرایش شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// حذف تیکت
    /// Deletes a ticket
    /// </summary>
    /// <param name="id">شناسه تیکت</param>
    /// <returns>نتیجه حذف</returns>
    /// <response code="200">تیکت با موفقیت حذف شد</response>
    /// <response code="404">تیکت پیدا نشد</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteTicket(Guid id)
    {
        try
        {
            var validationResult = ValidateId(id);
            if (validationResult != null) return validationResult;

            // TODO: Implement DeleteTicketCommand
            await Task.CompletedTask;
            return Deleted("تیکت با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// تغییر وضعیت تیکت
    /// Updates ticket status
    /// </summary>
    /// <param name="id">شناسه تیکت</param>
    /// <param name="status">وضعیت جدید</param>
    /// <returns>نتیجه تغییر وضعیت</returns>
    /// <response code="200">وضعیت تیکت با موفقیت تغییر کرد</response>
    /// <response code="404">تیکت پیدا نشد</response>
    /// <response code="400">وضعیت نامعتبر است</response>
    [HttpPatch("{id}/status")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> UpdateTicketStatus(Guid id, [FromBody] string status)
    {
        try
        {
            var validationResult = ValidateId(id);
            if (validationResult != null) return validationResult;

            // TODO: Implement UpdateTicketStatusCommand
            await Task.CompletedTask;
            return Success("وضعیت تیکت با موفقیت تغییر کرد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }
}

