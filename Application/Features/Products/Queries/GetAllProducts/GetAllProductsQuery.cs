using MediatR;
using Dinawin.Erp.Application.Features.Products.Queries.Dtos;

namespace Dinawin.Erp.Application.Features.Products.Queries.GetAllProducts;

/// <summary>
/// پرس‌وجو لیست کالاها
/// Query for getting all products
/// </summary>
public record GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>
{
    /// <summary>
    /// عبارت جستجو
    /// Search term
    /// </summary>
    public string SearchTerm { get; init; }

    /// <summary>
    /// شناسه برند
    /// Brand ID filter
    /// </summary>
    public Guid? BrandId { get; init; }

    /// <summary>
    /// شناسه دسته‌بندی
    /// Category ID filter
    /// </summary>
    public Guid? CategoryId { get; init; }

    /// <summary>
    /// فقط کالاهای فعال
    /// Only active products
    /// </summary>
    public bool? IsActive { get; init; }

    /// <summary>
    /// شماره صفحه
    /// Page number
    /// </summary>
    public int Page { get; init; } = 1;

    /// <summary>
    /// تعداد آیتم در هر صفحه
    /// Items per page
    /// </summary>
    public int PageSize { get; init; } = 25;
}
