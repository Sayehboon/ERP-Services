using MediatR;

namespace Dinawin.Erp.Application.Features.CRM.Opportunities.Queries.GetAllOpportunities;

/// <summary>
/// پرس‌وجو لیست فرصت‌ها
/// </summary>
public sealed class GetAllOpportunitiesQuery : IRequest<IEnumerable<OpportunityDto>>
{
    /// <summary>
    /// عبارت جستجو
    /// </summary>
    public string? SearchTerm { get; init; }

    /// <summary>
    /// مرحله فرصت برای فیلتر
    /// </summary>
    public string? Stage { get; init; }

    /// <summary>
    /// وضعیت فرصت برای فیلتر
    /// </summary>
    public string? Status { get; init; }

    /// <summary>
    /// شناسه کاربر مسئول برای فیلتر
    /// </summary>
    public Guid? AssignedToId { get; init; }

    /// <summary>
    /// اولویت برای فیلتر
    /// </summary>
    public string? Priority { get; init; }

    /// <summary>
    /// نوع فرصت برای فیلتر
    /// </summary>
    public string? OpportunityType { get; init; }

    /// <summary>
    /// مبلغ حداقل
    /// </summary>
    public decimal? MinAmount { get; init; }

    /// <summary>
    /// مبلغ حداکثر
    /// </summary>
    public decimal? MaxAmount { get; init; }

    /// <summary>
    /// تاریخ شروع بسته شدن مورد انتظار
    /// </summary>
    public DateTime? ExpectedCloseFrom { get; init; }

    /// <summary>
    /// تاریخ پایان بسته شدن مورد انتظار
    /// </summary>
    public DateTime? ExpectedCloseTo { get; init; }

    /// <summary>
    /// شماره صفحه
    /// </summary>
    public int Page { get; init; } = 1;

    /// <summary>
    /// تعداد آیتم در هر صفحه
    /// </summary>
    public int PageSize { get; init; } = 25;
}
