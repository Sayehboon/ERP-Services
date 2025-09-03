using Dinawin.Erp.Application.Features.Brands.Queries.GetAllBrands;
using Dinawin.Erp.Application.Features.Products.Queries.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dinawin.Erp.WebApi.Controllers;

/// <summary>
/// کنترلر مدیریت برندها
/// Controller for managing brands
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class BrandsController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// سازنده کنترلر برندها
    /// Brands controller constructor
    /// </summary>
    /// <param name="mediator">واسط میدیاتور</param>
    public BrandsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// دریافت لیست تمام برندها
    /// Gets all brands with optional filtering
    /// </summary>
    /// <param name="searchTerm">عبارت جستجو</param>
    /// <param name="isActive">وضعیت فعال/غیرفعال</param>
    /// <param name="page">شماره صفحه</param>
    /// <param name="pageSize">تعداد آیتم در هر صفحه</param>
    /// <returns>لیست برندها</returns>
    /// <response code="200">لیست برندها با موفقیت بازگردانده شد</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<BrandDto>), 200)]
    public async Task<ActionResult<IEnumerable<BrandDto>>> GetAllBrands(
        [FromQuery] string? searchTerm = null,
        [FromQuery] bool? isActive = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 25)
    {
        var query = new GetAllBrandsQuery
        {
            SearchTerm = searchTerm,
            IsActive = isActive,
            Page = page,
            PageSize = pageSize
        };

        var brands = await _mediator.Send(query);
        return Ok(brands);
    }

    /// <summary>
    /// دریافت برند با شناسه
    /// Gets a brand by ID
    /// </summary>
    /// <param name="id">شناسه برند</param>
    /// <returns>اطلاعات برند</returns>
    /// <response code="200">برند پیدا شد</response>
    /// <response code="404">برند پیدا نشد</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(BrandDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<BrandDto>> GetBrand(Guid id)
    {
        // TODO: Implement GetBrandByIdQuery
        await Task.CompletedTask;
        return NotFound($"برند با شناسه {id} پیدا نشد");
    }

    /// <summary>
    /// ایجاد برند جدید
    /// Creates a new brand
    /// </summary>
    /// <returns>شناسه برند ایجاد شده</returns>
    /// <response code="201">برند با موفقیت ایجاد شد</response>
    /// <response code="400">اطلاعات ارسالی نامعتبر است</response>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Guid>> CreateBrand()
    {
        // TODO: Implement CreateBrandCommand
        await Task.CompletedTask;
        return BadRequest(new { message = "ایجاد برند - در حال توسعه" });
    }

    /// <summary>
    /// ویرایش برند
    /// Updates an existing brand
    /// </summary>
    /// <param name="id">شناسه برند</param>
    /// <returns>نتیجه ویرایش</returns>
    /// <response code="200">برند با موفقیت ویرایش شد</response>
    /// <response code="404">برند پیدا نشد</response>
    /// <response code="400">اطلاعات ارسالی نامعتبر است</response>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> UpdateBrand(Guid id)
    {
        // TODO: Implement UpdateBrandCommand
        await Task.CompletedTask;
        return Ok(new { message = "برند با موفقیت ویرایش شد" });
    }

    /// <summary>
    /// حذف برند
    /// Deletes a brand
    /// </summary>
    /// <param name="id">شناسه برند</param>
    /// <returns>نتیجه حذف</returns>
    /// <response code="204">برند با موفقیت حذف شد</response>
    /// <response code="404">برند پیدا نشد</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteBrand(Guid id)
    {
        // TODO: Implement DeleteBrandCommand
        await Task.CompletedTask;
        return NoContent();
    }
}
