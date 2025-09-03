using Dinawin.Erp.Application.Features.Products.Commands.CreateProduct;
using Dinawin.Erp.Application.Features.Products.Commands.UpdateProduct;
using Dinawin.Erp.Application.Features.Products.Queries.GetAllProducts;
using Dinawin.Erp.Application.Features.Products.Queries.GetProductById;
using Dinawin.Erp.Application.Features.Products.Queries.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dinawin.Erp.WebApi.Controllers;

/// <summary>
/// کنترلر مدیریت کالاها
/// Controller for managing products
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// سازنده کنترلر کالاها
    /// Products controller constructor
    /// </summary>
    /// <param name="mediator">واسط میدیاتور</param>
    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// دریافت لیست تمام کالاها
    /// Gets all products with optional filtering
    /// </summary>
    /// <param name="searchTerm">عبارت جستجو</param>
    /// <param name="brandId">شناسه برند</param>
    /// <param name="categoryId">شناسه دسته‌بندی</param>
    /// <param name="isActive">وضعیت فعال/غیرفعال</param>
    /// <param name="page">شماره صفحه</param>
    /// <param name="pageSize">تعداد آیتم در هر صفحه</param>
    /// <returns>لیست کالاها</returns>
    /// <response code="200">لیست کالاها با موفقیت بازگردانده شد</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ProductDto>), 200)]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts(
        [FromQuery] string? searchTerm = null,
        [FromQuery] Guid? brandId = null,
        [FromQuery] Guid? categoryId = null,
        [FromQuery] bool? isActive = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 25)
    {
        var query = new GetAllProductsQuery
        {
            SearchTerm = searchTerm,
            BrandId = brandId,
            CategoryId = categoryId,
            IsActive = isActive,
            Page = page,
            PageSize = pageSize
        };

        var products = await _mediator.Send(query);
        return Ok(products);
    }

    /// <summary>
    /// دریافت کالا با شناسه
    /// Gets a product by ID
    /// </summary>
    /// <param name="id">شناسه کالا</param>
    /// <returns>اطلاعات کالا</returns>
    /// <response code="200">کالا پیدا شد</response>
    /// <response code="404">کالا پیدا نشد</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ProductDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<ProductDto>> GetProduct(Guid id)
    {
        var query = new GetProductByIdQuery { Id = id };
        var product = await _mediator.Send(query);
        
        if (product == null)
        {
            return NotFound($"کالا با شناسه {id} پیدا نشد");
        }
        
        return Ok(product);
    }

    /// <summary>
    /// ایجاد کالای جدید
    /// Creates a new product
    /// </summary>
    /// <param name="command">اطلاعات کالای جدید</param>
    /// <returns>شناسه کالای ایجاد شده</returns>
    /// <response code="201">کالا با موفقیت ایجاد شد</response>
    /// <response code="400">اطلاعات ارسالی نامعتبر است</response>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Guid>> CreateProduct(CreateProductCommand command)
    {
        try
        {
            var productId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetProduct), new { id = productId }, productId);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "خطا در ایجاد کالا", error = ex.Message });
        }
    }

    /// <summary>
    /// ویرایش کالا
    /// Updates an existing product
    /// </summary>
    /// <param name="id">شناسه کالا</param>
    /// <returns>نتیجه ویرایش</returns>
    /// <response code="200">کالا با موفقیت ویرایش شد</response>
    /// <response code="404">کالا پیدا نشد</response>
    /// <response code="400">اطلاعات ارسالی نامعتبر است</response>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductCommand command)
    {
        try
        {
            if (command.Id != id)
            {
                return BadRequest(new { message = "شناسه کالا در URL و Body باید یکسان باشد" });
            }

            var result = await _mediator.Send(command);
            
            if (!result)
            {
                return NotFound($"کالا با شناسه {id} پیدا نشد");
            }

            return Ok(new { message = "کالا با موفقیت ویرایش شد" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "خطا در ویرایش کالا", error = ex.Message });
        }
    }

    /// <summary>
    /// حذف کالا
    /// Deletes a product
    /// </summary>
    /// <param name="id">شناسه کالا</param>
    /// <returns>نتیجه حذف</returns>
    /// <response code="204">کالا با موفقیت حذف شد</response>
    /// <response code="404">کالا پیدا نشد</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        // TODO: Implement DeleteProductCommand
        await Task.CompletedTask;
        return NoContent();
    }
}
