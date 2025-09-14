using MediatR;

namespace Dinawin.Erp.Application.Features.Uoms.Queries.GetActiveUoms;

/// <summary>
/// پرس‌وجو دریافت واحدهای اندازه‌گیری فعال
/// </summary>
public sealed class GetActiveUomsQuery : IRequest<IEnumerable<UomDto>>
{
    /// <summary>
    /// نوع واحد اندازه‌گیری (اختیاری)
    /// </summary>
    public string Type { get; init; }

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
