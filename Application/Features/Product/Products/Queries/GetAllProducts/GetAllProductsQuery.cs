using MediatR;

namespace Dinawin.Erp.Application.Features.Product.Products.Queries.GetAllProducts;

/// <summary>
/// پرس‌وجو لیست محصولات
/// </summary>
public sealed class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>
{
    /// <summary>
    /// عبارت جستجو
    /// </summary>
    public string SearchTerm { get; init; }

    /// <summary>
    /// شناسه برند برای فیلتر
    /// </summary>
    public Guid? BrandId { get; init; }

    /// <summary>
    /// شناسه دسته‌بندی برای فیلتر
    /// </summary>
    public Guid? CategoryId { get; init; }

    /// <summary>
    /// شناسه مدل برای فیلتر
    /// </summary>
    public Guid? ModelId { get; init; }

    /// <summary>
    /// شناسه تریم برای فیلتر
    /// </summary>
    public Guid? TrimId { get; init; }

    /// <summary>
    /// شناسه سال برای فیلتر
    /// </summary>
    public Guid? YearId { get; init; }

    /// <summary>
    /// شناسه واحد برای فیلتر
    /// </summary>
    public Guid? UnitId { get; init; }

    /// <summary>
    /// شناسه UOM برای فیلتر
    /// </summary>
    public Guid? UomId { get; init; }

    /// <summary>
    /// نوع محصول برای فیلتر
    /// </summary>
    public string ProductType { get; init; }

    /// <summary>
    /// وضعیت محصول برای فیلتر
    /// </summary>
    public string Status { get; init; }

    /// <summary>
    /// رنگ محصول برای فیلتر
    /// </summary>
    public string Color { get; init; }

    /// <summary>
    /// آیا قابل فروش است
    /// </summary>
    public bool? IsSellable { get; init; }

    /// <summary>
    /// آیا قابل خرید است
    /// </summary>
    public bool? IsPurchasable { get; init; }

    /// <summary>
    /// آیا قابل تولید است
    /// </summary>
    public bool? IsManufacturable { get; init; }

    /// <summary>
    /// قیمت خرید حداقل
    /// </summary>
    public decimal? MinPurchasePrice { get; init; }

    /// <summary>
    /// قیمت خرید حداکثر
    /// </summary>
    public decimal? MaxPurchasePrice { get; init; }

    /// <summary>
    /// قیمت فروش حداقل
    /// </summary>
    public decimal? MinSalePrice { get; init; }

    /// <summary>
    /// قیمت فروش حداکثر
    /// </summary>
    public decimal? MaxSalePrice { get; init; }

    /// <summary>
    /// موجودی حداقل
    /// </summary>
    public decimal? MinStock { get; init; }

    /// <summary>
    /// موجودی حداکثر
    /// </summary>
    public decimal? MaxStock { get; init; }

    /// <summary>
    /// آیا موجودی کم است
    /// </summary>
    public bool? IsLowStock { get; init; }

    /// <summary>
    /// شماره صفحه
    /// </summary>
    public int Page { get; init; } = 1;

    /// <summary>
    /// تعداد آیتم در هر صفحه
    /// </summary>
    public int PageSize { get; init; } = 25;
}