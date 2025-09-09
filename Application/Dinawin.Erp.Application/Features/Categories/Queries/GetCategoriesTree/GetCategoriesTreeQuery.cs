using MediatR;
using Dinawin.Erp.Application.Features.Categories.DTOs;

namespace Dinawin.Erp.Application.Features.Categories.Queries.GetCategoriesTree;

/// <summary>
/// پرس‌وجو دریافت درخت دسته‌بندی‌ها
/// </summary>
public sealed class GetCategoriesTreeQuery : IRequest<IEnumerable<CategoryTreeDto>>
{
    /// <summary>
    /// آیا فقط دسته‌بندی‌های فعال
    /// </summary>
    public bool? OnlyActive { get; init; }

    /// <summary>
    /// شناسه دسته‌بندی والد (برای دریافت زیردسته‌ها)
    /// </summary>
    public Guid? ParentId { get; init; }
}
