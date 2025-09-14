using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;
using Dinawin.Erp.Application.Features.Product.Products.Queries.GetAllProducts;
using Dinawin.Erp.Application.Features.Product.Products.Queries.GetProductById;
using Dinawin.Erp.Application.Features.Product.Products.Queries.SearchProducts;
using Dinawin.Erp.Application.Features.Product.Products.Queries.GetProductsByCategory;
using Dinawin.Erp.Application.Features.Product.Products.Commands.CreateProduct;
using Dinawin.Erp.Application.Features.Product.Products.Commands.UpdateProduct;
using Dinawin.Erp.Application.Features.Product.Products.Commands.DeleteProduct;
using ProductDto = Dinawin.Erp.Application.Features.Product.Products.Queries.GetAllProducts.ProductDto;
using GetProductByIdDto = Dinawin.Erp.Application.Features.Product.Products.Queries.GetProductById.ProductDto;

namespace Dinawin.Erp.WebApi.Controllers.Product;

/// <summary>
/// کنترلر مدیریت محصولات
/// </summary>
[Route("api/[controller]")]
public class ProductsController : BaseController
{
    /// <summary>
    /// سازنده کنترلر محصولات
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public ProductsController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت تمام محصولات
    /// </summary>
    /// <param name="searchTerm">عبارت جستجو</param>
    /// <param name="categoryId">شناسه دسته‌بندی</param>
    /// <param name="brandId">شناسه برند</param>
    /// <param name="modelId">شناسه مدل</param>
    /// <param name="isActive">آیا فقط محصولات فعال</param>
    /// <param name="page">شماره صفحه</param>
    /// <param name="pageSize">اندازه صفحه</param>
    /// <returns>لیست تمام محصولات</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ProductDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts(
        [FromQuery] string searchTerm = null,
        [FromQuery] Guid? categoryId = null,
        [FromQuery] Guid? brandId = null,
        [FromQuery] Guid? modelId = null,
        [FromQuery] bool? isActive = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 25)
    {
        try
        {
            var query = new GetAllProductsQuery
            {
                SearchTerm = searchTerm,
                CategoryId = categoryId,
                BrandId = brandId,
                ModelId = modelId,
                Status = isActive.HasValue ? (isActive.Value ? "Active" : "Inactive") : null,
                Page = page,
                PageSize = pageSize
            };

            var products = await _mediator.Send(query);
            return Success(products);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت لیست محصولات");
        }
    }

    /// <summary>
    /// دریافت محصول بر اساس شناسه
    /// </summary>
    /// <param name="id">شناسه محصول</param>
    /// <returns>اطلاعات محصول</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetProductByIdDto), 200)]
    [ProducesResponseType(404)]
    public async Task<object> GetProduct(Guid id)
    {
        try
        {
            var query = new GetProductByIdQuery { Id = id };
            var product = await _mediator.Send(query);
            
            if (product == null)
            {
                return NotFound($"محصول با شناسه {id} یافت نشد");
            }
            
            return Success(product);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت اطلاعات محصول");
        }
    }

    /// <summary>
    /// جستجوی محصولات
    /// </summary>
    /// <param name="searchTerm">عبارت جستجو</param>
    /// <returns>لیست محصولات مطابق جستجو</returns>
    [HttpGet("search")]
    [ProducesResponseType(typeof(IEnumerable<object>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<IEnumerable<ProductDto>>> SearchProducts([FromQuery] string searchTerm)
    {
        try
        {
            var query = new SearchProductsQuery
            {
                SearchTerm = searchTerm
            };
            
            var products = await _mediator.Send(query);
            return Success(products);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در جستجوی محصولات");
        }
    }

    /// <summary>
    /// دریافت محصولات یک دسته‌بندی
    /// </summary>
    /// <param name="categoryId">شناسه دسته‌بندی</param>
    /// <returns>لیست محصولات دسته‌بندی</returns>
    [HttpGet("by-category/{categoryId}")]
    [ProducesResponseType(typeof(IEnumerable<object>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsByCategory(Guid categoryId)
    {
        try
        {
            var query = new GetProductsByCategoryQuery
            {
                CategoryId = categoryId
            };
            
            var products = await _mediator.Send(query);
            return Success(products);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت محصولات دسته‌بندی");
        }
    }

    /// <summary>
    /// ایجاد محصول جدید
    /// </summary>
    /// <param name="command">دستور ایجاد محصول</param>
    /// <returns>شناسه محصول ایجاد شده</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Guid>> CreateProduct([FromBody] CreateProductCommand command)
    {
        try
        {
            var productId = await _mediator.Send(command);
            return Created(productId, "محصول با موفقیت ایجاد شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در ایجاد محصول");
        }
    }

    /// <summary>
    /// به‌روزرسانی محصول
    /// </summary>
    /// <param name="id">شناسه محصول</param>
    /// <param name="command">دستور به‌روزرسانی</param>
    /// <returns>نتیجه به‌روزرسانی</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductCommand command)
    {
        try
        {
            command.Id = id;
            await _mediator.Send(command);
            return Success("محصول با موفقیت به‌روزرسانی شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در به‌روزرسانی محصول");
        }
    }

    /// <summary>
    /// حذف محصول
    /// </summary>
    /// <param name="id">شناسه محصول</param>
    /// <returns>نتیجه حذف</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> DeleteProduct(Guid id)
    {
        try
        {
            var command = new DeleteProductCommand { Id = id };
            await _mediator.Send(command);
            return Success("محصول با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در حذف محصول");
        }
    }
}
