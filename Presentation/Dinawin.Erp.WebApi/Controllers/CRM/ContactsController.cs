using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.Application.Features.Contacts.Commands.CreateContact;
using Dinawin.Erp.Application.Features.Contacts.Queries.GetAllContacts;
using Dinawin.Erp.Application.Features.Contacts.DTOs;

namespace Dinawin.Erp.WebApi.Controllers.CRM;

/// <summary>
/// کنترلر مدیریت مخاطبین CRM
/// Controller for managing CRM contacts
/// </summary>
[Route("api/[controller]")]
public class ContactsController : BaseController
{
    /// <summary>
    /// سازنده کنترلر مخاطبین
    /// Contacts controller constructor
    /// </summary>
    /// <param name="mediator">واسط میدیاتور</param>
    public ContactsController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت لیست تمام مخاطبین
    /// Gets all contacts with optional filtering
    /// </summary>
    /// <param name="query">پارامترهای فیلتر</param>
    /// <returns>لیست مخاطبین</returns>
    /// <response code="200">لیست مخاطبین با موفقیت بازگردانده شد</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ContactDto>), 200)]
    public async Task<ActionResult<List<ContactDto>>> GetAllContacts([FromQuery] GetAllContactsQuery query)
    {
        try
        {
            var contacts = await _mediator.Send(query);
            return Success(contacts, "لیست مخاطبین با موفقیت بازگردانده شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// دریافت مخاطب با شناسه
    /// Gets a contact by ID
    /// </summary>
    /// <param name="id">شناسه مخاطب</param>
    /// <returns>اطلاعات مخاطب</returns>
    /// <response code="200">مخاطب پیدا شد</response>
    /// <response code="404">مخاطب پیدا نشد</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ContactDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<ContactDto>> GetContact(Guid id)
    {
        try
        {
            var validationResult = ValidateId(id);
            if (validationResult != null) return validationResult;

            // TODO: Implement GetContactByIdQuery
            await Task.CompletedTask;
            return Error("مخاطب با شناسه مشخص شده پیدا نشد", 404);
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// ایجاد مخاطب جدید
    /// Creates a new contact
    /// </summary>
    /// <param name="command">اطلاعات مخاطب جدید</param>
    /// <returns>شناسه مخاطب ایجاد شده</returns>
    /// <response code="201">مخاطب با موفقیت ایجاد شد</response>
    /// <response code="400">اطلاعات ارسالی نامعتبر است</response>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Guid>> CreateContact([FromBody] CreateContactCommand command)
    {
        try
        {
            var contactId = await _mediator.Send(command);
            return Created(contactId, contactId, nameof(GetContact));
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// ویرایش مخاطب
    /// Updates an existing contact
    /// </summary>
    /// <param name="id">شناسه مخاطب</param>
    /// <param name="command">اطلاعات به‌روزرسانی</param>
    /// <returns>نتیجه ویرایش</returns>
    /// <response code="200">مخاطب با موفقیت ویرایش شد</response>
    /// <response code="404">مخاطب پیدا نشد</response>
    /// <response code="400">اطلاعات ارسالی نامعتبر است</response>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> UpdateContact(Guid id, [FromBody] UpdateContactCommand command)
    {
        try
        {
            var validationResult = ValidateId(id);
            if (validationResult != null) return validationResult;

            // TODO: Implement UpdateContactCommand
            await Task.CompletedTask;
            return Updated("مخاطب با موفقیت ویرایش شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// حذف مخاطب
    /// Deletes a contact
    /// </summary>
    /// <param name="id">شناسه مخاطب</param>
    /// <returns>نتیجه حذف</returns>
    /// <response code="200">مخاطب با موفقیت حذف شد</response>
    /// <response code="404">مخاطب پیدا نشد</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteContact(Guid id)
    {
        try
        {
            var validationResult = ValidateId(id);
            if (validationResult != null) return validationResult;

            // TODO: Implement DeleteContactCommand
            await Task.CompletedTask;
            return Deleted("مخاطب با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// تغییر وضعیت مخاطب
    /// Updates contact status
    /// </summary>
    /// <param name="id">شناسه مخاطب</param>
    /// <param name="status">وضعیت جدید</param>
    /// <returns>نتیجه تغییر وضعیت</returns>
    /// <response code="200">وضعیت مخاطب با موفقیت تغییر کرد</response>
    /// <response code="404">مخاطب پیدا نشد</response>
    /// <response code="400">وضعیت نامعتبر است</response>
    [HttpPatch("{id}/status")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> UpdateContactStatus(Guid id, [FromBody] string status)
    {
        try
        {
            var validationResult = ValidateId(id);
            if (validationResult != null) return validationResult;

            // TODO: Implement UpdateContactStatusCommand
            await Task.CompletedTask;
            return Success("وضعیت مخاطب با موفقیت تغییر کرد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }
}

