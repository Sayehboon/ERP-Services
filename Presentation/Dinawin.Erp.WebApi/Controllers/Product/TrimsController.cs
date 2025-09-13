using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;
using Dinawin.Erp.Application.Features.Trims.Queries.GetAllTrims;
using Dinawin.Erp.Application.Features.Trims.Queries.GetTrimById;
using Dinawin.Erp.Application.Features.Trims.Commands.CreateTrim;
using Dinawin.Erp.Application.Features.Trims.Commands.UpdateTrim;
using Dinawin.Erp.Application.Features.Trims.Commands.DeleteTrim;

namespace Dinawin.Erp.WebApi.Controllers.Product;

/// <summary>
/// کنترلر مدیریت تریم‌ها
/// </summary>
[Route("api/[controller]")]
public class TrimsController : BaseController
{
    /// <summary>
    /// سازنده کنترلر تریم‌ها
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public TrimsController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت تمام تریم‌ها
    /// </summary>
    /// <param name="searchTerm">عبارت جستجو</param>
    /// <param name="modelId">شناسه مدل</param>
    /// <param name="isActive">آیا فقط تریم‌های فعال</param>
    /// <param name="page">شماره صفحه</param>
    /// <param name="pageSize">اندازه صفحه</param>
    /// <returns>لیست تمام تریم‌ها</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Application.Features.Trims.Queries.GetAllTrims.TrimDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<object> GetAllTrims(
        [FromQuery] string? searchTerm = null,
        [FromQuery] Guid? modelId = null,
        [FromQuery] bool? isActive = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 25)
    {
        try
        {
            var query = new GetAllTrimsQuery
            {
                SearchTerm = searchTerm,
                ModelId = modelId,
                IsActive = isActive,
                Page = page,
                PageSize = pageSize
            };

            var trims = await _mediator.Send(query);
            return Success(trims);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت لیست تریم‌ها");
        }
    }

    /// <summary>
    /// دریافت تریم بر اساس شناسه
    /// </summary>
    /// <param name="id">شناسه تریم</param>
    /// <returns>اطلاعات تریم</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Application.Features.Trims.Queries.GetTrimById.TrimDto), 200)]
    [ProducesResponseType(404)]
    public async Task<object> GetTrim(Guid id)
    {
        try
        {
            var query = new GetTrimByIdQuery { Id = id };
            var trim = await _mediator.Send(query);
            
            if (trim == null)
            {
                return NotFound($"تریم با شناسه {id} یافت نشد");
            }
            
            return Success(trim);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت اطلاعات تریم");
        }
    }

    /// <summary>
    /// دریافت تریم‌های یک مدل
    /// </summary>
    /// <param name="modelId">شناسه مدل</param>
    /// <returns>لیست تریم‌های مدل</returns>
    [HttpGet("by-model/{modelId}")]
    [ProducesResponseType(typeof(IEnumerable<Application.Features.Trims.Queries.GetAllTrims.TrimDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<object> GetTrimsByModel(Guid modelId)
    {
        try
        {
            var query = new GetAllTrimsQuery { ModelId = modelId };
            var trims = await _mediator.Send(query);
            return Success(trims);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت تریم‌های مدل");
        }
    }

    /// <summary>
    /// ایجاد تریم جدید
    /// </summary>
    /// <param name="command">دستور ایجاد تریم</param>
    /// <returns>شناسه تریم ایجاد شده</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Guid>> CreateTrim([FromBody] CreateTrimCommand command)
    {
        try
        {
            var trimId = await _mediator.Send(command);
            return Created(trimId, "تریم با موفقیت ایجاد شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در ایجاد تریم");
        }
    }

    /// <summary>
    /// به‌روزرسانی تریم
    /// </summary>
    /// <param name="id">شناسه تریم</param>
    /// <param name="command">دستور به‌روزرسانی</param>
    /// <returns>نتیجه به‌روزرسانی</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> UpdateTrim(Guid id, [FromBody] UpdateTrimCommand command)
    {
        try
        {
            command.Id = id;
            await _mediator.Send(command);
            return Success("تریم با موفقیت به‌روزرسانی شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در به‌روزرسانی تریم");
        }
    }

    /// <summary>
    /// حذف تریم
    /// </summary>
    /// <param name="id">شناسه تریم</param>
    /// <returns>نتیجه حذف</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> DeleteTrim(Guid id)
    {
        try
        {
            var command = new DeleteTrimCommand { Id = id };
            await _mediator.Send(command);
            return Success("تریم با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در حذف تریم");
        }
    }
}
