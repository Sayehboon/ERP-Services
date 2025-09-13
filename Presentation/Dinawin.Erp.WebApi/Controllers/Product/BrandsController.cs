using Dinawin.Erp.Application.Features.Brands.Commands.CreateBrand;
using Dinawin.Erp.Application.Features.Brands.Commands.UpdateBrand;
using Dinawin.Erp.Application.Features.Brands.Commands.DeleteBrand;
using Dinawin.Erp.Application.Features.Brands.Queries.GetAllBrands;
using Dinawin.Erp.Application.Features.Brands.Queries.GetBrandById;
using Dinawin.Erp.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using BrandDto = Dinawin.Erp.Application.Features.Brands.Queries.GetAllBrands.BrandDto;
using GetBrandByIdDto = Dinawin.Erp.Application.Features.Brands.Queries.GetBrandById.BrandDto;

namespace Dinawin.Erp.WebApi.Controllers.Product;

/// <summary>
/// کنترلر مدیریت برندها
/// </summary>
[Route("api/[controller]")]
public class BrandsController : BaseController
{
    /// <summary>
    /// سازنده کنترلر برندها
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public BrandsController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت تمام برندها
    /// </summary>
    /// <param name="searchTerm">عبارت جستجو</param>
    /// <param name="isActive">آیا فقط برندهای فعال</param>
    /// <param name="page">شماره صفحه</param>
    /// <param name="pageSize">اندازه صفحه</param>
    /// <returns>لیست تمام برندها</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<BrandDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<IEnumerable<BrandDto>>> GetAllBrands(
        [FromQuery] string? searchTerm = null,
        [FromQuery] bool? isActive = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 25)
    {
        try
        {
            var query = new GetAllBrandsQuery
            {
                SearchTerm = searchTerm,
                IsActive = isActive,
                Page = page,
                PageSize = pageSize
            };

            var brands = await _mediator.Send(query);
            return Success(brands);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت لیست برندها");
        }
    }

    /// <summary>
    /// دریافت برند بر اساس شناسه
    /// </summary>
    /// <param name="id">شناسه برند</param>
    /// <returns>اطلاعات برند</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetBrandByIdDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<GetBrandByIdDto>> GetBrand(Guid id)
    {
        try
        {
            var query = new GetBrandByIdQuery { Id = id };
            var brand = await _mediator.Send(query);
            
            if (brand == null)
            {
                return NotFound($"برند با شناسه {id} یافت نشد");
            }
            
            return Success(brand);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت اطلاعات برند");
        }
    }

    /// <summary>
    /// ایجاد برند جدید
    /// </summary>
    /// <param name="command">دستور ایجاد برند</param>
    /// <returns>شناسه برند ایجاد شده</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Guid>> CreateBrand([FromBody] CreateBrandCommand command)
    {
        try
        {
            var brandId = await _mediator.Send(command);
            return Created(brandId, "برند با موفقیت ایجاد شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در ایجاد برند");
        }
    }

    /// <summary>
    /// به‌روزرسانی برند
    /// </summary>
    /// <param name="id">شناسه برند</param>
    /// <param name="command">دستور به‌روزرسانی</param>
    /// <returns>نتیجه به‌روزرسانی</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> UpdateBrand(Guid id, [FromBody] UpdateBrandCommand command)
    {
        try
        {
            command.Id = id;
            await _mediator.Send(command);
            return Success("برند با موفقیت به‌روزرسانی شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در به‌روزرسانی برند");
        }
    }

    /// <summary>
    /// حذف برند
    /// </summary>
    /// <param name="id">شناسه برند</param>
    /// <returns>نتیجه حذف</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> DeleteBrand(Guid id)
    {
        try
        {
            var command = new DeleteBrandCommand { Id = id };
            await _mediator.Send(command);
            return Success("برند با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در حذف برند");
        }
    }
}