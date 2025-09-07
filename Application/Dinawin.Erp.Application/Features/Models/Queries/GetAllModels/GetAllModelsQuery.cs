using MediatR;

namespace Dinawin.Erp.Application.Features.Models.Queries.GetAllModels;

/// <summary>
/// پرس‌وجو لیست مدل‌ها
/// </summary>
public sealed class GetAllModelsQuery : IRequest<IEnumerable<ModelDto>>
{
    /// <summary>
    /// عبارت جستجو
    /// </summary>
    public string? SearchTerm { get; init; }

    /// <summary>
    /// شناسه برند برای فیلتر
    /// </summary>
    public Guid? BrandId { get; init; }

    /// <summary>
    /// فقط مدل‌های فعال
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
