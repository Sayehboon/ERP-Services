using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.Application.Features.Opportunities.Commands.CreateOpportunity;
using Dinawin.Erp.Application.Features.Opportunities.Queries.GetAllOpportunities;
using Dinawin.Erp.Application.Features.Opportunities.DTOs;

namespace Dinawin.Erp.WebApi.Controllers.CRM;

/// <summary>
/// کنترلر مدیریت فرصت‌های CRM
/// Controller for managing CRM opportunities
/// </summary>
[Route("api/[controller]")]
public class OpportunitiesController : BaseController
{
    /// <summary>
    /// سازنده کنترلر فرصت‌ها
    /// Opportunities controller constructor
    /// </summary>
    /// <param name="mediator">واسط میدیاتور</param>
    public OpportunitiesController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت لیست تمام فرصت‌ها
    /// Gets all opportunities with optional filtering
    /// </summary>
    /// <param name="query">پارامترهای فیلتر</param>
    /// <returns>لیست فرصت‌ها</returns>
    /// <response code="200">لیست فرصت‌ها با موفقیت بازگردانده شد</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<OpportunityDto>), 200)]
    public async Task<ActionResult<List<OpportunityDto>>> GetAllOpportunities([FromQuery] GetAllOpportunitiesQuery query)
    {
        try
        {
            var opportunities = await _mediator.Send(query);
            return Success(opportunities, "لیست فرصت‌ها با موفقیت بازگردانده شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// دریافت فرصت با شناسه
    /// Gets an opportunity by ID
    /// </summary>
    /// <param name="id">شناسه فرصت</param>
    /// <returns>اطلاعات فرصت</returns>
    /// <response code="200">فرصت پیدا شد</response>
    /// <response code="404">فرصت پیدا نشد</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(OpportunityDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<OpportunityDto>> GetOpportunity(Guid id)
    {
        try
        {
            var validationResult = ValidateId(id);
            if (validationResult != null) return validationResult;

            // TODO: Implement GetOpportunityByIdQuery
            await Task.CompletedTask;
            return Error("فرصت با شناسه مشخص شده پیدا نشد", 404);
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// ایجاد فرصت جدید
    /// Creates a new opportunity
    /// </summary>
    /// <param name="command">اطلاعات فرصت جدید</param>
    /// <returns>شناسه فرصت ایجاد شده</returns>
    /// <response code="201">فرصت با موفقیت ایجاد شد</response>
    /// <response code="400">اطلاعات ارسالی نامعتبر است</response>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Guid>> CreateOpportunity([FromBody] CreateOpportunityCommand command)
    {
        try
        {
            var opportunityId = await _mediator.Send(command);
            return Created(opportunityId, opportunityId, nameof(GetOpportunity));
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// ویرایش فرصت
    /// Updates an existing opportunity
    /// </summary>
    /// <param name="id">شناسه فرصت</param>
    /// <param name="command">اطلاعات به‌روزرسانی</param>
    /// <returns>نتیجه ویرایش</returns>
    /// <response code="200">فرصت با موفقیت ویرایش شد</response>
    /// <response code="404">فرصت پیدا نشد</response>
    /// <response code="400">اطلاعات ارسالی نامعتبر است</response>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> UpdateOpportunity(Guid id, [FromBody] UpdateOpportunityCommand command)
    {
        try
        {
            var validationResult = ValidateId(id);
            if (validationResult != null) return validationResult;

            // TODO: Implement UpdateOpportunityCommand
            await Task.CompletedTask;
            return Updated("فرصت با موفقیت ویرایش شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// حذف فرصت
    /// Deletes an opportunity
    /// </summary>
    /// <param name="id">شناسه فرصت</param>
    /// <returns>نتیجه حذف</returns>
    /// <response code="200">فرصت با موفقیت حذف شد</response>
    /// <response code="404">فرصت پیدا نشد</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteOpportunity(Guid id)
    {
        try
        {
            var validationResult = ValidateId(id);
            if (validationResult != null) return validationResult;

            // TODO: Implement DeleteOpportunityCommand
            await Task.CompletedTask;
            return Deleted("فرصت با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// تغییر وضعیت فرصت
    /// Updates opportunity status
    /// </summary>
    /// <param name="id">شناسه فرصت</param>
    /// <param name="status">وضعیت جدید</param>
    /// <returns>نتیجه تغییر وضعیت</returns>
    /// <response code="200">وضعیت فرصت با موفقیت تغییر کرد</response>
    /// <response code="404">فرصت پیدا نشد</response>
    /// <response code="400">وضعیت نامعتبر است</response>
    [HttpPatch("{id}/status")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> UpdateOpportunityStatus(Guid id, [FromBody] string status)
    {
        try
        {
            var validationResult = ValidateId(id);
            if (validationResult != null) return validationResult;

            // TODO: Implement UpdateOpportunityStatusCommand
            await Task.CompletedTask;
            return Success("وضعیت فرصت با موفقیت تغییر کرد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }
}

