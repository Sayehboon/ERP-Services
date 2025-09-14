using MediatR;
using Dinawin.Erp.Application.Features.Product.Products.Queries.GetAllProducts;

namespace Dinawin.Erp.Application.Features.Product.Products.Queries.SearchProducts;

/// <summary>
/// پرس‌وجو جستجوی محصولات
/// </summary>
public sealed class SearchProductsQuery : IRequest<IEnumerable<ProductDto>>
{
    /// <summary>
    /// عبارت جستجو
    /// </summary>
    public required string SearchTerm { get; init; }

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
    /// نوع محصول برای فیلتر
    /// </summary>
    public string ProductType { get; init; }

    /// <summary>
    /// وضعیت محصول برای فیلتر
    /// </summary>
    public string Status { get; init; }

    /// <summary>
    /// آیا فقط محصولات فعال
    /// </summary>
    public bool? IsActive { get; init; }

    /// <summary>
    /// شماره صفحه
    /// </summary>
    public int Page { get; init; } = 1;

    /// <summary>
    /// تعداد آیتم در هر صفحه
    /// </summary>
    public int PageSize { get; init; } = 25;
}
