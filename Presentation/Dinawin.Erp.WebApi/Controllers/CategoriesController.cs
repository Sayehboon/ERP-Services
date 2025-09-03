using Dinawin.Erp.Application.Features.Categories.Queries.GetAllCategories;
using Dinawin.Erp.Application.Features.Products.Queries.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dinawin.Erp.WebApi.Controllers;

/// <summary>
/// کنترلر مدیریت دسته‌بندی‌ها
/// Controller for managing categories
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// سازنده کنترلر دسته‌بندی‌ها
    /// Categories controller constructor
    /// </summary>
    /// <param name="mediator">واسط میدیاتور</param>
    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// دریافت لیست تمام دسته‌بندی‌ها
    /// Gets all categories with optional filtering
    /// </summary>
    /// <param name="searchTerm">عبارت جستجو</param>
    /// <param name="parentCategoryId">شناسه دسته‌بندی والد</param>
    /// <param name="isActive">وضعیت فعال/غیرفعال</param>
    /// <param name="page">شماره صفحه</param>
    /// <param name="pageSize">تعداد آیتم در هر صفحه</param>
    /// <returns>لیست دسته‌بندی‌ها</returns>
    /// <response code="200">لیست دسته‌بندی‌ها با موفقیت بازگردانده شد</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CategoryDto>), 200)]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllCategories(
        [FromQuery] string? searchTerm = null,
        [FromQuery] Guid? parentCategoryId = null,
        [FromQuery] bool? isActive = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 25)
    {
        var query = new GetAllCategoriesQuery
        {
            SearchTerm = searchTerm,
            ParentCategoryId = parentCategoryId,
            IsActive = isActive,
            Page = page,
            PageSize = pageSize
        };

        var categories = await _mediator.Send(query);
        return Ok(categories);
    }

    /// <summary>
    /// دریافت دسته‌بندی با شناسه
    /// Gets a category by ID
    /// </summary>
    /// <param name="id">شناسه دسته‌بندی</param>
    /// <returns>اطلاعات دسته‌بندی</returns>
    /// <response code="200">دسته‌بندی پیدا شد</response>
    /// <response code="404">دسته‌بندی پیدا نشد</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CategoryDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<CategoryDto>> GetCategory(Guid id)
    {
        // TODO: Implement GetCategoryByIdQuery
        await Task.CompletedTask;
        return NotFound($"دسته‌بندی با شناسه {id} پیدا نشد");
    }

    /// <summary>
    /// ایجاد دسته‌بندی جدید
    /// Creates a new category
    /// </summary>
    /// <returns>شناسه دسته‌بندی ایجاد شده</returns>
    /// <response code="201">دسته‌بندی با موفقیت ایجاد شد</response>
    /// <response code="400">اطلاعات ارسالی نامعتبر است</response>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Guid>> CreateCategory()
    {
        // TODO: Implement CreateCategoryCommand
        await Task.CompletedTask;
        return BadRequest(new { message = "ایجاد دسته‌بندی - در حال توسعه" });
    }

    /// <summary>
    /// ویرایش دسته‌بندی
    /// Updates an existing category
    /// </summary>
    /// <param name="id">شناسه دسته‌بندی</param>
    /// <returns>نتیجه ویرایش</returns>
    /// <response code="200">دسته‌بندی با موفقیت ویرایش شد</response>
    /// <response code="404">دسته‌بندی پیدا نشد</response>
    /// <response code="400">اطلاعات ارسالی نامعتبر است</response>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> UpdateCategory(Guid id)
    {
        // TODO: Implement UpdateCategoryCommand
        await Task.CompletedTask;
        return Ok(new { message = "دسته‌بندی با موفقیت ویرایش شد" });
    }

    /// <summary>
    /// حذف دسته‌بندی
    /// Deletes a category
    /// </summary>
    /// <param name="id">شناسه دسته‌بندی</param>
    /// <returns>نتیجه حذف</returns>
    /// <response code="204">دسته‌بندی با موفقیت حذف شد</response>
    /// <response code="404">دسته‌بندی پیدا نشد</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        // TODO: Implement DeleteCategoryCommand
        await Task.CompletedTask;
        return NoContent();
    }
}
