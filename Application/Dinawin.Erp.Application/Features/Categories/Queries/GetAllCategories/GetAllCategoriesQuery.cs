using MediatR;
using Dinawin.Erp.Application.Features.Products.Queries.Dtos;

namespace Dinawin.Erp.Application.Features.Categories.Queries.GetAllCategories;

/// <summary>
/// پرس‌وجو لیست دسته‌بندی‌ها
/// Query for getting all categories
/// </summary>
public record GetAllCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
{
    /// <summary>
    /// عبارت جستجو
    /// Search term
    /// </summary>
    public string? SearchTerm { get; init; }

    /// <summary>
    /// شناسه دسته‌بندی والد
    /// Parent category ID filter
    /// </summary>
    public Guid? ParentCategoryId { get; init; }

    /// <summary>
    /// فقط دسته‌بندی‌های فعال
    /// Only active categories
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
