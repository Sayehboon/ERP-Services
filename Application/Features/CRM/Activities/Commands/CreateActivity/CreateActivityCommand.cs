using MediatR;

namespace Dinawin.Erp.Application.Features.CRM.Activities.Commands.CreateActivity;

/// <summary>
/// دستور ایجاد فعالیت جدید
/// </summary>
public class CreateActivityCommand : IRequest<Guid>
{
    /// <summary>
    /// عنوان فعالیت
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات فعالیت
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// نوع فعالیت
    /// </summary>
    public string ActivityType { get; set; } = string.Empty;

    /// <summary>
    /// وضعیت فعالیت
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// اولویت فعالیت
    /// </summary>
    public string Priority { get; set; } = string.Empty;

    /// <summary>
    /// تاریخ شروع
    /// </summary>
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// تاریخ پایان
    /// </summary>
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// شناسه مخاطب مرتبط
    /// </summary>
    public Guid? ContactId { get; set; }

    /// <summary>
    /// شناسه لید مرتبط
    /// </summary>
    public Guid? LeadId { get; set; }

    /// <summary>
    /// شناسه فرصت مرتبط
    /// </summary>
    public Guid? OpportunityId { get; set; }

    /// <summary>
    /// شناسه کاربر مسئول
    /// </summary>
    public Guid? AssignedToUserId { get; set; }

    /// <summary>
    /// شناسه کاربر ایجادکننده
    /// </summary>
    public Guid CreatedByUserId { get; set; }
}
