using MediatR;

namespace Dinawin.Erp.Application.Features.Products.Commands.UpdateProduct;

/// <summary>
/// فرمان ویرایش کالا
/// Command for updating a product
/// </summary>
public record UpdateProductCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه کالا
    /// Product ID
    /// </summary>
    public required Guid Id { get; init; }

    /// <summary>
    /// کد SKU کالا
    /// Product SKU code
    /// </summary>
    public required string Sku { get; init; }

    /// <summary>
    /// نام کالا
    /// Product name
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// توضیحات کالا
    /// Product description
    /// </summary>
    public string? Description { get; init; }

    /// <summary>
    /// شناسه برند
    /// Brand ID
    /// </summary>
    public Guid? BrandId { get; init; }

    /// <summary>
    /// شناسه دسته‌بندی
    /// Category ID
    /// </summary>
    public Guid? CategoryId { get; init; }

    /// <summary>
    /// شناسه واحد پایه
    /// Base unit of measure ID
    /// </summary>
    public Guid? BaseUomId { get; init; }

    /// <summary>
    /// قیمت خرید
    /// Purchase price
    /// </summary>
    public decimal? PriceBuy { get; init; }

    /// <summary>
    /// قیمت فروش
    /// Selling price
    /// </summary>
    public decimal? PriceSell { get; init; }

    /// <summary>
    /// حداقل موجودی
    /// Minimum stock level
    /// </summary>
    public decimal MinStockLevel { get; init; }

    /// <summary>
    /// حداکثر موجودی
    /// Maximum stock level
    /// </summary>
    public decimal MaxStockLevel { get; init; }

    /// <summary>
    /// نقطه سفارش مجدد
    /// Reorder point
    /// </summary>
    public decimal ReorderPoint { get; init; }

    /// <summary>
    /// وضعیت فعال/غیرفعال
    /// Active status
    /// </summary>
    public bool IsActive { get; init; } = true;
}
