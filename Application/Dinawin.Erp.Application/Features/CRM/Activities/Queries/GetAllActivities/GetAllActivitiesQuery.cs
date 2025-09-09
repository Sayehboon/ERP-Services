using MediatR;
using Dinawin.Erp.Application.Features.CRM.Activities.DTOs;

namespace Dinawin.Erp.Application.Features.CRM.Activities.Queries.GetAllActivities;

/// <summary>
/// درخواست دریافت تمام فعالیت‌ها
/// </summary>
public class GetAllActivitiesQuery : IRequest<IEnumerable<ActivityDto>>
{
    /// <summary>
    /// شناسه مخاطب (اختیاری)
    /// </summary>
    public Guid? ContactId { get; set; }

    /// <summary>
    /// شناسه لید (اختیاری)
    /// </summary>
    public Guid? LeadId { get; set; }

    /// <summary>
    /// شناسه فرصت (اختیاری)
    /// </summary>
    public Guid? OpportunityId { get; set; }

    /// <summary>
    /// شناسه کاربر مسئول (اختیاری)
    /// </summary>
    public Guid? AssignedToUserId { get; set; }

    /// <summary>
    /// وضعیت فعالیت (اختیاری)
    /// </summary>
    public string? Status { get; set; }

    /// <summary>
    /// نوع فعالیت (اختیاری)
    /// </summary>
    public string? ActivityType { get; set; }

    /// <summary>
    /// از تاریخ (اختیاری)
    /// </summary>
    public DateTime? FromDate { get; set; }

    /// <summary>
    /// تا تاریخ (اختیاری)
    /// </summary>
    public DateTime? ToDate { get; set; }

    /// <summary>
    /// شماره صفحه
    /// </summary>
    public int Page { get; set; } = 1;

    /// <summary>
    /// تعداد آیتم در هر صفحه
    /// </summary>
    public int PageSize { get; set; } = 25;
}
