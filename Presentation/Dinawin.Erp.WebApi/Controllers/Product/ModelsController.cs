using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;
using Dinawin.Erp.Application.Features.Models.Queries.GetAllModels;
using Dinawin.Erp.Application.Features.Models.Queries.GetModelById;
using Dinawin.Erp.Application.Features.Models.Commands.CreateModel;
using Dinawin.Erp.Application.Features.Models.Commands.UpdateModel;
using Dinawin.Erp.Application.Features.Models.Commands.DeleteModel;
using ModelDto = Dinawin.Erp.Application.Features.Models.Queries.GetAllModels.ModelDto;
using GetModelByIdDto = Dinawin.Erp.Application.Features.Models.Queries.GetModelById.ModelDto;

namespace Dinawin.Erp.WebApi.Controllers.Product;

/// <summary>
/// کنترلر مدیریت مدل‌ها
/// </summary>
[Route("api/[controller]")]
public class ModelsController : BaseController
{
    /// <summary>
    /// سازنده کنترلر مدل‌ها
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public ModelsController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت تمام مدل‌ها
    /// </summary>
    /// <param name="searchTerm">عبارت جستجو</param>
    /// <param name="brandId">شناسه برند</param>
    /// <param name="isActive">آیا فقط مدل‌های فعال</param>
    /// <param name="page">شماره صفحه</param>
    /// <param name="pageSize">اندازه صفحه</param>
    /// <returns>لیست تمام مدل‌ها</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ModelDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<object> GetAllModels(
        [FromQuery] string? searchTerm = null,
        [FromQuery] Guid? brandId = null,
        [FromQuery] bool? isActive = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 25)
    {
        try
        {
            var query = new GetAllModelsQuery
            {
                SearchTerm = searchTerm,
                BrandId = brandId,
                IsActive = isActive,
                Page = page,
                PageSize = pageSize
            };

            var models = await _mediator.Send(query);
            return Success(models);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت لیست مدل‌ها");
        }
    }

    /// <summary>
    /// دریافت مدل بر اساس شناسه
    /// </summary>
    /// <param name="id">شناسه مدل</param>
    /// <returns>اطلاعات مدل</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetModelByIdDto), 200)]
    [ProducesResponseType(404)]
    public async Task<object> GetModel(Guid id)
    {
        try
        {
            var query = new GetModelByIdQuery { Id = id };
            var model = await _mediator.Send(query);
            
            if (model == null)
            {
                return NotFound($"مدل با شناسه {id} یافت نشد");
            }
            
            return Success(model);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت اطلاعات مدل");
        }
    }

    /// <summary>
    /// دریافت مدل‌های یک برند
    /// </summary>
    /// <param name="brandId">شناسه برند</param>
    /// <returns>لیست مدل‌های برند</returns>
    [HttpGet("by-brand/{brandId}")]
    [ProducesResponseType(typeof(IEnumerable<ModelDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<object> GetModelsByBrand(Guid brandId)
    {
        try
        {
            var query = new GetAllModelsQuery { BrandId = brandId };
            var models = await _mediator.Send(query);
            return Success(models);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت مدل‌های برند");
        }
    }

    /// <summary>
    /// ایجاد مدل جدید
    /// </summary>
    /// <param name="command">دستور ایجاد مدل</param>
    /// <returns>شناسه مدل ایجاد شده</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<object> CreateModel([FromBody] CreateModelCommand command)
    {
        try
        {
            var modelId = await _mediator.Send(command);
            return Created(modelId, "مدل با موفقیت ایجاد شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در ایجاد مدل");
        }
    }

    /// <summary>
    /// به‌روزرسانی مدل
    /// </summary>
    /// <param name="id">شناسه مدل</param>
    /// <param name="command">دستور به‌روزرسانی</param>
    /// <returns>نتیجه به‌روزرسانی</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<object> UpdateModel(Guid id, [FromBody] UpdateModelCommand command)
    {
        try
        {
            command.Id = id;
            await _mediator.Send(command);
            return Success("مدل با موفقیت به‌روزرسانی شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در به‌روزرسانی مدل");
        }
    }

    /// <summary>
    /// حذف مدل
    /// </summary>
    /// <param name="id">شناسه مدل</param>
    /// <returns>نتیجه حذف</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<object> DeleteModel(Guid id)
    {
        try
        {
            var command = new DeleteModelCommand { Id = id };
            await _mediator.Send(command);
            return Success("مدل با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در حذف مدل");
        }
    }
}
