namespace Dinawin.Erp.Application.Features.CRM.Activities.Queries.GetAllActivities;

/// <summary>
/// DTO فعالیت
/// </summary>
public class ActivityDto
{
    /// <summary>
    /// شناسه فعالیت
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// عنوان فعالیت
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات فعالیت
    /// </summary>
    public string? Description { get; set; }

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
    /// نام مخاطب
    /// </summary>
    public string? ContactName { get; set; }

    /// <summary>
    /// شناسه لید مرتبط
    /// </summary>
    public Guid? LeadId { get; set; }

    /// <summary>
    /// نام لید
    /// </summary>
    public string? LeadName { get; set; }

    /// <summary>
    /// شناسه فرصت مرتبط
    /// </summary>
    public Guid? OpportunityId { get; set; }

    /// <summary>
    /// نام فرصت
    /// </summary>
    public string? OpportunityName { get; set; }

    /// <summary>
    /// شناسه کاربر مسئول
    /// </summary>
    public Guid? AssignedToUserId { get; set; }

    /// <summary>
    /// نام کاربر مسئول
    /// </summary>
    public string? AssignedToUserName { get; set; }

    /// <summary>
    /// شناسه کاربر ایجادکننده
    /// </summary>
    public Guid CreatedByUserId { get; set; }

    /// <summary>
    /// نام کاربر ایجادکننده
    /// </summary>
    public string CreatedByUserName { get; set; } = string.Empty;

    /// <summary>
    /// تاریخ ایجاد
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// تاریخ آخرین به‌روزرسانی
    /// </summary>
    public DateTime UpdatedAt { get; set; }
    public DateTime? ReminderDate { get; internal set; }
    public Guid? AssignedTo { get; internal set; }
    public bool IsCompleted { get; internal set; }
    public string? CreatedByName { get; internal set; }
    public Guid? CreatedBy { get; internal set; }
    public string? AssignedToName { get; internal set; }
    public string? Result { get; internal set; }
    public string? Notes { get; internal set; }
    public DateTime? CompletedAt { get; internal set; }
}
