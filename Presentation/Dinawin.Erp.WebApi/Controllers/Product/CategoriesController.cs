using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;
using Dinawin.Erp.Application.Features.Categories.Commands.CreateCategory;
using Dinawin.Erp.Application.Features.Categories.Commands.UpdateCategory;
using Dinawin.Erp.Application.Features.Categories.Commands.DeleteCategory;
using Dinawin.Erp.Application.Features.Categories.Commands.ToggleCategoryActive;
using Dinawin.Erp.Application.Features.Categories.Queries.GetAllCategories;
using Dinawin.Erp.Application.Features.Categories.Queries.GetCategoryById;
using Dinawin.Erp.Application.Features.Categories.Queries.GetCategoriesTree;
using Dinawin.Erp.Application.Features.Categories.DTOs;

namespace Dinawin.Erp.WebApi.Controllers.Product;

/// <summary>
/// کنترلر مدیریت دسته‌بندی‌های محصولات
/// Controller for managing product categories
/// </summary>
[Route("api/[controller]")]
public class CategoriesController : BaseController
{
    /// <summary>
    /// سازنده کنترلر دسته‌بندی‌ها
    /// Categories controller constructor
    /// </summary>
    /// <param name="mediator">واسط میدیاتور</param>
    public CategoriesController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت لیست تمام دسته‌بندی‌ها
    /// Gets all categories with optional filtering
    /// </summary>
    /// <param name="query">پارامترهای فیلتر</param>
    /// <returns>لیست دسته‌بندی‌ها</returns>
    /// <response code="200">لیست دسته‌بندی‌ها با موفقیت بازگردانده شد</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CategoryDto>), 200)]
    public async Task<ActionResult<List<CategoryDto>>> GetAllCategories([FromQuery] GetAllCategoriesQuery query)
    {
        try
        {
            var categories = await _mediator.Send(query);
            return Success(categories, "لیست دسته‌بندی‌ها با موفقیت بازگردانده شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
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
    public async Task<object> GetCategory(Guid id)
    {
        try
        {
            var query = new GetCategoryByIdQuery { Id = id };
            var category = await _mediator.Send(query);
            
            if (category == null)
            {
                return NotFound($"دسته‌بندی با شناسه {id} یافت نشد");
            }
            
            return Success(category, "دسته‌بندی با موفقیت یافت شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت اطلاعات دسته‌بندی");
        }
    }

    /// <summary>
    /// ایجاد دسته‌بندی جدید
    /// Creates a new category
    /// </summary>
    /// <param name="command">اطلاعات دسته‌بندی جدید</param>
    /// <returns>شناسه دسته‌بندی ایجاد شده</returns>
    /// <response code="201">دسته‌بندی با موفقیت ایجاد شد</response>
    /// <response code="400">اطلاعات ارسالی نامعتبر است</response>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Guid>> CreateCategory([FromBody] CreateCategoryCommand command)
    {
        try
        {
            var categoryId = await _mediator.Send(command);
            return Created(categoryId, categoryId, nameof(GetCategory));
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// ویرایش دسته‌بندی
    /// Updates an existing category
    /// </summary>
    /// <param name="id">شناسه دسته‌بندی</param>
    /// <param name="command">اطلاعات به‌روزرسانی</param>
    /// <returns>نتیجه ویرایش</returns>
    /// <response code="200">دسته‌بندی با موفقیت ویرایش شد</response>
    /// <response code="404">دسته‌بندی پیدا نشد</response>
    /// <response code="400">اطلاعات ارسالی نامعتبر است</response>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] UpdateCategoryCommand command)
    {
        try
        {
            command.Id = id;
            await _mediator.Send(command);
            return Success("دسته‌بندی با موفقیت ویرایش شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در ویرایش دسته‌بندی");
        }
    }

    /// <summary>
    /// حذف دسته‌بندی
    /// Deletes a category
    /// </summary>
    /// <param name="id">شناسه دسته‌بندی</param>
    /// <returns>نتیجه حذف</returns>
    /// <response code="200">دسته‌بندی با موفقیت حذف شد</response>
    /// <response code="404">دسته‌بندی پیدا نشد</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        try
        {
            var command = new DeleteCategoryCommand { Id = id };
            await _mediator.Send(command);
            return Success("دسته‌بندی با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در حذف دسته‌بندی");
        }
    }

    /// <summary>
    /// تغییر وضعیت فعال/غیرفعال دسته‌بندی
    /// Toggles category active status
    /// </summary>
    /// <param name="id">شناسه دسته‌بندی</param>
    /// <returns>نتیجه تغییر وضعیت</returns>
    /// <response code="200">وضعیت دسته‌بندی با موفقیت تغییر کرد</response>
    /// <response code="404">دسته‌بندی پیدا نشد</response>
    [HttpPatch("{id}/toggle-active")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<object> ToggleCategoryActive(Guid id)
    {
        try
        {
            var validationResult = ValidateId(id);
            if (validationResult != null) return validationResult;

            var command = new ToggleCategoryActiveCommand
            {
                Id = id
            };
            
            var isActive = await _mediator.Send(command);
            return Success(new { IsActive = isActive }, "وضعیت دسته‌بندی با موفقیت تغییر کرد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// دریافت درخت دسته‌بندی‌ها
    /// Gets categories tree structure
    /// </summary>
    /// <returns>درخت دسته‌بندی‌ها</returns>
    /// <response code="200">درخت دسته‌بندی‌ها با موفقیت بازگردانده شد</response>
    [HttpGet("tree")]
    [ProducesResponseType(typeof(IEnumerable<CategoryDto>), 200)]
    public async Task<object> GetCategoriesTree()
    {
        try
        {
            var query = new GetCategoriesTreeQuery();
            var categoriesTree = await _mediator.Send(query);
            return Success(categoriesTree, "درخت دسته‌بندی‌ها با موفقیت بازگردانده شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }
}

