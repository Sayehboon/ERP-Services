using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;
using Dinawin.Erp.Application.Features.Years.Queries.GetAllYears;
using Dinawin.Erp.Application.Features.Years.Queries.GetYearById;
using Dinawin.Erp.Application.Features.Years.Commands.CreateYear;
using Dinawin.Erp.Application.Features.Years.Commands.UpdateYear;
using Dinawin.Erp.Application.Features.Years.Commands.DeleteYear;
using YearDto = Dinawin.Erp.Application.Features.Years.Queries.GetAllYears.YearDto;
using GetYearByIdDto = Dinawin.Erp.Application.Features.Years.Queries.GetYearById.YearDto;

namespace Dinawin.Erp.WebApi.Controllers.Product;

/// <summary>
/// کنترلر مدیریت سال‌ها
/// </summary>
[Route("api/[controller]")]
public class YearsController : BaseController
{
    /// <summary>
    /// سازنده کنترلر سال‌ها
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public YearsController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت تمام سال‌ها
    /// </summary>
    /// <param name="searchTerm">عبارت جستجو</param>
    /// <param name="isActive">آیا فقط سال‌های فعال</param>
    /// <param name="page">شماره صفحه</param>
    /// <param name="pageSize">اندازه صفحه</param>
    /// <returns>لیست تمام سال‌ها</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<YearDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<IEnumerable<YearDto>>> GetAllYears(
        [FromQuery] string searchTerm = null,
        [FromQuery] bool? isActive = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 25)
    {
        try
        {
            var query = new GetAllYearsQuery
            {
                SearchTerm = searchTerm,
                IsActive = isActive,
                Page = page,
                PageSize = pageSize
            };

            var years = await _mediator.Send(query);
            return Success(years);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت لیست سال‌ها");
        }
    }

    /// <summary>
    /// دریافت سال بر اساس شناسه
    /// </summary>
    /// <param name="id">شناسه سال</param>
    /// <returns>اطلاعات سال</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetYearByIdDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<GetYearByIdDto>> GetYear(Guid id)
    {
        try
        {
            var query = new GetYearByIdQuery { Id = id };
            var year = await _mediator.Send(query);
            
            if (year == null)
            {
                return NotFound($"سال با شناسه {id} یافت نشد");
            }
            
            return Success(year);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت اطلاعات سال");
        }
    }

    /// <summary>
    /// دریافت سال‌های فعال
    /// </summary>
    /// <returns>لیست سال‌های فعال</returns>
    [HttpGet("active")]
    [ProducesResponseType(typeof(IEnumerable<YearDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<IEnumerable<YearDto>>> GetActiveYears()
    {
        try
        {
            var query = new GetAllYearsQuery { IsActive = true };
            var years = await _mediator.Send(query);
            return Success(years);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت سال‌های فعال");
        }
    }

    /// <summary>
    /// ایجاد سال جدید
    /// </summary>
    /// <param name="command">دستور ایجاد سال</param>
    /// <returns>شناسه سال ایجاد شده</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Guid>> CreateYear([FromBody] CreateYearCommand command)
    {
        try
        {
            var yearId = await _mediator.Send(command);
            return Created(yearId, "سال با موفقیت ایجاد شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در ایجاد سال");
        }
    }

    /// <summary>
    /// به‌روزرسانی سال
    /// </summary>
    /// <param name="id">شناسه سال</param>
    /// <param name="command">دستور به‌روزرسانی</param>
    /// <returns>نتیجه به‌روزرسانی</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> UpdateYear(Guid id, [FromBody] UpdateYearCommand command)
    {
        try
        {
            command.Id = id;
            await _mediator.Send(command);
            return Success("سال با موفقیت به‌روزرسانی شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در به‌روزرسانی سال");
        }
    }

    /// <summary>
    /// حذف سال
    /// </summary>
    /// <param name="id">شناسه سال</param>
    /// <returns>نتیجه حذف</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> DeleteYear(Guid id)
    {
        try
        {
            var command = new DeleteYearCommand { Id = id };
            await _mediator.Send(command);
            return Success("سال با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در حذف سال");
        }
    }
}
