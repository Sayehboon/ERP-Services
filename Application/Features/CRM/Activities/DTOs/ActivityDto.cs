namespace Dinawin.Erp.Application.Features.CRM.Activities.DTOs;

/// <summary>
/// DTO فعالیت
/// Activity DTO
/// </summary>
public class ActivityDto
{
    /// <summary>
    /// شناسه فعالیت
    /// Activity ID
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// عنوان فعالیت
    /// Activity title
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات فعالیت
    /// Activity description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// نوع فعالیت
    /// Activity type
    /// </summary>
    public string ActivityType { get; set; } = string.Empty;

    /// <summary>
    /// وضعیت فعالیت
    /// Activity status
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// اولویت فعالیت
    /// Activity priority
    /// </summary>
    public string Priority { get; set; } = string.Empty;

    /// <summary>
    /// تاریخ شروع فعالیت
    /// Activity start date
    /// </summary>
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// تاریخ پایان فعالیت
    /// Activity end date
    /// </summary>
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// تاریخ یادآوری
    /// Reminder date
    /// </summary>
    public DateTime? ReminderDate { get; set; }

    /// <summary>
    /// شناسه مخاطب مرتبط
    /// Related contact ID
    /// </summary>
    public Guid? ContactId { get; set; }

    /// <summary>
    /// نام مخاطب مرتبط
    /// Related contact name
    /// </summary>
    public string ContactName { get; set; }

    /// <summary>
    /// شناسه سرنخ مرتبط
    /// Related lead ID
    /// </summary>
    public Guid? LeadId { get; set; }

    /// <summary>
    /// نام سرنخ مرتبط
    /// Related lead name
    /// </summary>
    public string LeadName { get; set; }

    /// <summary>
    /// شناسه فرصت مرتبط
    /// Related opportunity ID
    /// </summary>
    public Guid? OpportunityId { get; set; }

    /// <summary>
    /// نام فرصت مرتبط
    /// Related opportunity name
    /// </summary>
    public string OpportunityName { get; set; }

    /// <summary>
    /// شناسه کاربر ایجادکننده
    /// Created by user ID
    /// </summary>
    public Guid? CreatedBy { get; set; }

    /// <summary>
    /// نام کاربر ایجادکننده
    /// Created by user name
    /// </summary>
    public string CreatedByName { get; set; }

    /// <summary>
    /// شناسه کاربر مسئول
    /// Assigned to user ID
    /// </summary>
    public Guid? AssignedTo { get; set; }

    /// <summary>
    /// نام کاربر مسئول
    /// Assigned to user name
    /// </summary>
    public string AssignedToName { get; set; }

    /// <summary>
    /// نتیجه فعالیت
    /// Activity result
    /// </summary>
    public string Result { get; set; }

    /// <summary>
    /// یادداشت‌های فعالیت
    /// Activity notes
    /// </summary>
    public string Notes { get; set; }

    /// <summary>
    /// وضعیت تکمیل فعالیت
    /// Activity completion status
    /// </summary>
    public bool IsCompleted { get; set; }

    /// <summary>
    /// تاریخ تکمیل فعالیت
    /// Activity completion date
    /// </summary>
    public DateTime? CompletedAt { get; set; }

    /// <summary>
    /// تاریخ ایجاد
    /// Created date
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// تاریخ آخرین بروزرسانی
    /// Last updated date
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}
