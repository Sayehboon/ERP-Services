using Dinawin.Erp.Application.Features.CRM.Leads.Commands.CreateLead;
using Dinawin.Erp.Application.Features.CRM.Leads.Commands.UpdateLead;
using Dinawin.Erp.Application.Features.CRM.Leads.Queries.GetAllLeads;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dinawin.Erp.WebApi.Controllers.CRM;

/// <summary>
/// کنترلر مدیریت سرنخ‌های CRM
/// Controller for managing CRM leads
/// </summary>
[Route("api/[controller]")]
public class LeadsController : BaseController
{
    /// <summary>
    /// سازنده کنترلر سرنخ‌ها
    /// Leads controller constructor
    /// </summary>
    /// <param name="mediator">واسط میدیاتور</param>
    public LeadsController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت لیست تمام سرنخ‌ها
    /// Gets all leads with optional filtering
    /// </summary>
    /// <param name="query">پارامترهای فیلتر</param>
    /// <returns>لیست سرنخ‌ها</returns>
    /// <response code="200">لیست سرنخ‌ها با موفقیت بازگردانده شد</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<LeadDto>), 200)]
    public async Task<ActionResult<List<LeadDto>>> GetAllLeads([FromQuery] GetAllLeadsQuery query)
    {
        try
        {
            var leads = await _mediator.Send(query);
            return Success(leads, "لیست سرنخ‌ها با موفقیت بازگردانده شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// دریافت سرنخ با شناسه
    /// Gets a lead by ID
    /// </summary>
    /// <param name="id">شناسه سرنخ</param>
    /// <returns>اطلاعات سرنخ</returns>
    /// <response code="200">سرنخ پیدا شد</response>
    /// <response code="404">سرنخ پیدا نشد</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(LeadDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<LeadDto>> GetLead(Guid id)
    {
        try
        {
            var validationResult = ValidateId(id);
            if (validationResult != null) return validationResult;

            // TODO: Implement GetLeadByIdQuery
            await Task.CompletedTask;
            return Error("سرنخ با شناسه مشخص شده پیدا نشد", 404);
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// ایجاد سرنخ جدید
    /// Creates a new lead
    /// </summary>
    /// <param name="command">اطلاعات سرنخ جدید</param>
    /// <returns>شناسه سرنخ ایجاد شده</returns>
    /// <response code="201">سرنخ با موفقیت ایجاد شد</response>
    /// <response code="400">اطلاعات ارسالی نامعتبر است</response>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Guid>> CreateLead([FromBody] CreateLeadCommand command)
    {
        try
        {
            var leadId = await _mediator.Send(command);
            return Created(leadId, leadId, nameof(GetLead));
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// ویرایش سرنخ
    /// Updates an existing lead
    /// </summary>
    /// <param name="id">شناسه سرنخ</param>
    /// <param name="command">اطلاعات به‌روزرسانی</param>
    /// <returns>نتیجه ویرایش</returns>
    /// <response code="200">سرنخ با موفقیت ویرایش شد</response>
    /// <response code="404">سرنخ پیدا نشد</response>
    /// <response code="400">اطلاعات ارسالی نامعتبر است</response>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> UpdateLead(Guid id, [FromBody] UpdateLeadCommand command)
    {
        try
        {
            var validationResult = ValidateId(id);
            if (validationResult != null) return validationResult;

            // TODO: Implement UpdateLeadCommand
            await Task.CompletedTask;
            return Updated("سرنخ با موفقیت ویرایش شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// حذف سرنخ
    /// Deletes a lead
    /// </summary>
    /// <param name="id">شناسه سرنخ</param>
    /// <returns>نتیجه حذف</returns>
    /// <response code="200">سرنخ با موفقیت حذف شد</response>
    /// <response code="404">سرنخ پیدا نشد</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteLead(Guid id)
    {
        try
        {
            var validationResult = ValidateId(id);
            if (validationResult != null) return validationResult;

            // TODO: Implement DeleteLeadCommand
            await Task.CompletedTask;
            return Deleted("سرنخ با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// تغییر وضعیت سرنخ
    /// Updates lead status
    /// </summary>
    /// <param name="id">شناسه سرنخ</param>
    /// <param name="status">وضعیت جدید</param>
    /// <returns>نتیجه تغییر وضعیت</returns>
    /// <response code="200">وضعیت سرنخ با موفقیت تغییر کرد</response>
    /// <response code="404">سرنخ پیدا نشد</response>
    /// <response code="400">وضعیت نامعتبر است</response>
    [HttpPatch("{id}/status")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> UpdateLeadStatus(Guid id, [FromBody] string status)
    {
        try
        {
            var validationResult = ValidateId(id);
            if (validationResult != null) return validationResult;

            // TODO: Implement UpdateLeadStatusCommand
            await Task.CompletedTask;
            return Success("وضعیت سرنخ با موفقیت تغییر کرد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }
}

