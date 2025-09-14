using MediatR;

namespace Dinawin.Erp.Application.Features.UomConversions.Queries.GetAllUomConversions;

/// <summary>
/// پرس‌وجو لیست تبدیلات واحد اندازه‌گیری
/// </summary>
public sealed class GetAllUomConversionsQuery : IRequest<IEnumerable<UomConversionDto>>
{
    /// <summary>
    /// عبارت جستجو
    /// </summary>
    public string SearchTerm { get; init; }

    /// <summary>
    /// شناسه واحد اندازه‌گیری مبدا برای فیلتر
    /// </summary>
    public Guid? FromUomId { get; init; }

    /// <summary>
    /// شناسه واحد اندازه‌گیری مقصد برای فیلتر
    /// </summary>
    public Guid? ToUomId { get; init; }

    /// <summary>
    /// وضعیت فعال بودن برای فیلتر
    /// </summary>
    public bool? IsActive { get; init; }

    /// <summary>
    /// ضریب تبدیل حداقل
    /// </summary>
    public decimal? MinConversionFactor { get; init; }

    /// <summary>
    /// ضریب تبدیل حداکثر
    /// </summary>
    public decimal? MaxConversionFactor { get; init; }

    /// <summary>
    /// شماره صفحه
    /// </summary>
    public int Page { get; init; } = 1;

    /// <summary>
    /// تعداد آیتم در هر صفحه
    /// </summary>
    public int PageSize { get; init; } = 25;
}
