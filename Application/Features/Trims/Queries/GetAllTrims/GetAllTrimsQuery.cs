using MediatR;

namespace Dinawin.Erp.Application.Features.Trims.Queries.GetAllTrims;

/// <summary>
/// پرس‌وجو لیست تریم‌ها
/// </summary>
public sealed class GetAllTrimsQuery : IRequest<IEnumerable<TrimDto>>
{
    /// <summary>
    /// عبارت جستجو
    /// </summary>
    public string SearchTerm { get; init; }

    /// <summary>
    /// شناسه مدل برای فیلتر
    /// </summary>
    public Guid? ModelId { get; init; }

    /// <summary>
    /// فقط تریم‌های فعال
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
