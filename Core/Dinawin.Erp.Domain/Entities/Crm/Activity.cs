using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Crm;

/// <summary>
/// موجودیت فعالیت CRM
/// CRM Activity entity
/// </summary>
public class Activity : BaseEntity
{
    /// <summary>
    /// عنوان فعالیت
    /// Activity title
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات فعالیت
    /// Activity description
    /// </summary>
    public string? Description { get; set; }

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
    /// شناسه سرنخ مرتبط
    /// Related lead ID
    /// </summary>
    public Guid? LeadId { get; set; }

    /// <summary>
    /// شناسه فرصت مرتبط
    /// Related opportunity ID
    /// </summary>
    public Guid? OpportunityId { get; set; }

    

    /// <summary>
    /// شناسه کاربر مسئول
    /// Assigned to user ID
    /// </summary>
    public Guid? AssignedTo { get; set; }

    /// <summary>
    /// نتیجه فعالیت
    /// Activity result
    /// </summary>
    public string? Result { get; set; }

    /// <summary>
    /// یادداشت‌های فعالیت
    /// Activity notes
    /// </summary>
    public string? Notes { get; set; }

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
    public Guid AssignedToUserId { get; set; }
    public string Code { get; set; }
    public string Type { get; set; }
    public string ContactName { get; set; }
    public string AccountName { get; set; }
    public DateTime? DueDate { get; set; }
    public bool IsActive { get; set; }
    public string Subject { get; set; }
    public Guid UpdatedByUserId { get; set; }

    /// <summary>
    /// مخاطب مرتبط
    /// Related contact
    /// </summary>
    public Contact? Contact { get; set; }

    /// <summary>
    /// سرنخ مرتبط
    /// Related lead
    /// </summary>
    public Lead? Lead { get; set; }

    /// <summary>
    /// فرصت مرتبط
    /// Related opportunity
    /// </summary>
    public Opportunity? Opportunity { get; set; }

    /// <summary>
    /// کاربر مسئول
    /// Assigned user
    /// </summary>
    public Dinawin.Erp.Domain.Entities.Users.User? AssignedUser { get; set; }
}
