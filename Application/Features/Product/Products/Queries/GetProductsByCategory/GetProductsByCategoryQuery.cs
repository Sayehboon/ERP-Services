using MediatR;
using Dinawin.Erp.Application.Features.Product.Products.Queries.GetAllProducts;

namespace Dinawin.Erp.Application.Features.Product.Products.Queries.GetProductsByCategory;

/// <summary>
/// پرس‌وجو دریافت محصولات یک دسته‌بندی
/// </summary>
public sealed class GetProductsByCategoryQuery : IRequest<IEnumerable<ProductDto>>
{
    /// <summary>
    /// شناسه دسته‌بندی
    /// </summary>
    public required Guid CategoryId { get; init; }

    /// <summary>
    /// شناسه برند برای فیلتر
    /// </summary>
    public Guid? BrandId { get; init; }

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
    /// نوع محصول برای فیلتر
    /// </summary>
    public string ProductType { get; init; }

    /// <summary>
    /// آیا فقط محصولات فعال
    /// </summary>
    public bool? IsActive { get; init; }

    /// <summary>
    /// عبارت جستجو (اختیاری)
    /// </summary>
    public string SearchTerm { get; init; }

    /// <summary>
    /// شماره صفحه
    /// </summary>
    public int Page { get; init; } = 1;

    /// <summary>
    /// تعداد آیتم در هر صفحه
    /// </summary>
    public int PageSize { get; init; } = 25;
}
