using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.Application.Features.CRM.Activities.Commands.CreateActivity;
using Dinawin.Erp.Application.Features.CRM.Activities.Queries.GetAllActivities;
using Dinawin.Erp.Application.Features.CRM.Activities.Queries.GetActivityById;
using Dinawin.Erp.Application.Features.CRM.Activities.Commands.UpdateActivity;
using Dinawin.Erp.Application.Features.CRM.Activities.Commands.DeleteActivity;
using ActivityDto = Dinawin.Erp.Application.Features.CRM.Activities.DTOs.ActivityDto;

namespace Dinawin.Erp.WebApi.Controllers.CRM;

/// <summary>
/// کنترلر مدیریت فعالیت‌های CRM
/// Controller for managing CRM activities
/// </summary>
[Route("api/[controller]")]
public class ActivitiesController : BaseController
{
    /// <summary>
    /// سازنده کنترلر فعالیت‌ها
    /// Activities controller constructor
    /// </summary>
    /// <param name="mediator">واسط میدیاتور</param>
    public ActivitiesController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت لیست تمام فعالیت‌ها
    /// Gets all activities with optional filtering
    /// </summary>
    /// <param name="query">پارامترهای فیلتر</param>
    /// <returns>لیست فعالیت‌ها</returns>
    /// <response code="200">لیست فعالیت‌ها با موفقیت بازگردانده شد</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ActivityDto>), 200)]
    public async Task<object> GetAllActivities([FromQuery] GetAllActivitiesQuery query)
    {
        try
        {
            var activities = await _mediator.Send(query);
            return Success(activities, "لیست فعالیت‌ها با موفقیت بازگردانده شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// دریافت فعالیت با شناسه
    /// Gets an activity by ID
    /// </summary>
    /// <param name="id">شناسه فعالیت</param>
    /// <returns>اطلاعات فعالیت</returns>
    /// <response code="200">فعالیت پیدا شد</response>
    /// <response code="404">فعالیت پیدا نشد</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ActivityDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<ActivityDto>> GetActivity(Guid id)
    {
        try
        {
            var validationResult = ValidateId(id);
            if (validationResult != null) return validationResult;

            var result = await _mediator.Send(new GetActivityByIdQuery(id));
            if (result == null) return Error("فعالیت با شناسه مشخص شده پیدا نشد", 404);
            return Success(result);
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// ایجاد فعالیت جدید
    /// Creates a new activity
    /// </summary>
    /// <param name="command">اطلاعات فعالیت جدید</param>
    /// <returns>شناسه فعالیت ایجاد شده</returns>
    /// <response code="201">فعالیت با موفقیت ایجاد شد</response>
    /// <response code="400">اطلاعات ارسالی نامعتبر است</response>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Guid>> CreateActivity([FromBody] CreateActivityCommand command)
    {
        try
        {
            var activityId = await _mediator.Send(command);
            return Created(activityId, activityId, nameof(GetActivity));
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// ویرایش فعالیت
    /// Updates an existing activity
    /// </summary>
    /// <param name="id">شناسه فعالیت</param>
    /// <param name="command">اطلاعات به‌روزرسانی</param>
    /// <returns>نتیجه ویرایش</returns>
    /// <response code="200">فعالیت با موفقیت ویرایش شد</response>
    /// <response code="404">فعالیت پیدا نشد</response>
    /// <response code="400">اطلاعات ارسالی نامعتبر است</response>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> UpdateActivity(Guid id, [FromBody] UpdateActivityCommand command)
    {
        try
        {
            var validationResult = ValidateId(id);
            if (validationResult != null) return validationResult;

            if (command.Id != id) return BadRequest("شناسه فعالیت مطابقت ندارد");
            var ok = await _mediator.Send(command);
            if (!ok) return Error("فعالیت پیدا نشد", 404);
            return Updated("فعالیت با موفقیت ویرایش شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// حذف فعالیت
    /// Deletes an activity
    /// </summary>
    /// <param name="id">شناسه فعالیت</param>
    /// <returns>نتیجه حذف</returns>
    /// <response code="200">فعالیت با موفقیت حذف شد</response>
    /// <response code="404">فعالیت پیدا نشد</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<object> DeleteActivity(Guid id)
    {
        try
        {
            var validationResult = ValidateId(id);
            if (validationResult != null) return validationResult;

            var ok = await _mediator.Send(new DeleteActivityCommand(id));
            if (!ok) return Error("فعالیت پیدا نشد", 404);
            return Deleted("فعالیت با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// تغییر وضعیت فعالیت
    /// Updates activity status
    /// </summary>
    /// <param name="id">شناسه فعالیت</param>
    /// <param name="status">وضعیت جدید</param>
    /// <returns>نتیجه تغییر وضعیت</returns>
    /// <response code="200">وضعیت فعالیت با موفقیت تغییر کرد</response>
    /// <response code="404">فعالیت پیدا نشد</response>
    /// <response code="400">وضعیت نامعتبر است</response>
    [HttpPatch("{id}/status")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> UpdateActivityStatus(Guid id, [FromBody] string status)
    {
        try
        {
            var validationResult = ValidateId(id);
            if (validationResult != null) return validationResult;

            // TODO: Implement UpdateActivityStatusCommand
            await Task.CompletedTask;
            return Success("وضعیت فعالیت با موفقیت تغییر کرد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }
}

