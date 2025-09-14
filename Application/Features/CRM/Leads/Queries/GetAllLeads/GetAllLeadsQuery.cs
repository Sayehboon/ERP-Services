using MediatR;

namespace Dinawin.Erp.Application.Features.CRM.Leads.Queries.GetAllLeads;

/// <summary>
/// پرس‌وجو لیست لیدها
/// </summary>
public sealed class GetAllLeadsQuery : IRequest<IEnumerable<LeadDto>>
{
    /// <summary>
    /// عبارت جستجو
    /// </summary>
    public string SearchTerm { get; init; }

    /// <summary>
    /// وضعیت لید برای فیلتر
    /// </summary>
    public string Status { get; init; }

    /// <summary>
    /// منبع لید برای فیلتر
    /// </summary>
    public string LeadSource { get; init; }

    /// <summary>
    /// شناسه کاربر مسئول برای فیلتر
    /// </summary>
    public Guid? AssignedToId { get; init; }

    /// <summary>
    /// اولویت برای فیلتر
    /// </summary>
    public string Priority { get; init; }

    /// <summary>
    /// تاریخ شروع ایجاد
    /// </summary>
    public DateTime? CreatedFrom { get; init; }

    /// <summary>
    /// تاریخ پایان ایجاد
    /// </summary>
    public DateTime? CreatedTo { get; init; }

    /// <summary>
    /// شماره صفحه
    /// </summary>
    public int Page { get; init; } = 1;

    /// <summary>
    /// تعداد آیتم در هر صفحه
    /// </summary>
    public int PageSize { get; init; } = 25;
}
