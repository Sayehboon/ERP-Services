using MediatR;

namespace Dinawin.Erp.Application.Features.Brands.Queries.GetAllBrands;

/// <summary>
/// پرس‌وجو لیست برندها
/// Query for getting all brands
/// </summary>
public record GetAllBrandsQuery : IRequest<IEnumerable<BrandDto>>
{
    /// <summary>
    /// عبارت جستجو
    /// Search term
    /// </summary>
    public string? SearchTerm { get; init; }

    /// <summary>
    /// فقط برندهای فعال
    /// Only active brands
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
